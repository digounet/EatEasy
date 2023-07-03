using System.ComponentModel;

namespace EatEasy.Application.ViewModels
{
    public class LoginViewModel
    {
        [DisplayName("CPF")]
        public string Cpf { get; set; }

        [DisplayName("Senha")]
        public string Password { get; set; }
    }
}
