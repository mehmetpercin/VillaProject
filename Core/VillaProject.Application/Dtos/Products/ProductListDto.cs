namespace VillaProject.Application.Dtos.Products
{
    public class ProductListDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public Guid CategoryId { get; set; }
        public bool IsActive { get; set; }
    }
}
