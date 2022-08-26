using VillaProject.Domain.Common;

namespace VillaProject.Domain.Entities
{
    public class Villa : DbObject
    {
        public string Name { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
