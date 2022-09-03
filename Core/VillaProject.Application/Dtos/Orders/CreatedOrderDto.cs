namespace VillaProject.Application.Dtos.Orders
{
    public class CreatedOrderDto
    {
        public int OrderId { get; set; }
        public int VillaId { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
