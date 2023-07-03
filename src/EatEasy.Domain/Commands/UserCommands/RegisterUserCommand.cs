using EatEasy.Domain.Commands.UserCommands.Validations;

namespace EatEasy.Domain.Commands.UserCommands
{
    public class RegisterUserCommand : UserCommand
    {
        public RegisterUserCommand(string role, string name, string cpf, string password, string email, string mobilePhone)
        {
            Name = name;
            CPF = cpf;
            Password = password;
            Email = email;
            MobilePhone = mobilePhone;
            Role = role;
        }

        public override bool IsValid()
        {
            ValidationResult = new RegisterUserCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
