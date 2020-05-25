using DataLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interfaces
{
   public  interface IUnitOfWork
    {
         IProductRepository ProductR { get; }
         IProductPropertyRepository PPR { get; }
         IOrderRepository OrderR { get; }
         IPropertyRepository PropertyR { get; }
         ICustomerRepository CustomerR { get; }
         IShopRepository ShopR { get; }

        void Save();
    }
}
