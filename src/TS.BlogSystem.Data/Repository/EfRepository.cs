using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TS.BlogSystem.Core.Entities;
using TS.BlogSystem.Core.Interfaces.Context;
using TS.BlogSystem.Core.Interfaces.Repository;
using TS.BlogSystem.Data.Context;

namespace TS.BlogSystem.Data.Repository
{
    public partial class EfRepository<T> : IAsyncRepository<T> where T : Entity
    {
        protected readonly BlogContext _dbContext;
        public EfRepository(IBlogContext dbContext)
        {
            _dbContext = dbContext as BlogContext;
        }

        public IQueryable<T> Query()
        {
            return _dbContext.Set<T>();
        }
        public async Task<T> GetByIdAsync(Guid id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }
        public Task<T> FirstOrDefault(Expression<Func<T, bool>> predicate)
            => _dbContext.Set<T>().FirstOrDefaultAsync(predicate);


        public async Task<List<T>> ListAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<List<T>> ListAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbContext.Set<T>().Where(predicate).ToListAsync();
        }


        public Task<int> CountAll() => _dbContext.Set<T>().CountAsync();

        public Task<int> CountWhere(Expression<Func<T, bool>> predicate)
            => _dbContext.Set<T>().CountAsync(predicate);


        public async Task<T> AddAsync(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
    }
}
