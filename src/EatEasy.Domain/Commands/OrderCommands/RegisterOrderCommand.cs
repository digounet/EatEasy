using EatEasy.Domain.Commands.OrderCommands.Validations;
using EatEasy.Domain.Commands.ProductCommands.Validations;
using EatEasy.Domain.Enums;
using EatEasy.Domain.Models;

namespace EatEasy.Domain.Commands.OrderCommands
{
    public class RegisterOrderCommand : OrderCommand
    {
        public RegisterOrderCommand(DateTime orderDate, Guid clientId, double total, IEnumerable<OrderItem> items, int sequence, OrderStatus orderStatus)
        {
            OrderDate = orderDate;
            ClientId = clientId;
            Total = total;
            Items = items;
            Sequence = sequence;
            OrderStatus = orderStatus;
        }

        public override bool IsValid()
        {
            ValidationResult = new RegisterOrderCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
