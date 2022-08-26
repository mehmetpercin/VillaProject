using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using VillaProject.Domain.Entities;
using VillaProject.Domain.Enums;

namespace VillaProject.Persistence.Configurations
{
    public class OrderStatusConfiguration : IEntityTypeConfiguration<OrderStatus>
    {
        public void Configure(EntityTypeBuilder<OrderStatus> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired().HasConversion<int>().IsRequired();
            builder.Property(x => x.Status).IsRequired().HasMaxLength(50);
            builder.HasData(
                Enum.GetValues(typeof(OrderStatusEnum))
                    .Cast<OrderStatusEnum>()
                    .Select(x => new OrderStatus()
                    {
                        Id = x,
                        Status = x.ToString()
                    })
            );
        }
    }
}
