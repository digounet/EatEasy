using AutoMapper;
using EatEasy.Application.ViewModels;
using EatEasy.Domain.Commands.CategoryCommands;
using EatEasy.Domain.Commands.ClientCommands;
using EatEasy.Domain.Commands.ProductCommands;

namespace EatEasy.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<RegisterClientViewModel, RegisterClientCommand>()
                .ConstructUsing(c => new RegisterClientCommand(c.Name, c.Cpf, c.Password, c.Email, c.MobilePhone));
            CreateMap<RegisterClientViewModel, UpdateClientCommand>()
                .ConstructUsing(c => new UpdateClientCommand(c.Id,  c.Name, c.Cpf, c.Password, c.Email, c.MobilePhone));

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
