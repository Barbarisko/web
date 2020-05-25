using AutoMapper;
using BusinessLayer.Interfaces;
using BusinessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Services
{
    public class ShopService : IShopService
    {
        private readonly IUnitOfWork unitOfWork;
        IMapper mapper;
        public ShopService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public ShopModel GetShop(int id)
        {
            var shops = unitOfWork.ShopR.GetShopById(id);
            var shopmodels = mapper.Map<ShopModel>(shops);
            return shopmodels;
        }
    }
}
