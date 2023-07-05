using FluentValidation;

namespace EatEasy.Domain.Commands.OrderCommands.Validations;

public abstract class OrderValidation<T> : AbstractValidator<T> where T : OrderCommand
{
    protected void ValidateId()
    {
        RuleFor(c => c.Id)
            .NotEqual(Guid.Empty);
    }

    protected void ValidateUserID()
    {
        RuleFor(c => c.ClientId)
            .NotEqual(Guid.Empty).WithMessage("Por favor, informe o cliente do pedido.");
    }

    protected void ValidateStatus()
    {
        RuleFor(c => c.OrderStatus)
            .NotEmpty().WithMessage("Por favor, informe o status do pedido.");
    }

    protected void ValidatePaymentType()
    {
        RuleFor(c => c.PaymentType)
            .NotEmpty().WithMessage("Por favor, informe a forma de pagamento do pedido.");
    }
}