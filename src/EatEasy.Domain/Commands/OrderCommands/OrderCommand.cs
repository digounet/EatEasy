using EatEasy.Domain.Core.Messaging;
using EatEasy.Domain.Enums;

namespace EatEasy.Domain.Commands.OrderCommands;

public abstract class OrderCommand : Command
{
    public Guid Id { get; protected set; }
    public Guid ClientId { get; protected set; }
    public OrderStatus OrderStatus { get; protected set; }
    public PaymentType PaymentType { get; protected set; }
}