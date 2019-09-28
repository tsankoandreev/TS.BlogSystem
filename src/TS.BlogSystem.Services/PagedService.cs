using System;
using System.Linq.Expressions;
using System.Linq;
using System.Threading.Tasks;
using TS.BlogSystem.Core.Common;
using TS.BlogSystem.Core.Entities;
using TS.BlogSystem.Core.Interfaces.Repository;
using TS.BlogSystem.Core.Interfaces.Services;
using TS.BlogSystem.Core.Interfaces;

namespace TS.BlogSystem.Services
{
    public abstract class PagedService<T> : IPagedService<T> where T : Entity
    {
        private readonly IAsyncRepository<T> _repository;
        public PagedService(IAsyncRepository<T> repo)
        {
            this._repository = repo;
        }

        public async Task<IPagedList<T>> GetPagedResult(int pageIndex, int pageSize, string orderProperty = "", bool asc = true)
        {
            Expression<Func<T, object>> orderLambda = x => x.Id;
            if (!string.IsNullOrWhiteSpace(orderProperty))
            {
                System.Reflection.PropertyInfo prop = typeof(T).GetProperty(orderProperty);
                orderLambda = x => prop.GetValue(x, null);
            }

            var totalCount = await _repository.CountAll();
            var filteredCount = totalCount;
            IPagedList<T> result = new PagedList<T>(
                    _repository.Query().OrderBy(orderLambda)
                    .Skip((pageIndex - 1) * pageSize)
                    .Take(pageSize),
                    pageIndex,
                    pageSize,
                    filteredCount,
                    totalCount);

            return result;
        }

        public async Task<IPagedList<T>> GetPagedResult(int pageIndex, int pageSize, Expression<Func<T, bool>> filter, string orderProperty = "", bool asc = true)
        {
            Expression<Func<T, object>> orderLambda = x => x.Id;
            if (!string.IsNullOrWhiteSpace(orderProperty))
            {
                System.Reflection.PropertyInfo prop = typeof(T).GetProperty(orderProperty);
                orderLambda = x => prop.GetValue(x, null);
            }

            var totalCount = await _repository.CountAll();
            var filteredCount = await _repository.CountWhere(filter);
            IPagedList<T> result = new PagedList<T>(
                    _repository.Query().Where(filter).OrderBy(orderLambda)
                    .Skip((pageIndex - 1) * pageSize)
                    .Take(pageSize),
                    pageIndex,
                    pageSize,
                    filteredCount,
                    totalCount);

            return result;
        }

        public async Task<IPagedList<T>> GetPagedResult(int pageIndex, int pageSize, Expression<Func<T, bool>> filter, Expression<Func<T, object>> orderLambda, bool asc = true)
        {
            var totalCount = await _repository.CountAll();
            var filteredCount = await _repository.CountWhere(filter);

            if (orderLambda == null)
                orderLambda = x => x.Id;

            IPagedList<T> result = new PagedList<T>(
                _repository.Query().Where(filter).OrderBy(orderLambda)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize),
                pageIndex,
                pageSize,
                filteredCount,
                totalCount);

            return result;
        }
    }
}
