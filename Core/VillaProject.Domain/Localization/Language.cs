using VillaProject.Domain.Common;

namespace VillaProject.Domain.Localization
{
    public class Language : DbObjectBase<int>
    {
        public Language()
        {
            LanguageResources = new HashSet<LanguageResource>();
        }

        public string Name { get; set; }
        public string Culture { get; set; }

        public ICollection<LanguageResource> LanguageResources { get; set; }
    }
}
