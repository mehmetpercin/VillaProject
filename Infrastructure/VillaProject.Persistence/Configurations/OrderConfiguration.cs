using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VillaProject.Domain.Entities;
using VillaProject.Domain.Enums;

namespace VillaProject.Persistence.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasOne(x => x.Villa).WithMany(x => x.Orders);
            builder.Property(x => x.StatusId).IsRequired().HasConversion<int>().HasDefaultValue(OrderStatusEnum.Open);
        }
    }
}
