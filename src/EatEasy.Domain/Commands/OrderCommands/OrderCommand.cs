using EatEasy.Domain.Core.Messaging;
using EatEasy.Domain.Enums;
using EatEasy.Domain.Models;

namespace EatEasy.Domain.Commands.OrderCommands;

public class OrderCommand : Command
{
    public Guid Id { get; protected set; }
    public DateTime OrderDate { get; protected set; }
    public double Total { get; protected set; }
    public int Sequence { get; protected set; }
    public Guid ClientId { get; protected set; }
    public OrderStatus OrderStatus { get; protected set; }
    public IEnumerable<OrderItem> Items { get; protected set; }
}