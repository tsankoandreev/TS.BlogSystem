using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TS.BlogSystem.Web.Models
{
    public class PostViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
