using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TS.BlogSystem.Core.Interfaces.Context;
using TS.BlogSystem.Core.Interfaces.Repository;
using TS.BlogSystem.Core.Interfaces.Services;
using TS.BlogSystem.Data.Context;
using TS.BlogSystem.Data.Repository;
using Microsoft.EntityFrameworkCore;
using TS.BlogSystem.Services;
using TS.BlogSystem.Core.Entities;
using Microsoft.AspNetCore.Identity;

namespace TS.BlogSystem.Web.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddServiceDependencies(IServiceCollection services)
        {
            services.AddDbContext<BlogContext>(options =>
                    options.UseInMemoryDatabase("EFInMemory"));

            services.AddScoped<IBlogContext, BlogContext>();
            services.AddScoped(typeof(IAsyncRepository<>), typeof(EfRepository<>));

            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ICommentService, CommentsService>();
            services.AddScoped<IPostService, PostsService>();
        }

        public static void AddCustomizedIdentity(IServiceCollection services)
        {
            services
                .AddIdentity<User, Role>(options =>
                {
                    options.Password.RequireDigit = false;
                    options.Password.RequiredLength = 4;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequiredUniqueChars = 0;
                })
                .AddRoleManager<RoleManager<Role>>()
                .AddEntityFrameworkStores<BlogContext>()
                .AddDefaultTokenProviders();

        }
    }
}
