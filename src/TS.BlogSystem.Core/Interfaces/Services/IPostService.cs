using System;
using System.Collections.Generic;
using System.Text;
using TS.BlogSystem.Core.Entities;

namespace TS.BlogSystem.Core.Interfaces.Services
{
    public interface IPostService
    {
        /// <summary>
        /// Delete post
        /// </summary>
        /// <param name="post">Post</param>
        void DeletePost(Post post);
        /// <summary>
        /// Gets a post
        /// </summary>
        /// <param name="postId">Post identifier</param>
        /// <returns>Post</returns>
        Post GetPostById(Guid postId);

        /// <summary>
        /// Inserts post
        /// </summary>
        /// <param name="post">Post</param>
        void InsertPost(Post post);

        /// <summary>
        /// Updates the post
        /// </summary>
        /// <param name="post">Post</param>
        void UpdatePost(Post post);

        /// <summary>
        /// Retrieve all posts
        /// </summary>
        /// <returns></returns>
        List<Post> GetAll();

    }
}
