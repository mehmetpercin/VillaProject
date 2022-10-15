using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VillaProject.Domain.Entities;
using VillaProject.Persistence.Configurations.Common;

namespace VillaProject.Persistence.Configurations
{
    public class CategoryConfiguration : DbObjectConfiguration<Category>
    {
        public override void Configure(EntityTypeBuilder<Category> builder)
        {
            base.Configure(builder);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
        }
    }
}
