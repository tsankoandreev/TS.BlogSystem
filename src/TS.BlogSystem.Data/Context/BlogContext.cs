using Microsoft.EntityFrameworkCore;
using TS.BlogSystem.Core.Entities;
using TS.BlogSystem.Core.Interfaces.Context;

namespace TS.BlogSystem.Data.Context
{
    public class BlogContext : DbContext, IBlogContext
    {
        public BlogContext(DbContextOptions<BlogContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Tag> Tags { get; set; }

    }
}
