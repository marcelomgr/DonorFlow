using DonorFlow.Core.Entities;
using DonorFlow.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DonorFlow.Infrastructure.Persistence.Repositories
{
    public class DonorRepository : GenericRepository<Donor>, IDonorRepository
    {
        private readonly DonorDbContext _context;

        public DonorRepository(DonorDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Donor?> GetByEmailAsync(string email)
        {
            return await _context.Donors.SingleOrDefaultAsync(u => u.Email == email);
        }

        public async Task DeleteAsync(Guid id)
        {
            var user = await _context.Donors.FindAsync(id);

            if (user is not null)
            {
                user.Delete();
                await _context.SaveChangesAsync();
            }
        }
    }
}
