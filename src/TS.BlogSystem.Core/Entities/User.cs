using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace TS.BlogSystem.Core.Entities
{
    public class User : IdentityUser<Guid>
    {

        public virtual ICollection<Post> Posts { get; set; }
    }
}
