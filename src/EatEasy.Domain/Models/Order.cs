using EatEasy.Domain.Core.Domain;
using EatEasy.Domain.Enums;

namespace EatEasy.Domain.Models
{
    public class Order : Entity, IAggregateRoot
    {
        public DateTime OrderDate { get; private set; }
        public string ClientId { get; private set; }
        public double Total { get; private set; }
        public int Sequence { get; private set; }

        public virtual User Client { get; set; }

        public OrderStatus OrderStatus { get; private set; }

        public IEnumerable<OrderItem> Items { get; private set; }

        protected Order(DateTime orderDate, string clientId, double total, IEnumerable<OrderItem> items, int sequence, OrderStatus orderStatus)
        {
            OrderDate = orderDate;
            ClientId = clientId;
            Total = total;
            Items = items;
            Sequence = sequence;
            OrderStatus = orderStatus;
        }

        //Entity framework requires and empty constructor
        public Order() { }
    }
}
