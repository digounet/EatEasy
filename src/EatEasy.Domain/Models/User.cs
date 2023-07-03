using EatEasy.Domain.Core.Domain;
using Microsoft.AspNetCore.Identity;

namespace EatEasy.Domain.Models
{
    public class User : IdentityUser, IAggregateRoot
    {
        public string Name { get; set; }
        public string CPF { get; set; }

        public virtual IEnumerable<Order> Orders { get; set; }
    }
}
