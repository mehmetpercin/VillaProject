using Microsoft.EntityFrameworkCore;
using VillaProject.Application.Repositories;
using VillaProject.Domain.Entities;

namespace VillaProject.Persistence.Repositories
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        private readonly AppDbContext _appDbContext;

        public OrderRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Order> GetOrderWithOrderItemsByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _appDbContext.Orders
                .Include(x => x.OrderItems)
                .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }
    }
}
