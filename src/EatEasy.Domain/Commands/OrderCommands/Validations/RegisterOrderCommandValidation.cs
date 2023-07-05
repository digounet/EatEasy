using FluentValidation;

namespace EatEasy.Domain.Commands.OrderCommands.Validations;

public class RegisterOrderCommandValidation : OrderValidation<RegisterOrderCommand>
{
    public RegisterOrderCommandValidation()
    {
        ValidateUserID();
        ValidateItems();
        ValidatePaymentType();
    }

    private void ValidateItems()
    {
        RuleFor(c => c.Items)
            .NotEmpty().WithMessage("Por favor, informe os ítens do pedido.");
    }
}