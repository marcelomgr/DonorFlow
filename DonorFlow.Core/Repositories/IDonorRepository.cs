using DonorFlow.Core.Entities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonorFlow.Core.Repositories
{
    public interface IDonorRepository : IGenericRepository<Donor>
    {
        Task<Donor?> GetByEmailAsync(string email);
        Task DeleteAsync(Guid id);
    }
}
