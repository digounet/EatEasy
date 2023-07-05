using EatEasy.Domain.Enums;
using EatEasy.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EatEasy.Application.ViewModels
{
    public class OrderViewModel
    {
        public Guid Id { get; set; }
        public DateTime OrderDate { get; private set; }
        public double Total { get; private set; }
        public int Sequence { get; private set; }
        public virtual UserViewModel Client { get; set; }
        public OrderStatus OrderStatus { get; private set; }
        public PaymentType PaymentType { get; private set; }

        public virtual IEnumerable<OrderItemViewModel> Items { get; private set; }
    }
}
