using EatEasy.Domain.Commands.CategoryCommands.Validations;

namespace EatEasy.Domain.Commands.CategoryCommands
{
    public class RegisterCategoryCommand : CategoryCommand
    {
        public RegisterCategoryCommand(string name)
        {
            Name = name;
        }

        public override bool IsValid()
        {
            ValidationResult = new RegisterCategoryCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
