using Microsoft.EntityFrameworkCore;
using VillaProject.Application.Repositories;
using VillaProject.Domain.Entities;

namespace VillaProject.Persistence.Repositories
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }

        public async Task<Order> GetOrderWithOrderItemsByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await Table
                .Include(x => x.OrderItems)
                .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }
    }
}
