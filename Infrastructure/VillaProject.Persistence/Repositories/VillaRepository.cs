using VillaProject.Application.Repositories;
using VillaProject.Domain.Entities;

namespace VillaProject.Persistence.Repositories
{
    public class VillaRepository : Repository<Villa>, IVillaRepository
    {
        public VillaRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
