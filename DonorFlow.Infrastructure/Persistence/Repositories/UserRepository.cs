using DonorFlow.Core.Entities;
using DonorFlow.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DonorFlow.Infrastructure.Persistence.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly DonorDbContext _context;

        public UserRepository(DonorDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            return await _context.Users.SingleOrDefaultAsync(u => u.Email == email);
        }

        public async Task<User?> ValidateUserCredentialsAsync(string email, string passwordHash)
        {
            return await _context.Users.SingleOrDefaultAsync(u => u.Email == email && u.Password == passwordHash);
        }

        public async Task DeleteAsync(Guid id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user is not null)
            {
                user.Delete();
                user.Inactive();
                await _context.SaveChangesAsync();
            }
        }
    }
}
