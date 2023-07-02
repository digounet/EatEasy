using EatEasy.Domain.Core.Domain;

namespace EatEasy.Domain.Models
{
    public class Client : Entity, IAggregateRoot
    {
        public string Name { get; private set; }
        public string CPF { get; private set; }
        public string Password { get; private set; }
        public string Email { get; private set; }
        public string MobilePhone { get; private set; }

        public virtual IEnumerable<Order> Orders { get; set; }

        public Client(Guid id, string name, string cpf, string password, string email, string mobilePhone)
        {
            Id = id;
            Name = name;    
            CPF = cpf;
            Password = password;
            Email = email;
            MobilePhone = mobilePhone;
        }

        //Entity framework requires and empty constructor
        protected Client()
        {
        }
    }
}
