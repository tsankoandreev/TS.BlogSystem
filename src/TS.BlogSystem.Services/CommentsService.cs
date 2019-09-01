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
    public class CommentsService : ICommentService
    {
        private readonly IAsyncRepository<Comment> _commentRepository;
        private readonly IAsyncRepository<Post> _postRepository;

        public CommentsService(IAsyncRepository<Comment> commentRepository, IAsyncRepository<Post> postRepository)
        {
            this._commentRepository = commentRepository;
            this._postRepository = postRepository;
        }

        public Task<Comment> GetById(Guid entityId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Comment>> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<Comment> GetAll(Guid postId)
        {
            throw new NotImplementedException();
        }

        public Task<IPagedList<Comment>> GetPagedResult(int page, int pageCount, string orderProperty = "", bool asc = true)
        {
            throw new NotImplementedException();
        }

        public Task<IPagedList<Comment>> GetPagedResult(int page, int pageCount, Expression<Func<Comment, bool>> filter, string orderProperty = "", bool asc = true)
        {
            throw new NotImplementedException();
        }

        public Task<IPagedList<Comment>> GetPagedResult(int page, int pageCount, Expression<Func<Comment, bool>> filter, Expression<Func<Comment, object>> orderLambda, bool asc = true)
        {
            throw new NotImplementedException();
        }

        public Task Insert(Comment entity)
        {
            throw new NotImplementedException();
        }

        public Task Update(Comment entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Comment entity)
        {
            throw new NotImplementedException();
        }
    }
}
