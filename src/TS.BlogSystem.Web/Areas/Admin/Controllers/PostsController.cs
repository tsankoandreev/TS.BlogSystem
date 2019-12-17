using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TS.BlogSystem.Core.Entities;
using TS.BlogSystem.Core.Interfaces.Services;
using TS.BlogSystem.Data.Context;

namespace TS.BlogSystem.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PostsController : Controller
    {
        private readonly IPostService _postsService;
        private readonly ICategoryService _categoriesService;

        public PostsController(IPostService postsService, ICategoryService categoriesService)
        {
            _postsService = postsService;
            _categoriesService = categoriesService;
        }

        // GET: Admin/Posts
        public async Task<IActionResult> Index()
        {
            return View(await _postsService.GetAll());
        }

        // GET: Admin/Posts/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }


            var post = await _postsService.GetById(id.Value);
            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }

        // GET: Admin/Posts/Create
        public IActionResult Create()
        {
            PopulateCategoriesDropDownList();
            return View();
        }

        // POST: Admin/Posts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title,Content,DateCreated,DateEdited,IsPending,Id,CategoryId")] Post post)
        {
            if (ModelState.IsValid)
            {
                post.Id = Guid.NewGuid();
                await _postsService.Insert(post);
                return RedirectToAction(nameof(Index));
            }
            return View(post);
        }

        // GET: Admin/Posts/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = await _postsService.GetById(id.Value);
            if (post == null)
            {
                return NotFound();
            }

            PopulateCategoriesDropDownList(post.Category?.Id);
            return View(post);
        }

        // POST: Admin/Posts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Title,Content,DateCreated,DateEdited,IsPending,Id,CategoryId")] Post post)
        {
            if (id != post.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _postsService.Update(post);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PostExists(post.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            PopulateCategoriesDropDownList(post.Category?.Id);
            return View(post);
        }

        // GET: Admin/Posts/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = await _postsService.GetById(id.Value);
            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }

        // POST: Admin/Posts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var post = await _postsService.GetById(id);
            await _postsService.Delete(post);
            return RedirectToAction(nameof(Index));
        }

        private bool PostExists(Guid id)
        {
            return _postsService.GetById(id) != null;
        }

        private async void PopulateCategoriesDropDownList(object selectedCategory = null)
        {
            var allCategories = await _categoriesService.GetAll();
            ViewBag.Categories = new SelectList(allCategories, "Id", "Name", selectedCategory);
        }
    }
}
