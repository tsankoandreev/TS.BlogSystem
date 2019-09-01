using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TS.BlogSystem.Core.Entities;

namespace TS.BlogSystem.Core.Interfaces.Services
{
    public interface IPagedService<T> where T : Entity
    {
        Task<IPagedList<T>> GetPagedResult(int page, int pageCount, string orderProperty = "", bool asc = true);
        Task<IPagedList<T>> GetPagedResult(int page, int pageCount, Expression<Func<T, bool>> filter, string orderProperty = "", bool asc = true);
        Task<IPagedList<T>> GetPagedResult(int page, int pageCount, Expression<Func<T, bool>> filter, Expression<Func<T, object>> orderLambda, bool asc = true);
    }
}
