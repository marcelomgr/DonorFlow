using DonorFlow.Core.Entities;
using DonorFlow.Core.Repositories;

namespace DonorFlow.Infrastructure.Persistence.Repositories
{
    public class DonationRepository : GenericRepository<Donation>, IDonationRepository
    {
        private readonly DonorDbContext _context;

        public DonationRepository(DonorDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
