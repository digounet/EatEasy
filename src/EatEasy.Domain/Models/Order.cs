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
        public PaymentType PaymentType { get; private set; }

        public virtual IEnumerable<OrderItem> Items { get; private set; }

        public Order(Guid id, DateTime orderDate, string clientId, double total, int sequence, OrderStatus orderStatus, PaymentType paymentType, IEnumerable<OrderItem> items)
        {
            Id = id;
            OrderDate = orderDate;
            ClientId = clientId;
            Total = total;
            Sequence = sequence;
            OrderStatus = orderStatus;
            Items = items;
            PaymentType = paymentType;
        }

        //Entity framework requires and empty constructor
        public Order() { }
    }
}
