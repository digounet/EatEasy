namespace EatEasy.Domain.Commands.ClientCommands.Validations
{
    public class RegisterClientCommandValidation : ClientValidation<RegisterClientCommand>
    {
        public RegisterClientCommandValidation()
        {
            ValidateName();
            ValidateCpf();
            ValidateEmail();
            ValidatePassword();
            ValidateMobilePhone();
        }
    }
}
