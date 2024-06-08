using DonorFlow.Core.Repositories;

namespace DonorFlow.Infrastructure.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DonorDbContext _context;

        public UnitOfWork(DonorDbContext context,
            IUserRepository userRepository,
            IDonorRepository donorRepository
            )
        {
            _context = context;
            Users = userRepository;
            Donors = donorRepository;
        }

        public IUserRepository Users { get; }
        public IDonorRepository Donors { get; }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await _context.SaveChangesAsync(cancellationToken);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
