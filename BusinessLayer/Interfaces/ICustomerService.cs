using BusinessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interfaces
{
   public  interface ICustomerService
    {
        //for fututre admin role
        CustomerModel GetCustomer(int id);
        IEnumerable<CustomerModel> GetAll(ShopModel shop);
    }
}
