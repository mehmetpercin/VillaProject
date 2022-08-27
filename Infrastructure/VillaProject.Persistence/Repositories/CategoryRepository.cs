using VillaProject.Application.Repositories;
using VillaProject.Domain.Entities;

namespace VillaProject.Persistence.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext context) : base(context)
        {

        }
    }
}
