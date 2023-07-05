using EatEasy.Domain.Core.Domain;

namespace EatEasy.Domain.Models
{
    public class OrderItem : Entity, IAggregateRoot
    {
        public Guid OrderId { get; set; }
        public Guid ProductId { get; private set; }
        public virtual Product Product { get; set; }
        public virtual Order Order { get; set; }
        public int Qty { get; private set; }
        public double UnitPrice { get; private set; }
        public double Total => UnitPrice * Qty;

        protected OrderItem(Guid id, Guid orderId, Guid productId, int qty, double unitPrice)
        {
            OrderId = orderId;
            ProductId = productId;
            Qty = qty;
            UnitPrice = unitPrice;
            Id = id;
        }

        //Entity framework requires and empty constructor
        public OrderItem() { }  
    }
}
