using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VillaProject.Domain.Common;

namespace VillaProject.Persistence.Configurations.Common
{
    public abstract class DbObjectBaseConfiguration<T> : IEntityTypeConfiguration<T> where T : DbObjectBase<int>
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
        }
    }
}
