﻿using API.Core.DbModels;
using API.Core.DbModels.Identity;
using API.Core.DbModels.OrderAggregate;
using API.Dtos;
using AutoMapper;
using ETicaret.Dtos;

namespace API.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product, ProductToReturnDto>()
               .ForMember(x => x.ProductBrand, o => o.MapFrom(s => s.ProductBrand.Name))
               .ForMember(x => x.ProductType, o => o.MapFrom(s => s.ProductType.Name))
               .ForMember(x => x.PictureUrl, o => o.MapFrom<ProductUrlResolver>());

            CreateMap<ProductToReturnDto, Product>()
                   .ForMember(dest => dest.ProductBrand, opt => opt.Ignore())
                   .ForMember(dest => dest.ProductType, opt => opt.Ignore())
                   .ForMember(dest => dest.PictureUrl, opt => opt.Ignore());

            CreateMap<Core.DbModels.Identity.Address,AddressDto>().ReverseMap();
            CreateMap<CustomerBasketDto, CustomerBasket>();
            CreateMap<BasketItemDto, BasketItem>();
            CreateMap<AddressDto, Core.DbModels.OrderAggregate.OrderAddress>().ReverseMap();

            CreateMap<Order, OrderToReturnDto>()
            .ForMember(d => d.DeliveryMethod, o => o.MapFrom(s => s.DeliveryMethod.ShortName))
             .ForMember(d =>d.ShippingPrice, o => o.MapFrom(s => s.DeliveryMethod.Price));

            CreateMap<OrderItem, OrderItemDto>()
                .ForMember(d =>d.ProductId,o=>o.MapFrom(s=>s.ItemOrdered.ProductItemId))
                .ForMember(d => d.ProductName, o => o.MapFrom(s => s.ItemOrdered.ProductName))
                .ForMember(d => d.ImageUrl, o => o.MapFrom(s => s.ItemOrdered.PictureUrl))
                .ForMember(d => d.ImageUrl, o => o.MapFrom<OrderItemUrlResolver>());
        }

    }

}
