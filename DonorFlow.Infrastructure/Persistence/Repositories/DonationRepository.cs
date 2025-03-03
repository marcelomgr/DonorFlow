using DonorFlow.Core.Entities;
using DonorFlow.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DonorFlow.Infrastructure.Persistence.Repositories
{
    public class DonationRepository : GenericRepository<Donation>, IDonationRepository
    {
        private readonly DonorDbContext _context;

        public DonationRepository(DonorDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Donation?>> GetByDonor(Guid donorId)
        {
            return await _context.Donations.Where(d => d.DonorId == donorId).ToListAsync();
        }
    }
}
