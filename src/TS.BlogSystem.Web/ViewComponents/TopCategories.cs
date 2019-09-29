using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using TS.BlogSystem.Core.Interfaces.Services;
using TS.BlogSystem.Web.Models;

namespace TS.BlogSystem.Web.ViewComponents
{
    public class TopCategories : ViewComponent
    {
        private readonly ICategoryService _categoryService;

        public TopCategories(ICategoryService categoryService)
        {
            this._categoryService = categoryService;
        }
        public async Task<IViewComponentResult> InvokeAsync(int numberToTake)
        {
            var categories = await _categoryService.GetAll();
            var result = categories.Take(numberToTake).Select(x => new CategoryViewModel()
            {
                Id = x.Id,
                Name = x.Name,
            }).ToList();

            return await Task.FromResult((IViewComponentResult)View(result));
        }
    }
}
