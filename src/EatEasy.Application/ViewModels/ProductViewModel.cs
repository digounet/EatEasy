using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EatEasy.Application.ViewModels
{
    public class ProductViewModel
    {
        [Key]
        [DisplayName("Código")]
        public Guid Id { get; set; }

        [DisplayName("Nome")]
        public string Name { get; set; }

        [DisplayName("Descrição")]
        public string Description { get; set; }

        [DisplayName("Categoria")]
        public CategoryViewModel Category { get; set; }

        [DisplayName("Preço")]
        public double Price { get; set; }
    }
}
