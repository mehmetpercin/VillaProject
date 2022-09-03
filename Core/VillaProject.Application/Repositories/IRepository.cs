using System.Linq.Expressions;
using VillaProject.Domain.Common;

namespace VillaProject.Application.Repositories
{
    public interface IRepository<TEntity> where TEntity : DbObject
    {
        Task<TEntity> GetByIdAsync(int id, CancellationToken cancellationToken = default, bool tracking = true);
        IQueryable<TEntity> GetAll(bool tracking = true);
        Task<List<TEntity>> GetByFilterAsync(Expression<Func<TEntity, bool>> filter, CancellationToken cancellationToken = default, bool tracking = true);
        Task<TEntity> GetFirstAsync(Expression<Func<TEntity, bool>> filter, CancellationToken cancellationToken = default, bool tracking = true);
        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> filter, CancellationToken cancellationToken = default);
        Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default);
        Task AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default);
        Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);
        Task RemoveAsync(TEntity entity, CancellationToken cancellationToken = default);
        Task RemoveRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default);
    }
}
