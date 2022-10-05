using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VillaProject.Domain.Entities;

namespace VillaProject.Persistence.Configurations
{
    public class VillaConfiguration : DbObjectBaseConfiguration<Villa>
    {
        public override void Configure(EntityTypeBuilder<Villa> builder)
        {
            base.Configure(builder);
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Name).HasMaxLength(50);
        }
    }
}
