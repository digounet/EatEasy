using EatEasy.Domain.Commands.OrderCommands.Validations;
using EatEasy.Domain.Enums;

namespace EatEasy.Domain.Commands.OrderCommands;

public class UpdateOrderStatusCommand : OrderCommand
{
    public UpdateOrderStatusCommand(Guid orderId, OrderStatus newStatus)
    {
        Id = orderId;
        OrderStatus = newStatus;
    }

    public override bool IsValid()
    {
        ValidationResult = new UpdateStatusCommandValidation().Validate(this);
        return ValidationResult.IsValid;
    }
}