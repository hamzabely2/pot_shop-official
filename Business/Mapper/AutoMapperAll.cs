using AutoMapper;
using Entity.Model;
using Model.Adress;
using Model.Cart;
using Model.DetailsItem;
using Model.Item;
using Model.Order;
using System.Collections.Generic;

namespace Mapper.Adress
{
    public class AutoMapperAll : Profile
    {
        public AutoMapperAll()
        {
            //adress mapper
            CreateMap<AddAddress, Entity.Model.Address>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(src => DateTime.UtcNow))
                .ForMember(dest => dest.UpdateDate, opt => opt.MapFrom(src => DateTime.UtcNow));
            CreateMap<Entity.Model.Address, ReadAddress>();

            CreateMap<PutAddress, Entity.Model.Address>()
                .ForMember(dest => dest.UpdateDate, opt => opt.MapFrom(src => DateTime.UtcNow));

            //cart mapper
            CreateMap<Cart, ReadCart>();
            CreateMap<AddCart, Cart>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(src => DateTime.UtcNow))
                .ForMember(dest => dest.UpdateDate, opt => opt.MapFrom(src => DateTime.UtcNow));

            CreateMap<Cart, CartItem>();

            //order mapper
            CreateMap<Order, ReadOrder>();

            CreateMap<Cart, OrderItem>()
            .ForMember(dest => dest.Item, opt => opt.MapFrom(src => src.Items))
            .ReverseMap();

            CreateMap<CartItem, OrderItem>()
           .ForMember(dest => dest.Item, opt => opt.MapFrom(src => src.Items));

            // item mapper
            CreateMap<Entity.Model.Item, ReadItem>();
            CreateMap<CategoryDto, Category>();
            CreateMap<Category, CategoryDto>();
            CreateMap<Color, ColorDto>();
            CreateMap<Material, MaterialDto>();


            CreateMap<ItemAdd, Entity.Model.Item>();
            CreateMap<ItemUpdate, Entity.Model.Item>();
            CreateMap<Cart, CartItem>();
            CreateMap<ColorDto, Color>();

          

        }
    }

}


