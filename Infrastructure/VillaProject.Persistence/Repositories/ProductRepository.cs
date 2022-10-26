using Microsoft.EntityFrameworkCore;
using VillaProject.Application.Repositories;
using VillaProject.Domain.Entities;

namespace VillaProject.Persistence.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }

        public async Task<List<Product>> GetAllByCategoryId(int categoryId, CancellationToken cancellationToken = default)
        {
            return await Table.Where(x => x.CategoryId == categoryId).ToListAsync(cancellationToken);
        }
    }
}
