using EatEasy.Domain.Core.Messaging;

namespace EatEasy.Domain.Commands.ProductCommands
{
    public abstract class ProductCommand : Command
    {
        public Guid Id { get; protected set; }
        public string Name { get; protected set; }
        public string Description { get; protected set; }
        public Guid CategoryID { get; protected set; }
        public double Price { get; protected set; }

    }
}
