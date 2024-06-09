using DonorFlow.Core.Entities;

namespace DonorFlow.Core.Repositories
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User?> GetByEmailAsync(string email);
        Task<User?> ValidateUserCredentialsAsync(string email, string passwordHash);
        Task DeleteAsync(Guid id);
    }
}
