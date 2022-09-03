using VillaProject.Domain.Entities;

namespace VillaProject.Application.Repositories
{
    public interface IOrderRepository : IRepository<Order>
    {
        Task<Order> GetOrderWithOrderItemsByIdAsync(int id, CancellationToken cancellationToken = default);
    }
}
