using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interfaces
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> GetAllCustomers(bool includeCustomer = false);
        Customer GetCustomerById(int CustomerId, bool includeCustomer = false);
        void SaveCustomer(Customer customer);
        void DeleteCustomer(Customer customer);
    }
}
