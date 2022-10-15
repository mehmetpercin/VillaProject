using VillaProject.Application.Repositories;
using VillaProject.Domain.Localization;

namespace VillaProject.Persistence.Repositories
{
    public class LanguageRepository : Repository<Language>, ILanguageRepository
    {
        public LanguageRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
