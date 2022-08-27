namespace VillaProject.Application.Repositories
{
    public interface IUnitOfWork :IDisposable
    {
        IVillaRepository Villas { get; }
        IOrderRepository Orders { get; }
        ICategoryRepository Categories { get; }
        Task SaveAsync(CancellationToken cancellationToken = default);
    }
}
