using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLayer
{
   public static class SampleData
    {
        public static void InitData(EFDBContext context)
        {
            if(!context.Products.Any())
            {
                context.Products.Add(new Entities.Product() { Name = "Cake", Price = "120"  });
                context.Products.Add(new Entities.Product() { Name = "Trifle", Price = "60" });
                context.Products.Add(new Entities.Product() { Name = "Muffin", Price = "15" });
                context.Products.Add(new Entities.Product() { Name = "Eclair", Price = "30" });

                context.SaveChanges();
                context.Properties.Add(new Entities.Properties() { Mass = 2000, MainIng = "cottoncake", DateOfCreate = new DateTime(2020, 4, 1), ExpireDate = new  DateTime(2020, 4, 20)});
                context.Properties.Add(new Entities.Properties() { Mass = 100, MainIng = "sour cream, cookies", DateOfCreate = new DateTime(2020, 4, 11), ExpireDate = DateTime.Today });
                context.Properties.Add(new Entities.Properties() { Mass = 100, MainIng = "zests", DateOfCreate = new DateTime(2020, 4, 5), ExpireDate = DateTime.Now });
                context.Properties.Add(new Entities.Properties() { Mass = 100, MainIng = "whipped Cream", DateOfCreate = new DateTime(2020, 4, 6), ExpireDate = DateTime.Now });
                context.SaveChanges();
                context.ProductProperties.Add(new Entities.ProductProperties() { ProductId = context.Products.First().Id, PropertiesId = context.Properties.First().Id });
                context.ProductProperties.Add(new Entities.ProductProperties() { ProductId = context.Products.Last().Id, PropertiesId = context.Properties.Last().Id });
                context.SaveChanges();
            }
        }
    }

}
