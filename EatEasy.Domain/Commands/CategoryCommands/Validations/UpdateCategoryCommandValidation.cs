namespace EatEasy.Domain.Commands.CategoryCommands.Validations
{
    public class UpdateCategoryCommandValidation : CategoryValidation<UpdateCategoryCommand>
    {
        public UpdateCategoryCommandValidation()
        {
            ValidateId();
            ValidateName();
        }
    }
}
