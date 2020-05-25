using DataLayer.Entities;
using DataLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLayer.Implementation
{
    public class EFShopRepository : IShopRepository
    {
        private EFDBContext context;
        public EFShopRepository(EFDBContext context)
        {
            this.context = context;
        }

        public void DeleteShop(Shop shop)
        {
            context.Shops.Remove(shop);
            context.SaveChanges();
        }

        public IEnumerable<Shop> GetAllShops(bool includeShop = false)
        {
            if (includeShop)
                return context.Set<Shop>().AsNoTracking().ToList();
            else
                return context.Shops.ToList();
        }

        public Shop GetShopById(int ShopId, bool includeShop = false)
        {
            if (includeShop)
                return context.Set<Shop>().AsNoTracking().FirstOrDefault(x => x.Id == ShopId);
            else
                return context.Shops.FirstOrDefault(x => x.Id == ShopId);
        }

        public void SaveShop(Shop shop)
        {
            if (shop.Id == 0)
                context.Shops.Add(shop);
            else context.Entry(shop).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
