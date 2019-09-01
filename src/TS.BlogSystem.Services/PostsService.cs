using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TS.BlogSystem.Core.Entities;
using TS.BlogSystem.Core.Interfaces;
using TS.BlogSystem.Core.Interfaces.Repository;
using TS.BlogSystem.Core.Interfaces.Services;

namespace TS.BlogSystem.Services
{
    public class PostsService : IPostService
    {
        private readonly IAsyncRepository<Post> _postRepository;

        public PostsService(IAsyncRepository<Post> postRepository)
        {
            this._postRepository = postRepository;
        }

        public Task<Post> GetById(Guid entityId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Post>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IPagedList<Post>> GetPagedResult(int page, int pageCount, string orderProperty = "", bool asc = true)
        {
            throw new NotImplementedException();
        }

        public Task<IPagedList<Post>> GetPagedResult(int page, int pageCount, Expression<Func<Post, bool>> filter, string orderProperty = "", bool asc = true)
        {
            throw new NotImplementedException();
        }

        public Task<IPagedList<Post>> GetPagedResult(int page, int pageCount, Expression<Func<Post, bool>> filter, Expression<Func<Post, object>> orderLambda, bool asc = true)
        {
            throw new NotImplementedException();
        }

        public Task Insert(Post entity)
        {
            throw new NotImplementedException();
        }

        public Task Update(Post entity)
        {
            throw new NotImplementedException();
        }
        public Task Delete(Post entity)
        {
            throw new NotImplementedException();
        }

    }
}
