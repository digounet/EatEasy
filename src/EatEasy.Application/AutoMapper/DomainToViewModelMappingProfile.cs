using AutoMapper;
using EatEasy.Application.ViewModels;
using EatEasy.Domain.Models;
using Microsoft.AspNetCore.Identity;

namespace EatEasy.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<User, UserViewModel>()
                .ForMember(dest => dest.MobilePhone, o => o.MapFrom(src => src.PhoneNumber));
            CreateMap<Category, CategoryViewModel>();
            CreateMap<Product, ProductViewModel>();
            CreateMap<IdentityRole, RoleViewModel>().ConstructUsing(x => new RoleViewModel
            {
                Name = x.Name
            });
            CreateMap<Order, OrderViewModel>();
            CreateMap<OrderItem, OrderItemViewModel>();

        }
    }
}
