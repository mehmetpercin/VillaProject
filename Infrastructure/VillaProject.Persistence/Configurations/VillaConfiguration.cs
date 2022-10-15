using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VillaProject.Domain.Entities;
using VillaProject.Persistence.Configurations.Common;

namespace VillaProject.Persistence.Configurations
{
    public class VillaConfiguration : DbObjectConfiguration<Villa>
    {
        public override void Configure(EntityTypeBuilder<Villa> builder)
        {
            base.Configure(builder);
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Name).HasMaxLength(50);
        }
    }
}
