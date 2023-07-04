using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EatEasy.Application.ViewModels
{
    public class ProductUpdateViewModel : ProductRegisterViewModel
    {
        [Key]
        [DisplayName("Código")]
        public Guid Id { get; set; }
    }
}
