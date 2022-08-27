using VillaProject.Domain.Entities;

namespace VillaProject.Application.Repositories
{
    public interface IOrderRepository : IRepository<Order>
    {
        Task<Order> GetOrderWithOrderItemsByIdAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
