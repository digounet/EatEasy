using EatEasy.Domain.Core.Messaging;

namespace EatEasy.Domain.Commands.OrderItemCommands;

public abstract class OrderItemCommand : Command
{
    public Guid Id { get; protected set; }
    public Guid ProductId { get; protected set; }
    public int Qty { get; protected set; }
    public double UnitPrice { get; protected set; }
    public double Total => UnitPrice * Qty;
}