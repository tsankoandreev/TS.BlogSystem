using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TS.BlogSystem.Core.Common;
using TS.BlogSystem.Core.Interfaces.Services;
using TS.BlogSystem.Web.Mappers;
using TS.BlogSystem.Web.Models;

namespace TS.BlogSystem.Web.ViewComponents
{
    public class CommentsViewComponent : ViewComponent
    {
        private readonly ICommentService _commentService;

        public CommentsViewComponent(ICommentService commentService)
        {
            _commentService = commentService;
        }

        public async Task<IViewComponentResult> InvokeAsync(Guid postId, int page = 0)
        {
            var comments = await _commentService.GetPagedResult(page, 10, x => x.Post.Id == postId && x.IsReply == false, x => x.DateCreated);
            var data = comments.Select(x => CommentViewModelMapper.Map(x)).ToList();

            List<Core.Entities.Comment> replies = await _commentService.GetReplies(postId);
            foreach (var item in data)
            {
                FillReplies(item, replies);
            }

            var commentsResult = new PagedList<CommentViewModel>(data, comments.PageIndex, comments.PageSize, comments.ResultsCaunt, comments.TotalCaunt);

            return await Task.FromResult((IViewComponentResult)View(commentsResult));
        }

        /// <summary>
        /// Recursively itterates and fill all replies per comment 
        /// </summary>
        /// <param name="comment">current comment</param>
        /// <param name="allreplies">all comments marked as "IsReply" per post</param>
        private void FillReplies(CommentViewModel comment, List<Core.Entities.Comment> allreplies)
        {
            if (!allreplies.Any(r => r.InReplyTo.Equals(comment.CommentId)))//no replies for this comment
                return;

            List<CommentViewModel> replies = allreplies.Where(r=>r.InReplyTo.Equals(comment.CommentId)).Select(x => CommentViewModelMapper.Map(x)).ToList();

            foreach (var item in replies)
            {
                FillReplies(item, allreplies);
            }

            comment.Replies = replies;
        }
    }
}
