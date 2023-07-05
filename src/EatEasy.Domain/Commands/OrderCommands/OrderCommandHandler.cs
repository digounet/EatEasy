using EatEasy.Domain.Core.Messaging;
using EatEasy.Domain.Enums;
using EatEasy.Domain.Interfaces;
using EatEasy.Domain.Models;
using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace EatEasy.Domain.Commands.OrderCommands;

public class OrderCommandHandler : CommandHandler,
    IRequestHandler<RegisterOrderCommand, ValidationResult>,
    IRequestHandler<UpdateOrderStatusCommand, ValidationResult>
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

        await ValidateRegisterRequest(request, cancellationToken);

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

        return await Commit(_orderRepository.UnitOfWork);
    }

    private async Task ValidateRegisterRequest(RegisterOrderCommand request, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByIdAsync(request.ClientId.ToString());
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
        return await Commit(_orderRepository.UnitOfWork);
    }
}