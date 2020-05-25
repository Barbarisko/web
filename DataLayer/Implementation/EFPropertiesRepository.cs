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
   public  class EFPropertiesRepository : IPropertyRepository
    {
        private EFDBContext context;
        public EFPropertiesRepository (EFDBContext context)
        {
            this.context = context;
        }
        public void DeleteProperties(Properties prop)
        {
            context.Properties.Remove(prop);
            context.SaveChanges();
        }

        public IEnumerable<Properties> GetAllProperties(bool includeProperties = false)
        {
            if (includeProperties)
                return context.Set<Properties>().AsNoTracking().ToList();
            else
                return context.Properties.ToList();
        }

        public Properties GetPropertiesById(int propertyId, bool includeProperties = false)
        {
            if(includeProperties)
                return context.Set<Properties>().AsNoTracking().FirstOrDefault(x => x.Id == propertyId);
            else
                return context.Properties.FirstOrDefault(x => x.Id == propertyId);
        }

        public void SaveProperties(Properties prop)
        {
            if (prop.Id == 0)
                context.Properties.Add(prop);
            else
                context.Entry(prop).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
