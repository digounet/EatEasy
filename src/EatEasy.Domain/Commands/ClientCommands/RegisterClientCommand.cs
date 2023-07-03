using EatEasy.Domain.Commands.ClientCommands.Validations;

namespace EatEasy.Domain.Commands.ClientCommands
{
    public class RegisterClientCommand : ClientCommand
    {
        public RegisterClientCommand(string name, string cpf, string password, string email, string mobilePhone)
        {
            Name = name;
            CPF = cpf;
            Password = password;
            Email = email;
            MobilePhone = mobilePhone;
        }

        public override bool IsValid()
        {
            ValidationResult = new RegisterClientCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
