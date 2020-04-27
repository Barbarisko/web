using BusinessLayer.Interfaces;
using DataLayer;
using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLayer.Implementation
{
    class EFOrderRepository : IOrderRepository
    {
        private EFDBContext context;
        public EFOrderRepository(EFDBContext context)
        {
            this.context = context;
        }
        public void DeleteOrder(Order order)
        {
            context.Orders.Remove(order);
            context.SaveChanges();
        }

        public IEnumerable<Order> GetAllOrders(bool includeOrder = false)
        {
            if (includeOrder)
                return context.Set<Order>().AsNoTracking().ToList();
            else
                return context.Orders.ToList();
        }

        public Order GetOrderById(int OrderId, bool includeOrder = false)
        {
            if (includeOrder)
                return context.Set<Order>().AsNoTracking().FirstOrDefault(x => x.Id == OrderId);
            else
                return context.Orders.FirstOrDefault(x=>x.Id==OrderId);
        }

        public void SaveOrder(Order order)
        {
            if (order.Id == 0)
                context.Orders.Add(order);
            else
                context.Entry(order).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
