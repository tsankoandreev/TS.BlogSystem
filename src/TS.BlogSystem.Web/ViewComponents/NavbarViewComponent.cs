using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using TS.BlogSystem.Core.Interfaces.Services;
using TS.BlogSystem.Web.Models;

namespace TS.BlogSystem.Web.ViewComponents
{
    public class NavbarViewComponent : ViewComponent
    {
        private readonly INavigationService _navService;

        public NavbarViewComponent(INavigationService navService)
        {
            this._navService = navService;
        }
        public async Task<IViewComponentResult> InvokeAsync(int numberToTake)
        {
            var navItems = await _navService.GetAll();

            return await Task.FromResult((IViewComponentResult)View(navItems));
        }
    }
}
