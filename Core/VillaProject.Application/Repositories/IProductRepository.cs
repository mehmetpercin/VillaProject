using VillaProject.Domain.Entities;

namespace VillaProject.Application.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<List<Product>> GetAllByCategoryId(int categoryId, CancellationToken cancellationToken = default);
    }
}
