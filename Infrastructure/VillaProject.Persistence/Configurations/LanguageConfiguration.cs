using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VillaProject.Domain.Localization;
using VillaProject.Persistence.Configurations.Common;

namespace VillaProject.Persistence.Configurations
{
    public class LanguageConfiguration : DbObjectBaseConfiguration<Language>
    {
        public override void Configure(EntityTypeBuilder<Language> builder)
        {
            base.Configure(builder);
            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(x => x.Culture)
                .IsRequired()
                .HasMaxLength(10);
            builder.HasMany(x => x.LanguageResources)
                .WithOne(x => x.Language);
        }
    }
}
