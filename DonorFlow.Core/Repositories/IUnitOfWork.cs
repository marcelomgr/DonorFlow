using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonorFlow.Core.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }
        IDonorRepository Donors { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
