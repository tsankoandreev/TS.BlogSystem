using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TS.BlogSystem.Core.Common;
using TS.BlogSystem.Core.Interfaces.Services;
using TS.BlogSystem.Web.Models;

namespace TS.BlogSystem.Web.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            this._categoryService = categoryService;
        }

        public async Task<IActionResult> GetAll(int page =1)
        {
            var categories = await _categoryService.GetPagedResult(page, 3);

            var viewModelsColl = new PagedList<CategoryViewModel>(
                categories.Select(x => new CategoryViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                }),
            categories.PageIndex, categories.PageSize, categories.ResultsCaunt, categories.TotalCaunt);

            return View(viewModelsColl);
        }
    }
}