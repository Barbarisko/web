using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer
{
    public class EFDBContext: DbContext
    { 
        public EFDBContext(DbContextOptions<EFDBContext> options) : base(options)
        {
            //Database.EnsureDeleted();
            //Database.EnsureCreated();
            //Products.Add(new Product() { Name = "Cake", Price = "120" });
            //Products.Add(new Product() { Name = "Trifle", Price = "60" });
            //Products.Add(new Product() { Name = "Muffin", Price = "15" });
            //Products.Add(new Product() { Name = "Eclair", Price = "30" });


        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Properties> Properties { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<ProductProperties> ProductProperties { get; set; }



      
    }

    //миграции
    public class EFDBContextFactory:IDesignTimeDbContextFactory<EFDBContext>
    {
       
        public EFDBContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<EFDBContext>();
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb; Database = ShopDb; Trusted_Connection = True; MultipleActiveResultSets=true", b => b.MigrationsAssembly("DataLayer"));
            return new EFDBContext(optionsBuilder.Options);
        }
    }
}
