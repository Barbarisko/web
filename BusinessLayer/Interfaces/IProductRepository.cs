using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interfaces
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAllItems(bool includeProducts = false);
        Product GetProductById(int productId, bool includeProducts = false);
        void SaveProduct(Product product);
        void DeleteProduct(Product Product);
    }
}
