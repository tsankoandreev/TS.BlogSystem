using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TS.BlogSystem.Core.Common;
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

        public async Task<Comment> GetById(Guid entityId)
        {
            return await _commentRepository.GetByIdAsync(entityId);
        }

        public async Task<List<Comment>> GetAll()
        {
            return await _commentRepository.ListAllAsync();
        }

        public async Task<List<Comment>> GetAll(Guid postId)
        {
            throw new NotImplementedException();
        }

        public async Task<IPagedList<Comment>> GetPagedResult(int pageIndex, int pageSize, string orderProperty = "", bool asc = true)
        {
            var totalCount = await _commentRepository.CountAll();
            var filteredCount = totalCount;//filtered == total
            IPagedList<Comment> result = new PagedList<Comment>(
                    _commentRepository.Query().OrderBy(x => x.Id)
                    .Skip((pageIndex - 1) * pageSize)
                    .Take(pageSize),
                    pageIndex,
                    pageSize,
                    filteredCount,
                    totalCount);

            return result;
        }

        public async Task<IPagedList<Comment>> GetPagedResult(int pageIndex, int pageSize, Expression<Func<Comment, bool>> filter, string orderProperty = "", bool asc = true)
        {
            var totalCount = await _commentRepository.CountAll();
            var filteredCount = totalCount;//filtered == total
            IPagedList<Comment> result = new PagedList<Comment>(
                    _commentRepository.Query().OrderBy(x => x.Id)
                    .Skip((pageIndex - 1) * pageSize)
                    .Take(pageSize),
                    pageIndex,
                    pageSize,
                    filteredCount,
                    totalCount);

            return result;
        }

        public async Task<IPagedList<Comment>> GetPagedResult(int pageIndex, int pageSize, Expression<Func<Comment, bool>> filter, Expression<Func<Comment, object>> orderLambda, bool asc = true)
        {
            var totalCount = await _commentRepository.CountAll();
            var filteredCount = totalCount;//filtered == total
            IPagedList<Comment> result = new PagedList<Comment>(
                    _commentRepository.Query().OrderBy(x => x.Id)
                    .Skip((pageIndex - 1) * pageSize)
                    .Take(pageSize),
                    pageIndex,
                    pageSize,
                    filteredCount,
                    totalCount);

            return result;
        }

        public async Task Insert(Comment entity)
        {
            await _commentRepository.AddAsync(entity);
        }

        public async Task Update(Comment entity)
        {
            await _commentRepository.UpdateAsync(entity);
        }

        public async Task Delete(Comment entity)
        {
            await _commentRepository.DeleteAsync(entity);
        }
    }
}
