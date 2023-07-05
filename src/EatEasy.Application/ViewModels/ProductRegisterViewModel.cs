using System.ComponentModel;

namespace EatEasy.Application.ViewModels
{
    public class ProductRegisterViewModel
    {
        [DisplayName("Nome")]
        public string Name { get; set; }

        [DisplayName("Descrição")]
        public string Description { get; set; }

        [DisplayName("Código da Categoria")]
        public Guid CategoryId { get; set; }

        [DisplayName("Preço")]
        public double Price { get; set; }
    }
}
