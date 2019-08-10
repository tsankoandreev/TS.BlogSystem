using System;
using System.Collections.Generic;
using System.Text;

namespace TS.BlogSystem.Core.Entities
{
    public partial class Comment : Entity
    {
        public string Content { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateEdited { get; set; }
        public bool? Pending { get; set; }

        public bool IsReply { get; set; }
        public Guid? InReplyTo { get; set; }

        public virtual Post Post { get; set; }
        public virtual BlogUser Author { get; set; }
    }
}
