using EatEasy.Domain.Core.Messaging;

namespace EatEasy.Domain.Commands.UserCommands
{
    public abstract class UserCommand : Command
    {
        public Guid Id { get; protected set; }
        public string Name { get; protected set; }
        public string CPF { get; protected set; }
        public string Password { get; protected set; }
        public string Email { get; protected set; }
        public string MobilePhone { get; protected set; }
        public string Role { get; protected set; }
    }
}
