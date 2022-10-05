using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VillaProject.Domain.Common;

namespace VillaProject.Persistence.Configurations
{
    public abstract class DbObjectBaseConfiguration<T> : IEntityTypeConfiguration<T> where T : DbObject
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.CreatedDate).IsRequired();
            builder.Property(x => x.Creator).IsRequired()
                .HasColumnType("varchar(50)")
                .HasMaxLength(50);
            builder.Property(x => x.ModifiedDate).IsRequired(false);
            builder.Property(x => x.Modifier).IsRequired(false)
                .HasColumnType("varchar(50)")
                .HasMaxLength(50);
            builder.Property(x => x.RowVersion).IsRowVersion();
        }
    }
}
