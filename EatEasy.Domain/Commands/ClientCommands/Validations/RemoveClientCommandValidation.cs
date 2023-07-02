namespace EatEasy.Domain.Commands.ClientCommands.Validations
{
    public class RemoveClientCommandValidation : ClientValidation<RemoveClientCommand>
    {
        public RemoveClientCommandValidation()
        {
            ValidateId();
        }
    }
}
