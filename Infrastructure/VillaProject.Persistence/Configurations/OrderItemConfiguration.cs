using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VillaProject.Domain.Entities;

namespace VillaProject.Persistence.Configurations
{
    public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.HasOne(x => x.Order).WithMany(x => x.OrderItems);
            builder.HasOne(x => x.Product).WithMany(x => x.OrderItems);
            builder.Property(x => x.Price).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(x => x.Quantity).IsRequired();
            builder.Property(x => x.IsCancelled).IsRequired().HasDefaultValue(false);
        }
    }
}
