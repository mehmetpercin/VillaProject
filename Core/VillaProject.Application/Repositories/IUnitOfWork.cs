namespace VillaProject.Application.Repositories
{
    public interface IUnitOfWork :IDisposable
    {
        IVillaRepository Villas { get; }
        Task Save(CancellationToken cancellationToken = default);
    }
}
