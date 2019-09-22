using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TS.BlogSystem.Web.Models
{
    public class CommentViewModel
    {
        public Guid CommentId { get; set; }
        public Guid PostId { get; set; }

        public string Content { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime DateEdited { get; set; }

        public bool? Pending { get; set; }

        public bool IsReply { get; set; }
        public Guid? InReplyTo { get; set; }
        public List<CommentViewModel> Replies { get; set; }
    }
}
