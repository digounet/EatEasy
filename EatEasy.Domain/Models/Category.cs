using EatEasy.Domain.Core.Domain;

namespace EatEasy.Domain.Models
{
    public class Category : Entity, IAggregateRoot
    {
        public string Name { get; private set; }

        public virtual IEnumerable<Product> Products { get; set; }

        public Category(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        //Entity framework requires and empty constructor
        public Category()
        {

        }
    }
}