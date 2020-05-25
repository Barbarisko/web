using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Interfaces
{
    public interface IProductPropertyRepository
    {
        IEnumerable<ProductProperties> GetAllPP(bool includePP = false);
        ProductProperties GetProductPropertiesById(int PPId, bool includePP = false);
        void SaveProductProperties(ProductProperties PP);
        void DeleteProductProperties(ProductProperties PP);
    }
}
