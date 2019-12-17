using System;
using System.Collections.Generic;
using System.Text;

namespace TS.BlogSystem.Core.Entities
{
    public partial class Category : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsLocked { get; set; }
        public DateTime DateCreated { get; set; }

        public Guid? ParentCategoryId { get; set; }
        public virtual Category ParentCategory { get; set; }

        public virtual ICollection<Post> Posts { get; set; }
    }
}
