using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TS.BlogSystem.Core.Entities;
using TS.BlogSystem.Web.Models;

namespace TS.BlogSystem.Web.Mappers
{
    public static class PostViewModelMapper
    {
        public static PostViewModel Map(Post x)
        {
            return new PostViewModel()
            {
                Id = x.Id,
                Title = x.Title,
                Content = x.Content,
                DateCreated = x.DateCreated,
            };
        }
    }
}
