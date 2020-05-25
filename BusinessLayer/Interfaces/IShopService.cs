using AutoMapper;
using BusinessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interfaces
{
    public interface IShopService
    {
        ShopModel GetShop(int id);

    }
}
