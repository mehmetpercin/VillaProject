using VillaProject.Domain.Common;

namespace VillaProject.Domain.Entities
{
    public class OrderItem : DbObject
    {
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public bool IsCancelled { get; set; }       
    }
}
