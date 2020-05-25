using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Interfaces
{
   public  interface IOrderRepository
    {
        IEnumerable<Order> GetAllOrders(bool includeOrder = false);
        Order GetOrderById(int OrderId, bool includeOrder = false);
        void SaveOrder(Order order);
        void DeleteOrder(Order order);
    }
}
