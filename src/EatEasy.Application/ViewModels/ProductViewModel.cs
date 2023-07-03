using System.ComponentModel;

namespace EatEasy.Application.ViewModels
{
    public class ProductViewModel
    {
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
