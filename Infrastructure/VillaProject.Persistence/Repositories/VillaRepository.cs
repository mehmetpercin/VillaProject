using VillaProject.Application.Repositories;
using VillaProject.Domain;

namespace VillaProject.Persistence.Repositories
{
    public class VillaRepository : Repository<Villa>, IVillaRepository
    {
        private readonly AppDbContext _dbContext;

        public VillaRepository(AppDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
