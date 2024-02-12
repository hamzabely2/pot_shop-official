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
    public class AdressMapper : Profile
    {
        public AdressMapper()
        {
            //adress mapper
            CreateMap<AdressAdd, Entity.Model.Adress>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(src => DateTime.UtcNow))
                .ForMember(dest => dest.UpdateDate, opt => opt.MapFrom(src => DateTime.UtcNow));
            CreateMap<Entity.Model.Adress, AdressRead>();

            CreateMap<AdressPut, Entity.Model.Adress>()
                .ForMember(dest => dest.UpdateDate, opt => opt.MapFrom(src => DateTime.UtcNow));

            //cart mapper
            CreateMap<Cart, ReadCart>();
            CreateMap<AddCart, Cart>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(src => DateTime.UtcNow))
                .ForMember(dest => dest.UpdateDate, opt => opt.MapFrom(src => DateTime.UtcNow));

            CreateMap<Cart, CartItem>();

            //order mapper
            CreateMap<Order,ReadOrder>();

            CreateMap<Cart, OrderItem>()
            .ForMember(dest => dest.Item, opt => opt.MapFrom(src => src.Items))
            .ReverseMap();

            CreateMap<CartItem, OrderItem>()
           .ForMember(dest => dest.Item, opt => opt.MapFrom(src => src.Items));

            // item mapper
            CreateMap<Entity.Model.Item, ReadItem>();
            CreateMap<ItemAdd, Entity.Model.Item>();

            CreateMap<Category, CategoryDto>();
            CreateMap<Color, ColorDto>();
            CreateMap<Material, MaterialDto>();

            CreateMap<Image, ImageDto>();
            CreateMap<ItemUpdate, Entity.Model.Item>();


        }
    }
}
