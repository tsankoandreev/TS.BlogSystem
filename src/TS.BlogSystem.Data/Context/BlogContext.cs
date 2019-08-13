using Microsoft.EntityFrameworkCore;
using TS.BlogSystem.Core.Entities;
using TS.BlogSystem.Core.Interfaces.Context;

namespace TS.BlogSystem.Data.Context
{
    public class BlogContext : DbContext, IBlogContext
    {
        public BlogContext(DbContextOptions<BlogContext> options) : base(options)
        {
            BlogContextSeed.SeedAsync(this).Wait();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Tag> Tags { get; set; }

    }
}
