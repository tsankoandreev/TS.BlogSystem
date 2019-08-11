using System;
using System.Collections.Generic;
using System.Text;
using TS.BlogSystem.Core.Entities;

namespace TS.BlogSystem.Core.Interfaces.Services
{
    public interface ICommentService
    {
        /// <summary>
        /// Delete comment
        /// </summary>
        /// <param name="comment">Comment</param>
        void DeleteComment(Comment comment);
        /// <summary>
        /// Gets a comment
        /// </summary>
        /// <param name="commentId">Comment identifier</param>
        /// <returns>Comment</returns>
        Comment GetCommentById(Guid commentId);

        /// <summary>
        /// Inserts comment
        /// </summary>
        /// <param name="comment">Comment</param>
        void InsertComment(Comment comment);

        /// <summary>
        /// Updates the comment
        /// </summary>
        /// <param name="comment">Comment</param>
        void UpdateComment(Comment comment);

        /// <summary>
        /// Returns all comments
        /// </summary>
        /// <returns></returns>
        List<Comment> GetAll();
        /// <summary>
        /// Returns all comments by post
        /// </summary>
        /// <param name="postId"></param>
        /// <returns></returns>
        List<Comment> GetAll(Guid postId);
    }
}
