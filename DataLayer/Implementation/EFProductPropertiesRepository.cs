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
    public class EFProductPropertiesRepository:IProductPropertyRepository
    {
        private EFDBContext context;
        public EFProductPropertiesRepository(EFDBContext context)
        {
            this.context = context;
        }

        public void DeleteProductProperties(ProductProperties PP)
        {
            context.ProductProperties.Remove(PP);
            context.SaveChanges();
        }

        public IEnumerable<ProductProperties> GetAllPP(bool includePP = false)
        {
            if (includePP)
                return context.Set<ProductProperties>().AsNoTracking().ToList();
            else
                return context.ProductProperties.ToList();
        }

        public ProductProperties GetProductPropertiesById(int PPId, bool includePP = false)
        {
            if (includePP)
                return context.Set<ProductProperties>().AsNoTracking().FirstOrDefault(x => x.Id == PPId);
            else
                return context.ProductProperties.FirstOrDefault(x=>x.Id==PPId);
        }

        public void SaveProductProperties(ProductProperties PP)
        {
            if (PP.Id == 0)
                context.ProductProperties.Add(PP);
            else
                context.Entry(PP).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
