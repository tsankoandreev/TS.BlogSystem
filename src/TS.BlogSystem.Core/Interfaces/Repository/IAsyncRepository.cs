using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TS.BlogSystem.Core.Entities;

namespace TS.BlogSystem.Core.Interfaces.Repository
{
    public interface IAsyncRepository<T> where T : Entity
    {
        Task<T> GetByIdAsync(Guid id);

        Task<List<T>> ListAllAsync();
        Task<List<T>> ListAsync(Expression<Func<T, bool>> predicate);

        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
