using EatEasy.Domain.Commands.CategoryCommands.Validations;

namespace EatEasy.Domain.Commands.CategoryCommands
{
    public class RemoveCategoryCommand : CategoryCommand
    {
        public RemoveCategoryCommand(Guid id)
        {
            Id = id;
            AggregateId = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new RemoveCategoryCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
