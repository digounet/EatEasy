using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EatEasy.Application.ViewModels
{
    public class RegisterClientViewModel
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

        [DisplayName("Senha")]
        public string Password { get; set; }

    }
}
