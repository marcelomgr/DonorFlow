using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DonorFlow.Core.Repositories
{
    public interface IGenericRepository<T>
    {
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] includes);
        Task<T?> GetByIdAsync(Guid id);
        Task<T?> GetByIdAsync(Guid id, params Expression<Func<T, object>>[] includes);
    }
}
