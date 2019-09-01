using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TS.BlogSystem.Core.Entities;

namespace TS.BlogSystem.Core.Interfaces.Services
{
    public interface IService<T> where T : Entity
    {
        /// <summary>
        /// Gets entity by Id
        /// </summary>
        /// <returns>entity<T></returns>
        Task<T> GetById(Guid entityId);

        /// <summary>
        /// Retrieve all entities of Type <T>
        /// </summary>
        /// <returns></returns>
        Task<List<T>> GetAll();

        /// <summary>
        /// Inserts entity
        /// </summary>
        /// <param name="entity">entity</param>
        /// 
        Task Insert(T entity);

        /// <summary>
        /// Updates entity
        /// </summary>
        /// <param name="entity">entity</param>
        Task Update(T entity);

        /// <summary>
        /// Delete entity
        /// </summary>
        /// <param name="entity">entity</param>
        Task Delete(T entity);



    }
}
