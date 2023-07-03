using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace EatEasy.Application.ViewModels
{
    public class CategoryViewModel
    {
        [Key]
        [DisplayName("Código")]
        public Guid Id { get; set; }

        [DisplayName("Nome")]
        public string Name { get; set; }
    }
}
