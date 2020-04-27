using BusinessLayer.Interfaces;
using DataLayer;
using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLayer.Implementation
{
    class EFProductRepository : IProductRepository
    {
        private EFDBContext context;
        public EFProductRepository(EFDBContext context)
        {
            this.context = context;
        }
        public IEnumerable<Product> GetAllItems(bool includeProducts = false)
        {
            if (includeProducts) 
                return context.Set<Product>().AsNoTracking().ToList();
            else
                return context.Products.ToList();
        } 
        public Product GetProductById(int productId, bool includeProducts = false)
        {
            if (includeProducts)
                return context.Set<Product>().AsNoTracking().FirstOrDefault(x => x.Id == productId);
            else
                return context.Products.FirstOrDefault(x => x.Id == productId);
        }

        public void SaveProduct(Product product)
        {
            if (product.Id == 0)
                context.Products.Add(product);
            else
                context.Entry(product).State = EntityState.Modified;
            context.SaveChanges();

        }

        public void DeleteProduct(Product product)
        {
            context.Products.Remove(product);
            context.SaveChanges();
        }
        
       
    }
}
