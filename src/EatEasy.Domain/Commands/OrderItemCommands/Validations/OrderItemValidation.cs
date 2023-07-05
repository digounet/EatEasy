using FluentValidation;

namespace EatEasy.Domain.Commands.OrderItemCommands.Validations
{
    public abstract class OrderItemValidation<T> : AbstractValidator<T> where T : OrderItemCommand
    {
        protected void ValidateId()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty);
        }

        protected void ValidateProductID()
        {
            RuleFor(c => c.ProductId)
                .NotEqual(Guid.Empty).WithMessage("Por favor, informe o produto do ítem.");
        }

        protected void ValidateQty()
        {
            RuleFor(c => c.Qty)
                .GreaterThan(0).WithMessage("Por favor, informe a quantidade do ítem.");
        }

        protected void ValidatePrice()
        {
            RuleFor(c => c.UnitPrice)
                .GreaterThan(0).WithMessage("Por favor, informe o preço do ítem.");
        }
    }
}
