using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VillaProject.Domain.Localization;
using VillaProject.Persistence.Configurations.Common;

namespace VillaProject.Persistence.Configurations
{
    public class LanguageResourceConfiguration : DbObjectBaseConfiguration<LanguageResource>
    {
        public override void Configure(EntityTypeBuilder<LanguageResource> builder)
        {
            base.Configure(builder);
            builder.Property(x => x.ResourceValue)
                .IsRequired();
            builder.Property(x => x.ResourceKey)
                .IsRequired()
                .HasMaxLength(50);
            builder.HasOne(x => x.Language)
                .WithMany(x => x.LanguageResources);

            builder.HasIndex(x => new { x.LanguageId, x.ResourceKey })
                .IsUnique();
        }
    }
}
