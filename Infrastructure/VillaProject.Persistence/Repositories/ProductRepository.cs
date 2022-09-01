using Microsoft.EntityFrameworkCore;
using VillaProject.Application.Repositories;
using VillaProject.Domain.Entities;

namespace VillaProject.Persistence.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly AppDbContext _appDbContext;

        public ProductRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<List<Product>> GetAllByCategoryId(Guid categoryId, CancellationToken cancellationToken = default)
        {
            return await _appDbContext.Products.Where(x => x.CategoryId == categoryId).ToListAsync(cancellationToken);
        }
    }
}
