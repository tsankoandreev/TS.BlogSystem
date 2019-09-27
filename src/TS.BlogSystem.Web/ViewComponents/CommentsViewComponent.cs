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
        private readonly IPostService _postService;

        public CommentsViewComponent(ICommentService commentService, IPostService postService)
        {
            _commentService = commentService;
            _postService = postService;
        }

        public async Task<IViewComponentResult> InvokeAsync(Guid postId, int commentPage = 0)
        {
            var comments = await _commentService.GetPagedResult(commentPage, 10, x => x.Post.Id == postId && x.IsReply == false, x => x.DateCreated);
            var data = comments.ToList().Select(x => CommentViewModelMapper.Map(x));
            var commentsResult = new PagedList<CommentViewModel>(data, comments.PageIndex, comments.PageSize, comments.ResultsCaunt, comments.TotalCaunt);

            return await Task.FromResult((IViewComponentResult)View(commentsResult));
        }
    }
}
