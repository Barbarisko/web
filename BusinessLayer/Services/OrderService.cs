using AutoMapper;
using BusinessLayer.Interfaces;
using BusinessLayer.Models;
using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace BusinessLayer.Services
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork UnitOfWork;
        IMapper mapper;
        IProductService productService;

        public OrderService(IUnitOfWork unitOfWork, IMapper mapper, IProductService _productService)
        {
            UnitOfWork = unitOfWork;
            this.mapper = mapper;
            productService = _productService;
        }
        public int CountSum(OrderModel order)
        {
            int ordersum = 0;

            foreach (ProductModel product in productService.GetAllProducts(order))
            {
                ordersum += product.Price;
            }
            return ordersum;
        }

        public OrderModel GetOrder(int id)
        {
            var order = UnitOfWork.OrderR.GetOrderById(id);
            var ordermodel = mapper.Map<OrderModel>(order);
            return ordermodel;
        }

        public IEnumerable<OrderModel> GetOrdersFromCustomer(CustomerModel customer)
        {
            var ordersfromCust = new List<Order>();
            foreach(Order o in UnitOfWork.OrderR.GetAllOrders())
            {
                if (o.CustomerId==customer.Id)
                {
                    ordersfromCust.Add(o);
                }
            }

            var ordermodels = mapper.Map<IEnumerable<OrderModel>>(ordersfromCust);
            return ordermodels;
        }
    }
}
