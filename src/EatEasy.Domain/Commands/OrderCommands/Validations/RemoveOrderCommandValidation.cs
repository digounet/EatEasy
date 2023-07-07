namespace EatEasy.Domain.Commands.OrderCommands.Validations
{
    public class RemoveOrderCommandValidation : OrderValidation<RemoveOrderCommand>
    {
        public RemoveOrderCommandValidation()
        {
            ValidateId();
        }
    }
}
