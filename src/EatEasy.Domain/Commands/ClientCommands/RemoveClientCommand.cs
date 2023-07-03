using EatEasy.Domain.Commands.ClientCommands.Validations;

namespace EatEasy.Domain.Commands.ClientCommands
{
    public class RemoveClientCommand : ClientCommand
    {
        public RemoveClientCommand(Guid id)
        {
            Id = id;
            AggregateId = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new RemoveClientCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
