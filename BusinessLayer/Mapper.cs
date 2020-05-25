using AutoMapper;
using DataLayer.Entities;
using BusinessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer
{
    public class Mapper:Profile
    {
        public Mapper()
        {
            CreateMap<Product, ProductModel>()
                 .ForMember(d => d.OrderId, opt => opt.MapFrom(src => src.OrderId))
                .ReverseMap();

            CreateMap<Properties, PropertyModel>()               
                .ReverseMap();

            CreateMap<ProductProperties, ProdPropModel>()
                .ForMember(d => d.ProductId, opt => opt.MapFrom(src => src.ProductId))
                .ForMember(d => d.PropertiesId, opt => opt.MapFrom(src => src.PropertiesId))
                .ReverseMap();
            
            CreateMap<Order, OrderModel>()
                .ForMember(d => d.CustomerId, opt => opt.MapFrom(src => src.CustomerId))
                .ForMember(d => d.products, opt => opt.MapFrom(src => src.products))
                .ReverseMap();

            CreateMap<Customer, CustomerModel>()
                .ForMember(d => d.orders, opt => opt.MapFrom(src => src.orders))
                .ForMember(d => d.ShopId, opt => opt.MapFrom(src => src.ShopId))
                .ReverseMap();

            CreateMap<Shop, ShopModel>()
                .ForMember(d => d.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(d => d.customers, opt => opt.MapFrom(src => src.customers))
                .ReverseMap();
        }
    }
}
