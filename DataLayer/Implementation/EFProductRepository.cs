using BusinessLayer.Interfaces;
using DataLayer;
using DataLayer.Entities;
using DataLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLayer.Implementation
{
    public class EFProductRepository : IProductRepository
    {
        private EFDBContext context;
        private readonly List<Product> contextList;

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

        public void DeleteProduct(int id)
        {
            foreach (Product  e in contextList)
            {
                if (e.Id == id)
                {
                    context.Products.Remove(e);
                }
            }
            context.SaveChanges();
        }
        
       
    }
}
