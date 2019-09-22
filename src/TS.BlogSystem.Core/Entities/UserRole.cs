using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace TS.BlogSystem.Core.Entities
{
    public class UserRole : IdentityUserRole<Guid>
    {
        public override Guid UserId { get; set; }

        public virtual User User { get; set; }

        public override Guid RoleId { get; set; }

        public virtual Role Role { get; set; }
    }
}
