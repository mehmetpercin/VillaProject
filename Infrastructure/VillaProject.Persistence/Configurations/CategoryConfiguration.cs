using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VillaProject.Domain.Entities;

namespace VillaProject.Persistence.Configurations
{
    public class CategoryConfiguration : DbObjectBaseConfiguration<Category>
    {
        public override void Configure(EntityTypeBuilder<Category> builder)
        {
            base.Configure(builder);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
        }
    }
}
