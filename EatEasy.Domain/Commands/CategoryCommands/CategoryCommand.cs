using EatEasy.Domain.Core.Messaging;

namespace EatEasy.Domain.Commands.CategoryCommands
{
    public abstract class CategoryCommand : Command
    {
        public Guid Id { get; protected set; }

        public string Name { get; protected set; }
    }
}
