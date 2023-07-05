using EatEasy.Domain.Enums;
using System.ComponentModel;

namespace EatEasy.Application.ViewModels
{
    public class OrderRegisterViewModel
    {
        public Guid ClientId { get; set; }

        [DisplayName("Forma de pagamento")]
        public PaymentType PaymentMethod { get; set; }

        public IEnumerable<OrderItemRegisterViewModel> Items { get; set; }
    }
}
