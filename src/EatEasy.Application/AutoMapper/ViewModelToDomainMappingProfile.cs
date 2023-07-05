using AutoMapper;
using EatEasy.Application.ViewModels;
using EatEasy.Domain.Commands.CategoryCommands;
using EatEasy.Domain.Commands.OrderCommands;
using EatEasy.Domain.Commands.OrderItemCommands;
using EatEasy.Domain.Commands.ProductCommands;
using EatEasy.Domain.Commands.UserCommands;
using EatEasy.Domain.Models;

namespace EatEasy.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<RegisterUserViewModel, RegisterUserCommand>()
                .ConstructUsing(c => new RegisterUserCommand( c.RoleName, c.Name, c.Cpf, c.Password, c.Email, c.MobilePhone));
            CreateMap<LoginViewModel, LoginUserCommand>()
                .ConstructUsing(c => new LoginUserCommand(c.Cpf, c.Password));

            CreateMap<CategoryViewModel, RegisterCategoryCommand>()
                .ConstructUsing(c => new RegisterCategoryCommand(c.Name));
            CreateMap<CategoryViewModel, UpdateCategoryCommand>()
                .ConstructUsing(c => new UpdateCategoryCommand(c.Id, c.Name));

            CreateMap<ProductRegisterViewModel, RegisterProductCommand>()
                .ConstructUsing(c => new RegisterProductCommand(c.Name, c.Description, c.CategoryId, c.Price));
            CreateMap<ProductUpdateViewModel, UpdateProductCommand>()
                .ConstructUsing(c => new UpdateProductCommand(c.Id,
                    c.Name,c.Description, c.CategoryId, c.Price));

            CreateMap<OrderRegisterViewModel, RegisterOrderCommand>()
                .ForMember(c => c.Items, x => x.MapFrom(d => d.Items))
                .ForMember(c => c.PaymentType, x => x.MapFrom(d => d.PaymentMethod));
            CreateMap<OrderItemRegisterViewModel, RegisterOrderItemCommand>()
                .ConstructUsing(i => new RegisterOrderItemCommand(i.ProductId, i.Qty, i.UnitPrice));
        }
    }
}
