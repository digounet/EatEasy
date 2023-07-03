using AutoMapper;
using EatEasy.Application.ViewModels;
using EatEasy.Domain.Commands.CategoryCommands;
using EatEasy.Domain.Commands.ProductCommands;
using EatEasy.Domain.Commands.UserCommands;

namespace EatEasy.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<RegisterUserViewModel, RegisterUserCommand>()
                .ConstructUsing(c => new RegisterUserCommand( c.Role, c.Name, c.Cpf, c.Password, c.Email, c.MobilePhone));
            CreateMap<LoginViewModel, LoginUserCommand>()
                .ConstructUsing(c => new LoginUserCommand(c.Cpf, c.Password));

            CreateMap<CategoryViewModel, RegisterCategoryCommand>()
                .ConstructUsing(c => new RegisterCategoryCommand(c.Name));
            CreateMap<CategoryViewModel, UpdateCategoryCommand>()
                .ConstructUsing(c => new UpdateCategoryCommand(c.Id, c.Name));

            CreateMap<ProductRegisterViewModel, RegisterProductCommand>()
                .ConstructUsing(c => new RegisterProductCommand(c.Name, c.Description, c.Category, c.Price));
            CreateMap<ProductRegisterViewModel, UpdateProductCommand>()
                .ConstructUsing(c => new UpdateProductCommand(c.Id,  c.Name,c.Description, c.Category, c.Price));
        }
    }
}
