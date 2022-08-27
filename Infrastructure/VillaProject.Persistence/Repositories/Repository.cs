using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using VillaProject.Application.Repositories;
using VillaProject.Domain.Common;

namespace VillaProject.Persistence.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : DbObject
    {
        private readonly AppDbContext _dbContext;

        public Repository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        private DbSet<TEntity> Table => _dbContext.Set<TEntity>();

        public async Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            await Table.AddAsync(entity, cancellationToken);
            return entity;
        }

        public async Task AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
        {
            await Table.AddRangeAsync(entities, cancellationToken);
        }

        public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> filter, CancellationToken cancellationToken = default)
        {
            return await Table.AnyAsync(filter, cancellationToken);
        }

        public IQueryable<TEntity> GetAll(bool tracking = true)
        {
            if (tracking)
                return Table;

            return Table.AsNoTracking();
        }

        public async Task<List<TEntity>> GetByFilterAsync(Expression<Func<TEntity, bool>> filter, CancellationToken cancellationToken = default, bool tracking = true)
        {
            if (tracking)
                return await Table.Where(filter).ToListAsync(cancellationToken);

            return await Table.AsNoTracking().Where(filter).ToListAsync(cancellationToken);
        }

        public async Task<TEntity> GetByIdAsync(Guid id, CancellationToken cancellationToken = default, bool tracking = true)
        {
            if (tracking)
                return await Table.FindAsync(new object[] { id }, cancellationToken);

            return await Table.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        public async Task<TEntity> GetFirstAsync(Expression<Func<TEntity, bool>> filter, CancellationToken cancellationToken = default, bool tracking = true)
        {
            if (tracking)
                return await Table.FirstOrDefaultAsync(filter, cancellationToken);

            return await Table.AsNoTracking().FirstOrDefaultAsync(filter, cancellationToken);
        }

        public async Task RemoveAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            await Task.Run(() => Table.Remove(entity), cancellationToken);
        }

        public async Task RemoveRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
        {
            await Task.Run(() => Table.RemoveRange(entities), cancellationToken);
        }

        public async Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            var updatedData = await Task.Run(() => Table.Update(entity), cancellationToken);
        }
    }
}
