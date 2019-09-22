using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using TS.BlogSystem.Core.Entities;
using TS.BlogSystem.Core.Interfaces.Context;

namespace TS.BlogSystem.Data.Context
{
    public class BlogContext : IdentityDbContext<User, Role, Guid, IdentityUserClaim<Guid>, UserRole, IdentityUserLogin<Guid>, IdentityRoleClaim<Guid>, IdentityUserToken<Guid>>, IBlogContext
    {
        public BlogContext(DbContextOptions<BlogContext> options) : base(options)
        {
            BlogContextSeed.SeedAsync(this).Wait();
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Tag> Tags { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<Role>().ToTable("Roles");
            modelBuilder.Entity<UserRole>().ToTable("UserRoles");
            modelBuilder.Entity<IdentityUserLogin<Guid>>().ToTable("UserLogins");
            modelBuilder.Entity<IdentityUserToken<Guid>>().ToTable("UserTokens");
            modelBuilder.Entity<IdentityUserClaim<Guid>>().ToTable("UserClaims");
            modelBuilder.Entity<IdentityRoleClaim<Guid>>().ToTable("RoleClaims");

            modelBuilder.Entity<Category>().ToTable("Categories");
            modelBuilder.Entity<Comment>().ToTable("Comments");
            modelBuilder.Entity<Post>().ToTable("Posts");
            modelBuilder.Entity<Tag>().ToTable("Tags");

            modelBuilder.Entity<UserRole>(b =>
            {
                b.HasKey(ur => new { ur.UserId, ur.RoleId });
                b.HasOne(ur => ur.Role).WithMany(x => x.UserRoles).HasForeignKey(r => r.RoleId);
                b.HasOne(ur => ur.User).WithMany(x => x.UserRoles).HasForeignKey(u => u.UserId);
            });

            modelBuilder.Entity<IdentityUserLogin<Guid>>(b =>
            {
                b.HasKey(l => new { l.LoginProvider, l.ProviderKey, l.UserId });
            });

            modelBuilder.Entity<IdentityUserToken<Guid>>(b =>
            {
                b.HasKey(t => new { t.LoginProvider, t.Value, t.UserId });
            });
        }
    }
}
