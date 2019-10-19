using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TS.BlogSystem.Core.Common;
using TS.BlogSystem.Core.Interfaces.Services;
using TS.BlogSystem.Web.Mappers;
using TS.BlogSystem.Web.Models;

namespace TS.BlogSystem.Web.Controllers
{
    public class CommentsController : Controller
    {
        private readonly ICommentService _commentService;
        private readonly IPostService _postService;

        public CommentsController(ICommentService commentService, IPostService postService)
        {
            _commentService = commentService;
            _postService = postService;
        }

        public async Task<IActionResult> GetAll(Guid postId, int page = 0)
        {
            return ViewComponent("Comments", new { postId = postId, page = page });
        }

        public async Task<JsonResult> Add(CommentViewModel comment)
        {
            try
            {
                var post = await _postService.GetById(comment.PostId);
                if (post != null)
                    await _commentService.Insert(
                    new Core.Entities.Comment()
                    {
                        Content = comment.Content,
                        DateCreated = DateTime.Now,
                        Post = post,
                        IsReply = false,
                        Pending = true
                    }
                    );
            }
            catch (Exception ex)
            {
                Response.StatusCode = 500;
                return Json(new { error = ex.Message });
            }

            return Json(new { status = "Success", message = "All done!" });
        }
    }
}