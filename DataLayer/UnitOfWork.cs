using BusinessLayer.Interfaces;
using DataLayer.Entities;
using DataLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer
{
    public class UnitOfWork:IUnitOfWork
    {
        //для удобства пользования большой кучей репозиториев
        private IProductRepository productRepo;
        private IProductPropertyRepository ppRepo;
        private IOrderRepository orderRepo;
        private IPropertyRepository propertyRepo;
        private ICustomerRepository customerRepo;
        private IShopRepository shopRepo;
        private readonly EFDBContext context;
        public IProductRepository ProductR { get { return productRepo; } }
        public IProductPropertyRepository PPR { get { return ppRepo; } }
        public IOrderRepository OrderR { get { return orderRepo; } }
        public IPropertyRepository PropertyR { get { return propertyRepo; } }
        public ICustomerRepository CustomerR { get { return customerRepo; } }
        public IShopRepository ShopR { get { return shopRepo; } }

        public UnitOfWork(EFDBContext context,
            IProductRepository productRepo,
                            IProductPropertyRepository ppRepo,
                            IOrderRepository orderRepo,
                            IPropertyRepository propertyRepo,
                            ICustomerRepository customerRepo, IShopRepository shopRepo)
        {
            this.context = context;
            this.productRepo = productRepo;
            this.ppRepo = ppRepo;
            this.orderRepo = orderRepo;
            this.propertyRepo = propertyRepo;
            this.customerRepo = customerRepo;
            this.shopRepo = shopRepo;
        }



        public void Save()
        {
            context.SaveChanges();
        }
    }
}
