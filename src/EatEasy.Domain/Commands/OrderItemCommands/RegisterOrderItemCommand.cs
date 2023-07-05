using EatEasy.Domain.Commands.OrderItemCommands.Validations;

namespace EatEasy.Domain.Commands.OrderItemCommands;

public class RegisterOrderItemCommand : OrderItemCommand
{
    public RegisterOrderItemCommand(Guid productId, int qty, double unitPrice)
    {
        ProductId = productId;
        Qty = qty;
        UnitPrice = unitPrice;
    }

    public override bool IsValid()
    {
        ValidationResult = new RegisterOrderItemCommandValidation().Validate(this);
        return ValidationResult.IsValid;
    }
}