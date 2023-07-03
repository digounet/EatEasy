using EatEasy.Domain.Commands.UserCommands.Validations;

namespace EatEasy.Domain.Commands.UserCommands
{
    public class LoginUserCommand : UserCommand
    {
        public LoginUserCommand(string name, string cpf)
        {
            Name = name;
            CPF = cpf;
        }

        public override bool IsValid()
        {
            ValidationResult = new LoginUserCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
