using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLayer.Interfaces;
using BusinessLayer.Models;
using BusinessLayer.Services;
using DataLayer;
using DataLayer.Implementation;
using DataLayer.Interfaces;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using IdentityRole = Microsoft.AspNet.Identity.EntityFramework.IdentityRole;

namespace ShopApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<EFDBContext>(opt =>
            opt.UseSqlServer(Configuration.GetConnectionString("ShopDb")));

                services.AddScoped<IProductPropertyRepository, EFProductPropertiesRepository>();
                services.AddScoped<IPropertyRepository, EFPropertiesRepository>();

                services.AddScoped<IProductRepository, EFProductRepository>();
                services.AddScoped<IOrderRepository, EFOrderRepository>();
                services.AddScoped<ICustomerRepository, EFCustomerRepository>();

                services.AddScoped<IUnitOfWork, UnitOfWork>();
                services.AddSingleton(new MapperConfiguration(c => c.AddProfile(new BusinessLayer.Mapper())).CreateMapper());

                services.AddTransient<IShopService, ShopService>();
                services.AddTransient<IProductService, ProductService>();
                services.AddTransient<IOrderService, OrderService>();
                services.AddTransient<ICustomerService, CustomerService>();

            services.AddIdentity<AppUser, IdentityRole>(options => options.SignIn.RequireConfirmedEmail = false)
                    .AddEntityFrameworkStores<EFDBContext>()
                    .AddDefaultTokenProviders();

            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
            services
                .AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

                })
                .AddJwtBearer(cfg =>
                {
                    cfg.RequireHttpsMetadata = false;
                    cfg.SaveToken = true;
                    cfg.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidIssuer = Configuration["SecurityConfig:JwtIssuer"],
                        ValidAudience = Configuration["SecurityConfig:JwtIssuer"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["SecurityConfig:JwtKey"])),
                        ClockSkew = TimeSpan.Zero
                    };
                });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
