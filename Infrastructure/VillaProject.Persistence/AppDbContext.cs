using Microsoft.EntityFrameworkCore;
using VillaProject.Domain;
using VillaProject.Domain.Common;

namespace VillaProject.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Villa> Villas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
            base.OnModelCreating(modelBuilder);
        }

        public virtual Task<int> SaveChangesAsync(string user = "", CancellationToken cancellationToken = default)
        {
            var entities = ChangeTracker.Entries<DbObject>();
            var now = DateTimeOffset.Now;
            var userId = string.IsNullOrWhiteSpace(user) ? "SYSTEM" : user;

            foreach (var entity in entities)
            {
                switch (entity.State)
                {
                    case EntityState.Modified:
                        entity.Entity.ModifiedDate = now;
                        entity.Entity.Modifier = userId;
                        break;
                    case EntityState.Added:
                        entity.Entity.CreatedDate = now;
                        entity.Entity.Creator = userId;
                        break;
                    default:
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
