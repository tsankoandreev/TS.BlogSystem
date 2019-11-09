using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TS.BlogSystem.Core.Interfaces.Services;

namespace TS.BlogSystem.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly INavigationService _navService;

        public HomeController(INavigationService navService)
        {
            this._navService = navService;
        }
        public async  Task<IActionResult> Index()
        {
            return View( await _navService.GetAll());
        }
    }
}