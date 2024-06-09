namespace DonorFlow.Core.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }
        IDonorRepository Donors { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
