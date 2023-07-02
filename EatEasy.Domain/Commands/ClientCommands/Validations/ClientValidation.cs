using FluentValidation;

namespace EatEasy.Domain.Commands.ClientCommands.Validations
{
    public abstract class ClientValidation<T> : AbstractValidator<T> where T : ClientCommand
    {
        protected void ValidateId()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty);
        }

        protected void ValidateName()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Por favor, informe o nome do cliente")
                .Length(3, 150).WithMessage("A nome precisa ter entre 3 and 150 caracteres");
        }

        protected void ValidateCpf()
        {
            RuleFor(c => c.CPF)
                .NotEmpty().WithMessage("Por favor, informe o CPF do cliente.")
                .Length(11).WithMessage("O CPF precisa ter 11 caracteres");
        }

        protected void ValidatePassword()
        {
            RuleFor(c => c.Password)
                .NotEmpty().WithMessage("Por favor, informe a senha do cliente.")
                .Length(6, 36).WithMessage("A senha precisa ter entre 6 e 36 caracteres");
        }

        protected void ValidateEmail()
        {
            RuleFor(c => c.Email)
                .NotEmpty().WithMessage("Por favor, informe o e-mail do cliente.")
                .Length(10, 150).WithMessage("O e-mail precisa ter entre 10 e 150 caracteres")
                .EmailAddress();
        }

        protected void ValidateMobilePhone()
        {
            RuleFor(c => c.MobilePhone)
                .NotEmpty().WithMessage("Por favor, informe o celular de contato do cliente.")
                .Length(11).WithMessage("A celular precisa ser informado com o DDD (ex: 11 912345432");
        }
    }
}
