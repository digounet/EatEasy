namespace EatEasy.Domain.Commands.ProductCommands.Validations
{
    public class UpdateProductCommandValidation : ProductValidation<UpdateProductCommand>
    {
        public UpdateProductCommandValidation()
        {
            ValidateId();
            ValidateName();
            ValidateDescription();
            ValidateCategoryID();
            ValidatePrice();
        }
    }
}
