using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using TS.BlogSystem.Core.Utilities;

namespace TS.BlogSystem.Core.Entities
{
    public class Role : IdentityRole<Guid>
    {
        public Role()
        {
            Id = GuidUtils.GenerateComb();
        }
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
