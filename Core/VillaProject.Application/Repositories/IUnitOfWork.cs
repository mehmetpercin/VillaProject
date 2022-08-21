namespace VillaProject.Application.Repositories
{
    public interface IUnitOfWork :IDisposable
    {
        IVillaRepository Villas { get; }
        Task SaveAsync(CancellationToken cancellationToken = default);
    }
}
