using System;
using System.Collections.Generic;
using System.Text;
using TS.BlogSystem.Core.Entities;

namespace TS.BlogSystem.Core.Interfaces.Services
{
    public interface IPostService :IService<Post>, IPagedService<Post>
    {
    }
}
