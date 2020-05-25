using AutoMapper;
using BusinessLayer.Interfaces;
using BusinessLayer.Models;
using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork unitOfWork;
        IMapper mapper;
        public void AddProductToOrder( ProductModel product)
        {
            var newproduct = mapper.Map<Product>(product);
            unitOfWork.ProductR.SaveProduct(newproduct);
            unitOfWork.Save();
        }
        public void DeleteProductFromOrder(ProductModel product)
        {
            unitOfWork.ProductR.DeleteProduct(product.Id);
            unitOfWork.Save();
        }
        public void EditProduct(ProductModel product)
        {
        foreach(Product oldpr in unitOfWork.ProductR.GetAllItems())
            {
                if (oldpr.Id==product.Id)
                {
                    oldpr.Name = product.Name;
                    oldpr.Price = product.Price;
                    unitOfWork.ProductR.SaveProduct(oldpr);
                    unitOfWork.Save();
                    break;
                }
            }
        }
        public IEnumerable<ProductModel> GetAllProducts(OrderModel order)
        {
            var productsfromorder = new List<Product>();
            foreach(Product pr in unitOfWork.ProductR.GetAllItems())
            {
                if(pr.OrderId == order.Id)
                {
                    productsfromorder.Add(pr);
                }
            }
            var prmodels = mapper.Map<IEnumerable<ProductModel>>(productsfromorder);
            return prmodels;
        }
        public ProductModel GetProduct(int id)
        {
            var products = unitOfWork.ProductR.GetAllItems();
            var prmodels = mapper.Map<ProductModel>(products);
            return prmodels;
        }
    }
}
