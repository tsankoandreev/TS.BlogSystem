using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TS.BlogSystem.Core.Common;
using TS.BlogSystem.Core.Interfaces.Services;
using TS.BlogSystem.Web.Models;
using TS.BlogSystem.Web.Mappers;

namespace TS.BlogSystem.Web.Controllers
{
    public class PostsController : Controller
    {
        private readonly IPostService _postService;

        public PostsController(IPostService postService)
        {
            this._postService = postService;
        }

        public async Task<IActionResult> Get(Guid postId)
        {
            var model = await _postService.GetById(postId);
            var viewModel = PostViewModelMapper.Map(model);
            return View(viewModel);
        }
        public async Task<IActionResult> GetAll(int page = 0)
        {
            var posts = await _postService.GetPagedResult(page, 3);

            var viewModelsColl = new PagedList<PostViewModel>(posts.Select(x => PostViewModelMapper.Map(x)),
            posts.PageIndex, posts.PageSize, posts.ResultsCaunt, posts.TotalCaunt);

            return View(viewModelsColl);
        }
        public async Task<IActionResult> GetByCategory(Guid categoryId, int page = 1)
        {
            var posts = await _postService.GetPagedResult(page, 3, x => x.Category.Id == categoryId, x => x.Title);
            var viewModelsColl = new PagedList<PostViewModel>(
                posts.Select(x => PostViewModelMapper.Map(x)),
            posts.PageIndex, posts.PageSize, posts.ResultsCaunt, posts.TotalCaunt);

            return View("GetAll", viewModelsColl);
        }
    }
}