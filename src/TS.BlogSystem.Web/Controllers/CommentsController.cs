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
            return ViewComponent("Comments", new { postId = postId,page = page });
        }
    }
}