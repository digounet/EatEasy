using EatEasy.Domain.Core.Messaging;
using EatEasy.Domain.Models;

namespace EatEasy.Domain.Events
{
    public class OrderRegisteredEvent : Event
    {
        public Guid OrderId { get; set; }
        public int Sequence { get; private set; }
        public IEnumerable<OrderItem> Items { get; private set; }

        public OrderRegisteredEvent(Guid orderId, int sequence, IEnumerable<OrderItem> items)
        {
            OrderId = orderId;
            Sequence = sequence;
            Items = items;
        }
    }
}
