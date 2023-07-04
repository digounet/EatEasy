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
            CreateMap<User, UserViewModel>();
            CreateMap<Category, CategoryViewModel>();
            CreateMap<Product, ProductViewModel>();
            CreateMap<IdentityRole, RoleViewModel>().ConstructUsing(x => new RoleViewModel
            {
                Name = x.Name
            });
        }
    }
}
