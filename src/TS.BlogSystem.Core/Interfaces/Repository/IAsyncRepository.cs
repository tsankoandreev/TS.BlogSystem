using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TS.BlogSystem.Core.Entities;

namespace TS.BlogSystem.Core.Interfaces.Repository
{
    public interface IAsyncRepository<T> where T : Entity
    {
        IQueryable<T> Query();

        Task<T> GetByIdAsync(Guid id);
        Task<T> FirstOrDefault(Expression<Func<T, bool>> predicate);

        Task<List<T>> ListAllAsync();
        Task<List<T>> ListAsync(Expression<Func<T, bool>> predicate);

        Task<int> CountAll();
        Task<int> CountWhere(Expression<Func<T, bool>> predicate);

        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
