namespace VillaProject.Application.Dtos.Orders
{
    public class OrderItemCreateDto
    {
        public string ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
