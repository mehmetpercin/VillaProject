using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using VillaProject.Application.Repositories;
using VillaProject.Domain.Localization;

namespace VillaProject.Persistence.Repositories
{
    public class LanguageResourceRepository : Repository<LanguageResource>, ILanguageResourceRepository
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public LanguageResourceRepository(AppDbContext dbContext, IHttpContextAccessor httpContextAccessor) : base(dbContext)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<string> GetLocalizedItem(string resourceKey)
        {
            ArgumentNullException.ThrowIfNull(resourceKey);

            var language = _httpContextAccessor?.HttpContext?.Features.Get<IRequestCultureFeature>();
            if (language is null)
                return string.Empty;

            var resource = await Table
                                .AsNoTracking()
                                .Include(x => x.Language)
                                .FirstOrDefaultAsync(x => x.Language.Culture == language.RequestCulture.Culture.Name
                                    && x.ResourceKey == resourceKey.Trim().ToLower());

            if (resource is null)
                return string.Empty;

            return resource.ResourceValue;
        }
    }
}
