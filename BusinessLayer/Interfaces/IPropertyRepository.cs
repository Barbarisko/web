using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interfaces
{
    public interface IPropertyRepository
    {
        IEnumerable<Properties> GetAllProperties(bool includeProperties = false);
        Properties GetPropertiesById(int propertyId, bool includeProperties = false);
        void SaveProperties(Properties product);
        void DeleteProperties(Properties Product);
    }
}
