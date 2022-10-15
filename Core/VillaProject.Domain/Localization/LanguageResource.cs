using VillaProject.Domain.Common;

namespace VillaProject.Domain.Localization
{
    public class LanguageResource : DbObjectBase<int>
    {
        public int LanguageId { get; set; }
        public string ResourceKey { get; set; }
        public string ResourceValue { get; set; }

        public Language Language { get; set; }
    }
}
