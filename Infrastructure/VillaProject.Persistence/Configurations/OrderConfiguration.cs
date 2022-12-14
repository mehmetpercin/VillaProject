using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VillaProject.Domain.Entities;
using VillaProject.Domain.Enums;
using VillaProject.Persistence.Configurations.Common;

namespace VillaProject.Persistence.Configurations
{
    public class OrderConfiguration : DbObjectConfiguration<Order>
    {
        public override void Configure(EntityTypeBuilder<Order> builder)
        {
            base.Configure(builder);
            builder.HasOne(x => x.Villa).WithMany(x => x.Orders);
            builder.Property(x => x.StatusId).IsRequired().HasConversion<int>().HasDefaultValue(OrderStatusEnum.Open);
        }
    }
}
