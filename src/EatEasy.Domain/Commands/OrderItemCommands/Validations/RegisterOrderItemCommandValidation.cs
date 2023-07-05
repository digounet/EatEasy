namespace EatEasy.Domain.Commands.OrderItemCommands.Validations
{
    public class RegisterOrderItemCommandValidation : OrderItemValidation<RegisterOrderItemCommand>
    {
        public RegisterOrderItemCommandValidation()
        {
            ValidateProductID();
            ValidatePrice();
            ValidateQty();
        }
    }
}
