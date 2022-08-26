using VillaProject.Domain.Common;
using VillaProject.Domain.Enums;

namespace VillaProject.Domain.Entities
{
    public class Order : DbObject
    {
        public Guid VillaId { get; set; }
        public Villa Villa { get; set; }
        public OrderStatusEnum StatusId { get; set; }
        public OrderStatus Status { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
