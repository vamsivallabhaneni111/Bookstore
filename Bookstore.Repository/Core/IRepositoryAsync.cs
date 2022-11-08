using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Bookstore.Repository.Core
{
    public interface IRepositoryAsync<TDomain>
        where TDomain : class
    {
        Task<TDomain> FindAsync();
        Task<IEnumerable<TDomain>> FindAsync(Expression<Func<TDomain, bool>> predicate);
        Task AddAsync(TDomain record);
        Task AddAsync(IEnumerable<TDomain> records);
        Task<TDomain> UpdateAsync(TDomain record);
        Task UpdateAsync(IEnumerable<TDomain> records);
        Task DeleteAsync(Guid id);
        Task DeleteAsync(TDomain record);
        Task DeleteAsync(Expression<Func<TDomain, bool>> predicate);
        Task DeleteAllAsync();
    }
}
