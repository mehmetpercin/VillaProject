using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VillaProject.Identity.Entities;

namespace VillaProject.Identity.Configurations
{
    internal class UserRefreshTokenConfiguration : IEntityTypeConfiguration<UserRefreshToken>
    {
        public void Configure(EntityTypeBuilder<UserRefreshToken> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.UserId).IsRequired();
            builder.Property(x => x.RefreshToken).HasMaxLength(60).IsRequired();
            builder.Property(x => x.Expiration).IsRequired();
        }
    }
}
