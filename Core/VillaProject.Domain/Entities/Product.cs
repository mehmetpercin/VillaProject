using VillaProject.Domain.Common;

namespace VillaProject.Domain.Entities
{
    public class Product : DbObject
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
        public bool IsActive { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
