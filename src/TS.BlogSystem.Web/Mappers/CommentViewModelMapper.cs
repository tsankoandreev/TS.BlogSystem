using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TS.BlogSystem.Core.Entities;
using TS.BlogSystem.Web.Models;

namespace TS.BlogSystem.Web.Mappers
{
    public static class CommentViewModelMapper
    {
        public static CommentViewModel Map(Comment x)
        {
            return new CommentViewModel()
            {
                CommentId = x.Id,
                PostId = x.Post.Id, //all comments must be hooked to post
                Content = x.Content,
                DateCreated = x.DateCreated,
                IsReply = x.IsReply,
                InReplyTo = x.InReplyTo,
                DateEdited = x.DateEdited,
                Pending = x.Pending,
                Replies = new List<CommentViewModel>()
            };
        }
    }
}
