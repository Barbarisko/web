using BusinessLayer.Models;
using DataLayer.Entities;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer
{
    public class EFDBContext : IdentityDbContext<AppUser>
    { 
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Properties> Properties { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<ProductProperties> ProductProperties { get; set; }
        public DbSet<Shop> Shops { get; set; }
        public EFDBContext(DbContextOptions<EFDBContext> options) : base(options)
        {
            SampleData.InitData(this);
        }
    }

    //миграции
    //public class EFDBContextFactory:IDesignTimeDbContextFactory<EFDBContext>
    //{       
    //    public EFDBContext CreateDbContext(string[] args)
    //    {
    //        var optionsBuilder = new DbContextOptionsBuilder<EFDBContext>();
    //        optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb; Database = ShopDb; Trusted_Connection = True; MultipleActiveResultSets=true", b => b.MigrationsAssembly("DataLayer"));
    //        return new EFDBContext(optionsBuilder.Options);
    //    }
    //}
}
