using DonorFlow.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonorFlow.Core.Repositories
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User?> GetByEmailAsync(string email);
        Task<User?> ValidateUserCredentialsAsync(string email, string passwordHash);
        Task DeleteAsync(Guid id);
    }
}
