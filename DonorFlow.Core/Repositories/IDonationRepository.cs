using DonorFlow.Core.Entities;

namespace DonorFlow.Core.Repositories
{
    public interface IDonationRepository : IGenericRepository<Donation>
    {
        Task<IEnumerable<Donation?>> GetByDonor(Guid donorId);
    }
}
