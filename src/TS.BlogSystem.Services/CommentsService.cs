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
    public class CommentsService : PagedService<Comment>, ICommentService
    {
        private readonly IAsyncRepository<Comment> _commentRepository;
        private readonly IAsyncRepository<Post> _postRepository;

        public CommentsService(IAsyncRepository<Comment> commentRepository, IAsyncRepository<Post> postRepository)
            : base(commentRepository)
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
            return await _commentRepository.ListAsync(c=>c.Post.Id.Equals(postId));
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
