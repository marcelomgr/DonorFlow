using DonorFlow.Core.Enums;
using DonorFlow.Core.Entities;
using DonorFlow.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DonorFlow.Infrastructure.Persistence.Repositories
{
    public class BloodStockRepository : GenericRepository<BloodStock>, IBloodStockRepository
    {
        private readonly DonorDbContext _context;

        public BloodStockRepository(DonorDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<BloodStock> GetByTypeAndFactorAsync(BloodType bloodType, RhFactor rhFactor)
        {
            return await _context.BloodStocks.FirstOrDefaultAsync(b => b.BloodType == bloodType && b.RhFactor == rhFactor);
        }

        public async Task AddOrUpdateAsync(BloodStock bloodStock)
        {
            var existingBloodStock = await GetByTypeAndFactorAsync(bloodStock.BloodType, bloodStock.RhFactor);

            if (existingBloodStock != null)
            {
                // Atualiza a quantidade existente
                existingBloodStock.AddQuantity(bloodStock.QuantityML);
            }
            else
            {
                // Adiciona novo registro
                await _context.BloodStocks.AddAsync(bloodStock);
            }

            await _context.SaveChangesAsync();
        }
    }
}
