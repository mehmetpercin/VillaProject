using VillaProject.Domain.Common;

namespace VillaProject.Domain.Entities
{
    public class Category : DbObject
    {
        public string Name { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
