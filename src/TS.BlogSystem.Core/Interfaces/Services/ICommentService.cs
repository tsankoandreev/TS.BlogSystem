using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TS.BlogSystem.Core.Entities;

namespace TS.BlogSystem.Core.Interfaces.Services
{
    public interface ICommentService:IService<Comment>,IPagedService<Comment>
    {
        /// <summary>
        /// Returns all comments by post
        /// </summary>
        /// <param name="postId"></param>
        /// <returns></returns>
        Task<List<Comment>> GetAll(Guid postId);
    }
}
