using System;
using System.Collections.Generic;
using TS.BlogSystem.Core.Entities;
using TS.BlogSystem.Core.Interfaces.Repository;
using TS.BlogSystem.Core.Interfaces.Services;

namespace TS.BlogSystem.Services
{
    public class PostsService : IPostService
    {
        private readonly IRepository<Post> _postRepository;

        public PostsService(IRepository<Post> postRepository)
        {
            this._postRepository = postRepository;
        }

        public void DeletePost(Post post)
        {
            throw new NotImplementedException();
        }

        public List<Post> GetAll()
        {
            throw new NotImplementedException();
        }

        public Post GetPostById(Guid postId)
        {
            throw new NotImplementedException();
        }

        public void InsertPost(Post post)
        {
            throw new NotImplementedException();
        }

        public void UpdatePost(Post post)
        {
            throw new NotImplementedException();
        }
    }
}
