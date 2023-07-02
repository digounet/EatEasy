namespace EatEasy.Domain.Commands.CategoryCommands.Validations
{
    public class RemoveCategoryCommandValidation : CategoryValidation<RemoveCategoryCommand>
    {
        public RemoveCategoryCommandValidation()
        {
            ValidateId();
        }
    }
}
