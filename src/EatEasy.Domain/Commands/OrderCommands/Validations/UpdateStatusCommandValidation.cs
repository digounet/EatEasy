namespace EatEasy.Domain.Commands.OrderCommands.Validations;

public class UpdateStatusCommandValidation : OrderValidation<UpdateOrderStatusCommand>
{
    public UpdateStatusCommandValidation()
    {
        ValidateId();
        ValidateStatus();
    }
}