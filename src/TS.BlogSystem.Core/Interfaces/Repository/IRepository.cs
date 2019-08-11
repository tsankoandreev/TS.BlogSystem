using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using TS.BlogSystem.Core.Entities;

namespace TS.BlogSystem.Core.Interfaces.Repository
{
    public interface IRepository<T> where T : Entity
    {
        T GetById(Guid id);

        IEnumerable<T> GetAll();
        IEnumerable<T> GetAll(Expression<Func<T, bool>> filter = null);

        T Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
