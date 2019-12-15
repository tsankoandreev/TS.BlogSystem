using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using TS.BlogSystem.Core.Interfaces.Services;
using TS.BlogSystem.Web.Models;

namespace TS.BlogSystem.Web.ViewComponents
{
    public class TopNavViewComponent : ViewComponent
    {
        public Task<IViewComponentResult> InvokeAsync()
        {
            return Task.FromResult<IViewComponentResult>(View());
        }
    }
}
