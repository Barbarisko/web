using BusinessLayer.Interfaces;
using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Interfaces
{
   public  interface IShopRepository
    {
        IEnumerable<Shop> GetAllShops(bool includeShop = false);
        Shop GetShopById(int ShopId, bool includeShop = false);
        void SaveShop(Shop shop);
        void DeleteShop(Shop shop);
    }
}
