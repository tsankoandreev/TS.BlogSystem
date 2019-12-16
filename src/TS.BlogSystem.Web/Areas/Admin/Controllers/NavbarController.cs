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
    public class NavbarController : Controller
    {
        private readonly INavigationService _navService;

        public NavbarController(INavigationService navService)
        {
            this._navService = navService;
        }

        // GET: Admin/Navbar
        public async Task<IActionResult> Index()
        {
            return View(await _navService.GetAll());
        }

        // GET: Admin/Navbar/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var navItem = await _navService.GetById(id.Value);
            if (navItem == null)
            {
                return NotFound();
            }

            return View(navItem);
        }

        // GET: Admin/Navbar/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Navbar/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Area,Controller,Action,IconClass,IsActive,IsParent,Id")] NavItem navItem)
        {
            if (ModelState.IsValid)
            {
                navItem.Id = Guid.NewGuid();
                await _navService.Insert(navItem);
                return RedirectToAction(nameof(Index));
            }
            return View(navItem);
        }

        // GET: Admin/Navbar/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var navItem = await _navService.GetById(id.Value);
            if (navItem == null)
            {
                return NotFound();
            }
            return View(navItem);
        }

        // POST: Admin/Navbar/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Name,Area,Controller,Action,IconClass,IsActive,IsParent,Id")] NavItem navItem)
        {
            if (id != navItem.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _navService.Update(navItem);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NavItemExists(navItem.Id))
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
            return View(navItem);
        }

        // GET: Admin/Navbar/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var navItem = await _navService.GetById(id.Value);
            if (navItem == null)
            {
                return NotFound();
            }

            return View(navItem);
        }

        // POST: Admin/Navbar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var navItem = await _navService.GetById(id);
            await _navService.Delete(navItem);
            return RedirectToAction(nameof(Index));
        }

        private bool NavItemExists(Guid id)
        {
            return _navService.GetById(id) != null ;
        }
    }
}
