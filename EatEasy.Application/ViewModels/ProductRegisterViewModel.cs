using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EatEasy.Application.ViewModels
{
    public class ProductRegisterViewModel
    {
        [Key]
        [DisplayName("Código")]
        public Guid Id { get; set; }

        [DisplayName("Nome")]
        public string Name { get; set; }

        [DisplayName("Descrição")]
        public string Description { get; set; }

        [DisplayName("Código da Categoria")]
        public Guid Category { get; set; }

        [DisplayName("Preço")]
        public double Price { get; set; }
    }
}
