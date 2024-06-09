using DonorFlow.Core.Entities;

namespace DonorFlow.Core.Repositories
{
    public interface IDonorRepository : IGenericRepository<Donor>
    {
        Task<Donor?> GetByEmailAsync(string email);
        Task DeleteAsync(Guid id);
    }
}
