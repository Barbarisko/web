using AutoMapper;
using BusinessLayer.Interfaces;
using BusinessLayer.Models;
using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IUnitOfWork unitOfWork;
        IMapper mapper;
        public CustomerService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public IEnumerable<CustomerModel> GetAll(ShopModel shop)
        {
            var customersInShop = new List<Customer>();
            foreach(Customer c in unitOfWork.CustomerR.GetAllCustomers())
            {
                if(c.ShopId == shop.Id)
                {
                    customersInShop.Add(c);
                }
            }
            var custmodels = mapper.Map<IEnumerable<CustomerModel>>(customersInShop);
            return custmodels;
        }

        public CustomerModel GetCustomer(int id)
        {
            var customers = unitOfWork.CustomerR.GetCustomerById(id);
            var custmodels = mapper.Map<CustomerModel>(customers);
            return custmodels;
        }
    }
}
