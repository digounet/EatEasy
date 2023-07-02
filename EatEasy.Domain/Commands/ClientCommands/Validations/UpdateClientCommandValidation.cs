namespace EatEasy.Domain.Commands.ClientCommands.Validations
{
    public class UpdateClientCommandValidation : ClientValidation<UpdateClientCommand>
    {
        public UpdateClientCommandValidation()
        {
            ValidateId();
            ValidateName();
            ValidateCpf();
            ValidateEmail();
            ValidatePassword();
            ValidateMobilePhone();
        }
    }
}
