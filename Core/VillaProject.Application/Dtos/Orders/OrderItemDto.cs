namespace VillaProject.Application.Dtos.Orders
{
    public class OrderItemDto
    {
        public int Id { get; set; }
        public string ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
