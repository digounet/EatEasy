using EatEasy.Domain.Commands.OrderCommands.Validations;
using EatEasy.Domain.Commands.OrderItemCommands;

namespace EatEasy.Domain.Commands.OrderCommands
{
    public class RegisterOrderCommand : OrderCommand
    {
        public IEnumerable<RegisterOrderItemCommand> Items { get; protected set; }

        public RegisterOrderCommand(Guid clientId, IEnumerable<RegisterOrderItemCommand> items)
        {
            ClientId = clientId;
            Items = items;
        }

        public override bool IsValid()
        {
            ValidationResult = new RegisterOrderCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
