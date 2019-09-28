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
    public class PostsService : PagedService<Post>,IPostService
    {
        private readonly IAsyncRepository<Post> _postRepository;

        public PostsService(IAsyncRepository<Post> postRepository)
            : base(postRepository)
        {
            this._postRepository = postRepository;
        }

        public async Task<Post> GetById(Guid entityId)
        {
            return await _postRepository.GetByIdAsync(entityId);
        }

        public async Task<List<Post>> GetAll()
        {
            return await _postRepository.ListAllAsync();
        }

        public async Task Insert(Post entity)
        {
            await _postRepository.AddAsync(entity);
        }

        public async Task Update(Post entity)
        {
            await _postRepository.UpdateAsync(entity);
        }
        public async Task Delete(Post entity)
        {
            await _postRepository.DeleteAsync(entity);
        }

    }
}
