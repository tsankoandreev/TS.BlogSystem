using System;
using System.Collections.Generic;
using System.Text;

namespace TS.BlogSystem.Core.Entities
{
    public class BlogUser : Entity
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Post> Posts { get; set; }
    }
}
