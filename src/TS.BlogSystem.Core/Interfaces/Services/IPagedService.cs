using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TS.BlogSystem.Core.Interfaces.Services
{
    public interface IPagedService<T>
    {
        Task<IPagedList<T>> GetPagedResult(int page, int pageCount, string orderProperty = "", bool asc = true);
        Task<IPagedList<T>> GetPagedResult(int page, int pageCount, Expression<Func<T, bool>> filter, string orderProperty = "", bool asc = true);
        Task<IPagedList<T>> GetPagedResult(int page, int pageCount, Expression<Func<T, bool>> filter, Expression<Func<T, object>> orderLambda, bool asc = true);
    }
}
