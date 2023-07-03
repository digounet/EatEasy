namespace EatEasy.Domain.Commands.ProductCommands.Validations
{
    public class RegisterProductCommandValidation : ProductValidation<RegisterProductCommand>
    {
        public RegisterProductCommandValidation()
        {
            ValidateName();
            ValidateDescription();
            ValidateCategoryID();
            ValidatePrice();
        }
    }
}
