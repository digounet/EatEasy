namespace EatEasy.Domain.Commands.OrderCommands.Validations;

public class RegisterOrderCommandValidation : OrderValidation<RegisterOrderCommand>
{
    public RegisterOrderCommandValidation()
    {
        ValidateUserID();
        ValidateItems();
    }
}