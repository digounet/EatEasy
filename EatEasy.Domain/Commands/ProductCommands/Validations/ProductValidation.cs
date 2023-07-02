using FluentValidation;

namespace EatEasy.Domain.Commands.ProductCommands.Validations
{
    public abstract class ProductValidation<T> : AbstractValidator<T> where T : ProductCommand
    {
        protected void ValidateId()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty);
        }

        protected void ValidateName()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Por favor, informe o nome do produto")
                .Length(3, 150).WithMessage("O nome precisa ter entre 3 and 150 caracteres");
        }

        protected void ValidateDescription()
        {
            RuleFor(c => c.Description)
                .NotEmpty().WithMessage("Por favor, informe a descrição do produto.")
                .Length(3, 400).WithMessage("A descrição precisa ter entre 3 and 400 caracteres");
        }

        protected void ValidateCategoryID()
        {
            RuleFor(c => c.CategoryID)
                .NotEqual(Guid.Empty).WithMessage("Por favor, informe a categoria do produto.");
        }

        protected void ValidatePrice()
        {
            RuleFor(c => c.Price)
                .NotEmpty().WithMessage("Por favor, informe o preço do produto.")
                .GreaterThan(0).WithMessage("O preço do produto deve ser maior que zero.");
        }
    }
}
