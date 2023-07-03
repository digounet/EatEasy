namespace EatEasy.Domain.Commands.UserCommands.Validations
{
    public class RegisterUserCommandValidation : UserValidation<RegisterUserCommand>
    {
        public RegisterUserCommandValidation()
        {
            ValidateName();
            ValidateCpf();
            ValidateEmail();
            ValidatePassword();
            ValidateMobilePhone();
            ValidateRole();
        }
    }
}
