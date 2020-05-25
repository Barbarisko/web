using BusinessLayer.Models;
using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interfaces
{
   public interface IOrderService
    {
        IEnumerable<OrderModel> GetOrdersFromCustomer(CustomerModel customer);
        int CountSum(OrderModel order);
        OrderModel GetOrder(int id);
    }
}
