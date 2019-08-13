using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace TS.BlogSystem.Core.Entities
{
    public class Role : IdentityRole<Guid>
    {
        public IList<UserRole> Users { get; set; } = new List<UserRole>();
    }
}
