namespace VillaProject.Application.Repositories
{
    public interface IUnitOfWork :IDisposable
    {
        IVillaRepository Villas { get; }
        IOrderRepository Orders { get; }
        ICategoryRepository Categories { get; }
        IProductRepository Products { get; }
        Task SaveAsync(CancellationToken cancellationToken = default);
    }
}
