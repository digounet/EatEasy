using EatEasy.Domain.Commands.ProductCommands.Validations;

namespace EatEasy.Domain.Commands.ProductCommands
{
    public class UpdateProductCommand : ProductCommand
    {
        public UpdateProductCommand(Guid id, string name, string description, Guid categoryId, double price)
        {
            Id = id;
            Name = name;
            Description = description;
            CategoryID = categoryId;
            Price = price;
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdateProductCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
