namespace EatEasy.Domain.Commands.UserCommands.Validations
{
    public class LoginUserCommandValidation : UserValidation<LoginUserCommand>
    {
        public LoginUserCommandValidation()
        {
            ValidateCpf();
            ValidatePassword();
        }
    }
}
