namespace EatEasy.Application.ViewModels
{
    public class OrderItemRegisterViewModel
    {
        public Guid ProductId { get; set; }
        public int Qty { get; set; }
        public double UnitPrice { get; set; }
    }
}
