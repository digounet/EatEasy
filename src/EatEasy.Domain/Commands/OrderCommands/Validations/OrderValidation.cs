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

    protected void ValidateItems()
    {
        RuleFor(c => c.Items)
            .NotEmpty().WithMessage("Por favor, informe os ítens do pedido.");
    }
}