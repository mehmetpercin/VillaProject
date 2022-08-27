using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using VillaProject.Application.Repositories;

namespace VillaProject.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UnitOfWork(AppDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public IVillaRepository Villas => new VillaRepository(_context);
        public IOrderRepository Orders => new OrderRepository(_context);
        public ICategoryRepository Categories => new CategoryRepository(_context);

        public async Task SaveAsync(CancellationToken cancellationToken = default)
        {
            var username = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            await _context.SaveChangesAsync(username, cancellationToken);
        }
    }
}
