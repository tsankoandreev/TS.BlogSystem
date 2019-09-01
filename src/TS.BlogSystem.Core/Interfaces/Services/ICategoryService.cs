using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TS.BlogSystem.Core.Entities;

namespace TS.BlogSystem.Core.Interfaces.Services
{
    public interface ICategoryService:IService<Category>,IPagedService<Category>
    {
    }
}
