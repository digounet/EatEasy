using EatEasy.Domain.Core.Messaging;
using EatEasy.Domain.Models;

namespace EatEasy.Domain.Events
{
    public class OrderRegisteredEvent : Event
    {
        public Guid OrderId { get; set; }
        public string ClientName { get; set; }
        public int Sequence { get; private set; }
        public IEnumerable<OrderItem> Items { get; private set; }

        public OrderRegisteredEvent(Guid orderId, string clientName, int sequence, IEnumerable<OrderItem> items)
        {
            OrderId = orderId;
            ClientName = clientName;    
            Sequence = sequence;
            Items = items;
        }
    }
}
