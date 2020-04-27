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
    class EFCustomerRepository : ICustomerRepository
    {
        private EFDBContext context;
        public EFCustomerRepository(EFDBContext context)
        {
            this.context = context;
        }
        public void DeleteCustomer(Customer customer)
        {
            context.Customers.Remove(customer);
            context.SaveChanges();
        }

        public IEnumerable<Customer> GetAllCustomers(bool includeCustomer = false)
        {
            if (includeCustomer)
                return context.Set<Customer>().AsNoTracking().ToList();
            else
                return context.Customers.ToList();
        }

        public Customer GetCustomerById(int CustomerId, bool includeCustomer = false)
        {
            if (includeCustomer)
                return context.Set<Customer>().AsNoTracking().FirstOrDefault(x => x.Id == CustomerId);
            else
                return context.Customers.FirstOrDefault(x => x.Id == CustomerId);
        }

        public void SaveCustomer(Customer customer)
        {
            if (customer.Id == 0)
                context.Customers.Add(customer);
            else
                context.Entry(customer).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
