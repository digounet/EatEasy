using EatEasy.Domain.Core.Messaging;
using EatEasy.Domain.Enums;
using EatEasy.Domain.Events;
using EatEasy.Domain.Interfaces;
using EatEasy.Domain.Models;
using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace EatEasy.Domain.Commands.OrderCommands;

public class OrderCommandHandler : CommandHandler,
    IRequestHandler<RegisterOrderCommand, ValidationResult>,
    IRequestHandler<UpdateOrderStatusCommand, ValidationResult>,
    IRequestHandler<RemoveOrderCommand, ValidationResult>
{
    private readonly IOrderRepository _orderRepository;
    private readonly IProductRepository _productRepository;
    private readonly UserManager<User> _userManager;

    public OrderCommandHandler(IOrderRepository orderRepository, IProductRepository productRepository, UserManager<User> userManager)
    {
        _orderRepository = orderRepository;
        _productRepository = productRepository;
        _userManager = userManager;
    }

    public async Task<ValidationResult> Handle(RegisterOrderCommand request, CancellationToken cancellationToken)
    {
        if (!request.IsValid()) return request.ValidationResult;

        var user = await _userManager.FindByIdAsync(request.ClientId.ToString());

        await ValidateRegisterRequest(request, user, cancellationToken);

        if (!ValidationResult.IsValid) return ValidationResult;

        var orderDate = DateTime.UtcNow;

        var total = request.Items.Sum(x => x.Total);

        var sequence = await _orderRepository.GetNextSequenceByDateAsync(orderDate, cancellationToken);

        var orderId = Guid.NewGuid();


        var items = request.Items.Select(orderItemCommand =>
            new OrderItem(Guid.NewGuid(),
                orderId,
                orderItemCommand.ProductId,
                orderItemCommand.Qty,
                orderItemCommand.UnitPrice)).ToList();

        var order = new Order(Guid.NewGuid(),
            orderDate,
            request.ClientId.ToString(),
            total,
            sequence,
            OrderStatus.Received,
            request.PaymentType,
            items);

        _orderRepository.AddAsync(order, cancellationToken);

        order.AddDomainEvent(new OrderRegisteredEvent(order.Id, user.Name, order.Sequence, order.Items));

        return await Commit(_orderRepository.UnitOfWork);
  
    }

    private async Task ValidateRegisterRequest(RegisterOrderCommand request, User? user,
        CancellationToken cancellationToken)
    {
        if (user == null)
        {
            AddError($"O cliente {request.ClientId} não possui cadastro.");
        }

        foreach (var orderItemCommand in request.Items)
        {
            if (!orderItemCommand.IsValid())
            {
                AddErrors(orderItemCommand.ValidationResult.Errors);
            }
            else
            {
                var product = await _productRepository.GetByIdAsync(orderItemCommand.ProductId, cancellationToken);

                if (product == null)
                {
                    AddError($"Produto inexistente: {orderItemCommand.ProductId}");
                }
            }
        }
    }

    public async Task<ValidationResult> Handle(UpdateOrderStatusCommand request, CancellationToken cancellationToken)
    {
        if (!request.IsValid()) return request.ValidationResult;

        var existing = await _orderRepository.GetByIdAsync(request.Id, cancellationToken);

        if (existing == null)
        {
            AddError($"O pedido {request.Id} não existe.");
        }

        var order = new Order(existing.Id, existing.OrderDate, existing.ClientId, existing.Total, existing.Sequence,
            request.OrderStatus, existing.PaymentType, existing.Items);

        _orderRepository.Update(order);

        order.AddDomainEvent(new OrderUpdatedEvent(order.Id, order.OrderStatus));

        return await Commit(_orderRepository.UnitOfWork);
    }

    public async Task<ValidationResult> Handle(RemoveOrderCommand request, CancellationToken cancellationToken)
    {
        if (!request.IsValid()) return request.ValidationResult;

        var order = await _orderRepository.GetByIdAsync(request.Id, cancellationToken);

        if (order is null)
        {
            AddError("Pedido não encontrado");
            return ValidationResult;
        }

        _orderRepository.Remove(order);

        return await Commit(_orderRepository.UnitOfWork);
    }
}