using EatEasy.Domain.Commands.ProductCommands;
using EatEasy.Domain.Core.Messaging;
using EatEasy.Domain.Enums;
using EatEasy.Domain.Interfaces;
using EatEasy.Domain.Models;
using FluentValidation.Results;
using MediatR;

namespace EatEasy.Domain.Commands.OrderCommands;

public class OrderCommandHandler : CommandHandler,
    IRequestHandler<RegisterOrderCommand, ValidationResult>
{
    private readonly IOrderRepository _orderRepository;

    public OrderCommandHandler(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<ValidationResult> Handle(RegisterOrderCommand request, CancellationToken cancellationToken)
    {
        if (!request.IsValid()) return request.ValidationResult;

        var orderDate = DateTime.UtcNow;

        var total = request.Items.Sum(x => x.Total);

        var sequence = await _orderRepository.GetNextSequenceByDateAsync(orderDate, cancellationToken);

        var order = new Order(Guid.NewGuid(),
            orderDate,
            request.ClientId.ToString(),
            total,
            request.Items,
            sequence,
            OrderStatus.New);

        _orderRepository.AddAsync(order, cancellationToken);

        return await Commit(_orderRepository.UnitOfWork);
    }
}