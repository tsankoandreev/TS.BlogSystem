using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TS.BlogSystem.Core.Interfaces.Services;
using TS.BlogSystem.Web.Models;

namespace TS.BlogSystem.Web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            this._categoryService = categoryService;
        }

        public IActionResult GetAll()
        {
            var categories = _categoryService.GetAll();

            var viewModelsColl = categories.Select(x => new CategoryViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                }).ToList();

            return View(viewModelsColl);
        }
    }
}