using EatEasy.Domain.Core.Messaging;
using EatEasy.Domain.Enums;

namespace EatEasy.Domain.Events;

public class OrderUpdatedEvent : Event
{
    public Guid OrderId { get; set; }
    public OrderStatus OrderStatus { get; set; }

    public OrderUpdatedEvent(Guid orderId, OrderStatus orderStatus)
    {
        OrderId = orderId;
        OrderStatus = orderStatus;
    }
}