﻿using EatEasy.Application.Interface;
using EatEasy.Application.Services;
using EatEasy.CrossCutting.Bus;
using EatEasy.Domain.Commands.CategoryCommands;
using EatEasy.Domain.Commands.OrderCommands;
using EatEasy.Domain.Commands.ProductCommands;
using EatEasy.Domain.Commands.UserCommands;
using EatEasy.Domain.Core.Mediator;
using EatEasy.Domain.Events;
using EatEasy.Domain.Interfaces;
using EatEasy.Infra.Data.Context;
using EatEasy.Infra.Data.Repository;
using FluentValidation.Results;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace EatEasy.CrossCutting.IoC
{
    public static class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Domain Bus (Mediator)
            services.AddScoped<IMediatorHandler, InMemoryBus>();

            // Application
            services.AddScoped<IUserAppService, UserAppService>();
            services.AddScoped<ICategoryAppService, CategoryAppService>();
            services.AddScoped<IProductAppService, ProductAppService>();
            services.AddScoped<IOrderAppService, OrderAppService>();
            services.AddScoped<ITokenService, TokenService>();

            // Domain - Events
            services.AddScoped<INotificationHandler<OrderRegisteredEvent>, OrderEventHandler>();

            // Domain - Commands
            services.AddScoped<IRequestHandler<RegisterCategoryCommand, ValidationResult>, CategoryCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateCategoryCommand, ValidationResult>, CategoryCommandHandler>();
            services.AddScoped<IRequestHandler<RemoveCategoryCommand, ValidationResult>, CategoryCommandHandler>();

            services.AddScoped<IRequestHandler<RegisterUserCommand, ValidationResult>, UserCommandHandler>();
            services.AddScoped<IRequestHandler<LoginUserCommand, ValidationResult>, UserCommandHandler>();

            services.AddScoped<IRequestHandler<RegisterProductCommand, ValidationResult>, ProductCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateProductCommand, ValidationResult>, ProductCommandHandler>();
            services.AddScoped<IRequestHandler<RemoveProductCommand, ValidationResult>, ProductCommandHandler>();
            
            services.AddScoped<IRequestHandler<RegisterOrderCommand, ValidationResult>, OrderCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateOrderStatusCommand, ValidationResult>, OrderCommandHandler>();
            services.AddScoped<IRequestHandler<RemoveOrderCommand, ValidationResult>, OrderCommandHandler>();

            // Infra - Data
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IOrderItemRepository, OrderItemRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<EatEasyContext>();
        }
    }
}