using Application.Features.Orders.Commands.CreateOrder;
using Application.Features.Restaurants.Commands.UpdateRestaurant;
using Application.Features.Restaurants.Queries.GetRestaurantDetail;
using Application.Features.Restaurants.Queries.GetRestaurantsList;
using Application.Features.Restaurants.Queries.GetRestaurantsListWithMenus;
using Application.Features.Users.Commands.LoginUsers;
using Application.Features.Users.Commands.RegisterUsers;
using AutoMapper;
using Domain.Entities;

namespace Application.Profiles;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<AppUser, RegisterCommand>().ReverseMap();
        CreateMap<AppUser, RegisterUserDto>()
            .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FirstName + " " + src.LastName))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
            .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName))
            .ReverseMap();
        CreateMap<AppUser, LoginCommand>().ReverseMap();

        CreateMap<Restaurant, RestaurantListVm>().ReverseMap();
        CreateMap<Restaurant, RestaurantMenuDto>().ReverseMap();
        CreateMap<Menu, RestaurantMenuDto>().ReverseMap();
        CreateMap<Restaurant, RestaurantsListWithMenusVm>().ReverseMap();
        CreateMap<Restaurant, RestaurantDetailVm>().ReverseMap();
        CreateMap<Restaurant, UpdateRestaurantCommand>().ReverseMap();

        CreateMap<Order, CreateOrderCommand>()
            .ForMember(dest => dest.RestaurantId, opt => opt.MapFrom(src => src.RestaurantId))
            .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => src.CustomerName))
            .ReverseMap();
    }
}
