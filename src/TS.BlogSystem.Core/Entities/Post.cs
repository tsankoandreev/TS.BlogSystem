using System;
using System.Collections.Generic;
using System.Text;

namespace TS.BlogSystem.Core.Entities
{
    public class Post : Entity
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateEdited { get; set; }

        public bool? IsPending { get; set; }

        public virtual Category Category { get; set; }
        public virtual BlogUser Author { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}
