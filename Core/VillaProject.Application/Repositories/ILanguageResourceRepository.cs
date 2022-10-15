using VillaProject.Domain.Localization;

namespace VillaProject.Application.Repositories
{
    public interface ILanguageResourceRepository : IRepository<LanguageResource>
    {
        Task<string> GetLocalizedItem(string resourceKey);
    }
}
