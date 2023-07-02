using FluentValidation;

namespace EatEasy.Domain.Commands.CategoryCommands.Validations
{
    public abstract class CategoryValidation<T> : AbstractValidator<T> where T : CategoryCommand
    {
        protected void ValidateId()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty);
        }

        protected void ValidateName()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Por favor, informe o nome da categoria")
                .Length(3, 30).WithMessage("A categoria precisa ter entre 3 and 30 caracteres");
        }
    }
}
