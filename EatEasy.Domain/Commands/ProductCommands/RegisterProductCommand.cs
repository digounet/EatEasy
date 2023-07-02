using EatEasy.Domain.Commands.ProductCommands.Validations;

namespace EatEasy.Domain.Commands.ProductCommands
{
    public class RegisterProductCommand : ProductCommand
    {
        public RegisterProductCommand(string name, string description, Guid categoryId, double price)
        {
            Name = name;
            Description = description;
            CategoryID = categoryId;
            Price = price;
        }

        public override bool IsValid()
        {
            ValidationResult = new RegisterProductCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
