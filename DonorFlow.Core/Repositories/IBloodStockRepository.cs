using DonorFlow.Core.Enums;
using DonorFlow.Core.Entities;

namespace DonorFlow.Core.Repositories;

public interface IBloodStockRepository : IGenericRepository<BloodStock>
{
    Task<BloodStock> GetByTypeAndFactorAsync(BloodType bloodType, RhFactor rhFactor);
    Task AddOrUpdateAsync(BloodStock bloodStock);
}