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
        public HomeController()
        {
           
        }
        public async Task<IActionResult> Index()
        {
            return View();
        }
    }
}