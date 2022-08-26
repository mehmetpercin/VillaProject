using VillaProject.Domain.Enums;

namespace VillaProject.Domain.Entities
{
    public class OrderStatus
    {
        public OrderStatusEnum Id { get; set; }
        public string Status { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
