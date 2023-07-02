namespace EatEasy.Domain.Commands.CategoryCommands.Validations
{
    public class RegisterCategoryCommandValidation : CategoryValidation<RegisterCategoryCommand>
    {
        public RegisterCategoryCommandValidation()
        {
            ValidateName();
        }
    }
}
