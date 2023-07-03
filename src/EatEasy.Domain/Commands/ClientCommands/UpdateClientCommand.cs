using EatEasy.Domain.Commands.ClientCommands.Validations;
using System.Xml.Linq;

namespace EatEasy.Domain.Commands.ClientCommands
{
    public class UpdateClientCommand : ClientCommand
    {
        public UpdateClientCommand(Guid id, string name, string cpf, string password, string email, string mobilePhone)
        {
            Id = id;
            Name = name;
            CPF = cpf;
            Password = password;
            Email = email;
            MobilePhone = mobilePhone;
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdateClientCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
