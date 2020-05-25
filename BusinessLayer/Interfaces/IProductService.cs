using BusinessLayer.Models;

using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;

namespace BusinessLayer.Interfaces
{
    public interface IProductService
    {
        ProductModel GetProduct(int id);
        IEnumerable<ProductModel> GetAllProducts(OrderModel order);
        void AddProductToOrder( ProductModel product);
        void DeleteProductFromOrder( ProductModel product);
        void EditProduct(ProductModel product);
    }
}
