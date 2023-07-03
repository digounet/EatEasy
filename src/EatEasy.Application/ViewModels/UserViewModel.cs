using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EatEasy.Application.ViewModels
{
    public class UserViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [DisplayName("Nome")]
        public string Name { get; set; }

        [DisplayName("CPF")]
        public string Cpf { get; set; }

        [DisplayName("E-mail")]
        public string Email { get; set; }

        [DisplayName("Celular")]
        public string MobilePhone { get; set; }

    }
}
