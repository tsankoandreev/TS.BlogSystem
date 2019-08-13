using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace TS.BlogSystem.Core.Entities
{
    public class UserRole : IdentityUserRole<Guid>
    {
        public override Guid UserId { get; set; }

        public User User { get; set; }

        public override Guid RoleId { get; set; }

        public Role Role { get; set; }
    }
}
