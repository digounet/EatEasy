namespace EatEasy.Application.ViewModels
{
    public class OrderItemViewModel
    {
        public ProductViewModel Product { get; set; }
        public int Qty { get; set; }
        public double UnitPrice { get; set; }
        public double Total { get; set; }
    }
}
