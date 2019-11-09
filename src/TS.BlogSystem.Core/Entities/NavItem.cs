using System;
using System.Collections.Generic;
using System.Text;

namespace TS.BlogSystem.Core.Entities
{
    public partial class NavItem : Entity
    {
        public string Name { get; set; }
        public string Area { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }

        public string IconClass { get; set; }

        public bool IsActive { get; set; }
        public bool IsParent { get; set; } = true;

        public virtual NavItem Parent { get; set; }

    }
}
