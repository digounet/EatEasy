using EatEasy.Domain.Core.Domain;

namespace EatEasy.Domain.Models
{
    public class Product : Entity, IAggregateRoot
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public Guid CategoryID { get; private set; }
        public virtual Category Category { get; set; }
        public double Price { get; private set; }

        public virtual IEnumerable<OrderItem> OrderItems { get; set; }

        public Product(Guid id, string name, string description, Guid categoryId, double price)
        {
            Id = id;
            Name = name;
            Description = description;
            CategoryID = categoryId;
            Price = price;
        }

        //Entity framework requires and empty constructor
        public Product()
        {

        }
    }
}
