using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLayer
{
   public static class SampleData
    {
		private static bool initialized = false;

		public static void InitData(EFDBContext context)
        {
			//if(!context.Products.Any())
			//{
			//    context.Products.Add(new Entities.Product() { Name = "Cake", Price = "120"  });
			//    context.Products.Add(new Entities.Product() { Name = "Trifle", Price = "60" });
			//    context.Products.Add(new Entities.Product() { Name = "Muffin", Price = "15" });
			//    context.Products.Add(new Entities.Product() { Name = "Eclair", Price = "30" });

			//    context.SaveChanges();
			//    context.Properties.Add(new Entities.Properties() { Mass = 2000, MainIng = "cottoncake", DateOfCreate = new DateTime(2020, 4, 1), ExpireDate = new  DateTime(2020, 4, 20)});
			//    context.Properties.Add(new Entities.Properties() { Mass = 100, MainIng = "sour cream, cookies", DateOfCreate = new DateTime(2020, 4, 11), ExpireDate = DateTime.Today });
			//    context.Properties.Add(new Entities.Properties() { Mass = 100, MainIng = "zests", DateOfCreate = new DateTime(2020, 4, 5), ExpireDate = DateTime.Now });
			//    context.Properties.Add(new Entities.Properties() { Mass = 100, MainIng = "whipped Cream", DateOfCreate = new DateTime(2020, 4, 6), ExpireDate = DateTime.Now });
			//    context.SaveChanges();
			//    context.ProductProperties.Add(new Entities.ProductProperties() { ProductId = context.Products.First().Id, PropertiesId = context.Properties.First().Id });
			//    context.ProductProperties.Add(new Entities.ProductProperties() { ProductId = context.Products.Last().Id, PropertiesId = context.Properties.Last().Id });
			//    context.SaveChanges();
			//}

				if (initialized = true)
				{
					return;
				}
				context.Database.EnsureDeleted();
				context.Database.EnsureCreated();

				Product one = new Product()
				{
					Name = "Cake",
					Price = 120
				};

				Product two = new Product()
				{
					Name = "Trifle",
					Price = 60
				};
				Product three = new Product()
				{
					Name = "Muffin",
					Price = 15
				};
				Product four = new Product()
				{
					Name = "Eclair",
					Price = 30
				};

				Properties prop1 = new Properties()
				{
					Mass = 2000,
					MainIng = "cottoncake",
					DateOfCreate = new DateTime(2020, 4, 1),
					ExpireDate = new DateTime(2020, 4, 20)
				};

				Properties prop2 = new Properties()
				{
					Mass = 100,
					MainIng = "sour cream, cookies",
					DateOfCreate = new DateTime(2020, 4, 11),
					ExpireDate = DateTime.Today

				};
				Properties prop3 = new Properties()
				{
					Mass = 100,
					MainIng = "zests",
					DateOfCreate = new DateTime(2020, 4, 5),
					ExpireDate = DateTime.Now
				};
				Properties prop4 = new Properties()
				{
					Mass = 100,
					MainIng = "whipped Cream",
					DateOfCreate = new DateTime(2020, 4, 6),
					ExpireDate = DateTime.Now
				};

				ProductProperties pp1 = new ProductProperties()
				{
					ProductId = one.Id,
					PropertiesId = prop1.Id
				};

				ProductProperties pp2 = new ProductProperties()
				{
					ProductId = two.Id,
					PropertiesId = prop2.Id
				};
				ProductProperties pp3 = new ProductProperties()
				{
					ProductId = three.Id,
					PropertiesId = prop3.Id
				};
				ProductProperties pp4 = new ProductProperties()
				{
					ProductId = four.Id,
					PropertiesId = prop4.Id
				};

				Order o1 = new Order()
				{
					Paydate = new DateTime(2020, 5, 23),
					products = new List<Product>() { one, four }
				};

				Order o2 = new Order()
				{
					Paydate = new DateTime(2020, 5, 23),
					products = new List<Product>() { two, three }
				};

				Customer c1 = new Customer()
				{
					Name = "Sasha",
					orders = new List<Order>() { o1 }
				};
				Customer c2 = new Customer()
				{
					Name = "Olya",
					orders = new List<Order>() { o2 }
				};

				Shop sh = new Shop()
				{

					customers = new List<Customer>() { c1, c2 }
				};

				context.Shops.Add(sh);
				//context.ProductProperties.Add(pp1);
				//context.ProductProperties.Add(pp2);
				//context.ProductProperties.Add(pp3);

				context.SaveChanges();

				initialized = true;
			
			
		}
    }

}
