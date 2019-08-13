using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TS.BlogSystem.Core.Entities;

namespace TS.BlogSystem.Data.Context
{
    public class BlogContextSeed
    {
        public static async Task SeedAsync(BlogContext blogContext, int? retry = 0)
        {
            int retryForAvailability = retry.Value;
            try
            {
                List<Category> categories = SeedCategories();
                List<Post> posts = SeedPosts(categories);
                var tags = new List<Tag>()
            {
                new Tag { Text = "Golden" },
                new Tag { Text = "Pineapple" },
                new Tag { Text = "Girlscout" },
                new Tag { Text = "Cookies" }
            };

                List<Role> roles = new List<Role>(){
               new Role { Id = Guid.NewGuid(), ConcurrencyStamp = "4776a1b2-dbe4-4056-82ec-8bed211d1454", Name = "admin", NormalizedName = "ADMIN" },
               new Role { Id = Guid.NewGuid(), ConcurrencyStamp = "00d172be-03a0-4856-8b12-26d63fcf4374", Name = "customer", NormalizedName = "CUSTOMER" },
               new Role { Id = Guid.NewGuid(), ConcurrencyStamp = "d4754388-8355-4018-b728-218018836817", Name = "guest", NormalizedName = "GUEST" },
               new Role { Id = Guid.NewGuid(), ConcurrencyStamp = "71f10604-8c4d-4a7d-ac4a-ffefb11cefeb", Name = "vendor", NormalizedName = "VENDOR" }
                };

                List<User> users = new List<User>(){
                    new User { Id = Guid.NewGuid(), AccessFailedCount = 0, ConcurrencyStamp = "101cd6ae-a8ef-4a37-97fd-04ac2dd630e4",  LockoutEnabled = false, NormalizedEmail = "SYSTEM@SIMPLCOMMERCE.COM", NormalizedUserName = "SYSTEM@SIMPLCOMMERCE.COM", PasswordHash = "AQAAAAEAACcQAAAAEAEqSCV8Bpg69irmeg8N86U503jGEAYf75fBuzvL00/mr/FGEsiUqfR0rWBbBUwqtw==", PhoneNumberConfirmed = false, SecurityStamp = "a9565acb-cee6-425f-9833-419a793f5fba", TwoFactorEnabled = false,  UserName = "system@blogsystem.com" },
                    new User { Id = Guid.NewGuid(), AccessFailedCount = 0, ConcurrencyStamp = "c83afcbc-312c-4589-bad7-8686bd4754c0", LockoutEnabled = false, NormalizedEmail = "ADMIN@SIMPLCOMMERCE.COM", NormalizedUserName = "ADMIN@SIMPLCOMMERCE.COM", PasswordHash = "AQAAAAEAACcQAAAAEAEqSCV8Bpg69irmeg8N86U503jGEAYf75fBuzvL00/mr/FGEsiUqfR0rWBbBUwqtw==", PhoneNumberConfirmed = false, SecurityStamp = "d6847450-47f0-4c7a-9fed-0c66234bf61f", TwoFactorEnabled = false,    UserName = "admin@blogsystem.com" }
                };

                List<UserRole> userRoles = new List<UserRole>(){
                    new UserRole { UserId = users[0].Id, RoleId = roles[0].Id }
                };

                if (!blogContext.Users.Any())
                {
                    blogContext.Users.AddRange(
                        users);

                    await blogContext.SaveChangesAsync();
                }
                if (!blogContext.Roles.Any())
                {
                    blogContext.Roles.AddRange(
                        roles);

                    await blogContext.SaveChangesAsync();
                }
                if (!blogContext.UserRoles.Any())
                {
                    blogContext.UserRoles.AddRange(
                        userRoles);

                    await blogContext.SaveChangesAsync();
                }

                if (!blogContext.Categories.Any())
                {
                    blogContext.Categories.AddRange(
                        categories);

                    await blogContext.SaveChangesAsync();
                }

                if (!blogContext.Posts.Any())
                {
                    blogContext.Posts.AddRange(
                        posts);

                    await blogContext.SaveChangesAsync();
                }

                if (!blogContext.Tags.Any())
                {
                    blogContext.Tags.AddRange(
                       tags);

                    await blogContext.SaveChangesAsync();
                }

            }
            catch (Exception ex)
            {
                if (retryForAvailability < 10)
                {
                    retryForAvailability++;
                    await SeedAsync(blogContext, retryForAvailability);
                }
            }
        }

        #region seed methods

        private static List<Post> SeedPosts(List<Category> categories)
        {
            var posts = new List<Post>()
            {
                new Post { Title = "Best Boutiques on the Eastside"},
                new Post { Title = "Avoiding over-priced Hipster joints"},
                new Post { Title = "Where to buy Mars Bars"},
                new Post { Title = "Best Boutiques on the Eastside2"},
                new Post { Title = "Avoiding over-priced Hipster joints2" },
                new Post { Title = "Where to buy Mars Bars2"},
                new Post { Title = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit." },
                new Post { Title = "Aenean commodo ligula eget dolor." },
                new Post { Title = "Aenean massa." },
                new Post { Title = "Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus." },
                new Post { Title = "Donec quam felis, ultricies nec, pellentesque eu, pretium quis, sem." },
                new Post { Title = "Nulla consequat massa quis enim." },
                new Post { Title = "Donec pede justo, fringilla vel, aliquet nec, vulputate eget, arcu." },
                new Post { Title = "In enim justo, rhoncus ut, imperdiet a, venenatis vitae, justo." },
                new Post { Title = "Nullam dictum felis eu pede mollis pretium." },
                new Post { Title = "Integer tincidunt." },
                new Post { Title = "Cras dapibus." },
                new Post { Title = "Vivamus elementum semper nisi." },
                new Post { Title = "Aenean vulputate eleifend tellus." },
                new Post { Title = "Aenean leo ligula, porttitor eu, consequat vitae, eleifend ac, enim." },
                new Post { Title = "Aliquam lorem ante, dapibus in, viverra quis, feugiat a, tellus." },
                new Post { Title = "Phasellus viverra nulla ut metus varius laoreet." },
                new Post { Title = "Quisque rutrum." },
                new Post { Title = "Aenean imperdiet." },
                new Post { Title = "Etiam ultricies nisi vel augue." },
                new Post { Title = "Curabitur ullamcorper ultricies nisi." },
                new Post { Title = "Nam eget dui." },
                new Post { Title = "Etiam rhoncus." },
                new Post { Title = "2222 Maecenas tempus, tellus eget condimentum rhoncus, sem quam semper libero, sit amet adipiscing sem neque sed ipsum." },
                new Post { Title = "2222 Best Boutiques on the Eastside"},
                new Post { Title = "2222 Avoiding over-priced Hipster joints"},
                new Post { Title = "2222 Where to buy Mars Bars"},
                new Post { Title = "2222 Best Boutiques on the Eastside2"},
                new Post { Title = "2222 Avoiding over-priced Hipster joints2" },
                new Post { Title = "2222 Where to buy Mars Bars2"},
                new Post { Title = "2222 Lorem ipsum dolor sit amet, consectetuer adipiscing elit." },
                new Post { Title = "2222 Aenean commodo ligula eget dolor." },
                new Post { Title = "2222 Aenean massa." },
                new Post { Title = "2222 Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus." },
                new Post { Title = "2222 Donec quam felis, ultricies nec, pellentesque eu, pretium quis, sem." },
                new Post { Title = "2222 Nulla consequat massa quis enim." },
                new Post { Title = "2222 Donec pede justo, fringilla vel, aliquet nec, vulputate eget, arcu." },
                new Post { Title = "2222 In enim justo, rhoncus ut, imperdiet a, venenatis vitae, justo." },
                new Post { Title = "2222 Nullam dictum felis eu pede mollis pretium." },
                new Post { Title = "2222 Integer tincidunt." },
                new Post { Title = "2222 Cras dapibus." },
                new Post { Title = "2222 Vivamus elementum semper nisi." },
                new Post { Title = "2222 Aenean vulputate eleifend tellus." },
                new Post { Title = "2222 Aenean leo ligula, porttitor eu, consequat vitae, eleifend ac, enim." },
                new Post { Title = "2222 Aliquam lorem ante, dapibus in, viverra quis, feugiat a, tellus." },
                new Post { Title = "2222 Phasellus viverra nulla ut metus varius laoreet." },
                new Post { Title = "2222 Quisque rutrum." },
                new Post { Title = "2222 Aenean imperdiet." },
                new Post { Title = "2222 Etiam ultricies nisi vel augue." },
                new Post { Title = "2222 Curabitur ullamcorper ultricies nisi." },
                new Post { Title = "2222 Nam eget dui." },
                new Post { Title = "2222 Etiam rhoncus." },
                new Post { Title = "2222 Maecenas tempus, tellus eget condimentum rhoncus, sem quam semper libero, sit amet adipiscing sem neque sed ipsum." },
                new Post { Title = "3333 Best Boutiques on the Eastside"},
                new Post { Title = "3333 Avoiding over-priced Hipster joints"},
                new Post { Title = "3333 Where to buy Mars Bars"},
                new Post { Title = "3333 Best Boutiques on the Eastside2"},
                new Post { Title = "3333 Avoiding over-priced Hipster joints2" },
                new Post { Title = "3333 Where to buy Mars Bars2"},
                new Post { Title = "3333 Lorem ipsum dolor sit amet, consectetuer adipiscing elit." },
                new Post { Title = "3333 Aenean commodo ligula eget dolor." },
                new Post { Title = "3333 Aenean massa." },
                new Post { Title = "3333 Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus." },
                new Post { Title = "3333 Donec quam felis, ultricies nec, pellentesque eu, pretium quis, sem." },
                new Post { Title = "3333 Nulla consequat massa quis enim." },
                new Post { Title = "3333 Donec pede justo, fringilla vel, aliquet nec, vulputate eget, arcu." },
                new Post { Title = "3333 In enim justo, rhoncus ut, imperdiet a, venenatis vitae, justo." },
                new Post { Title = "3333 Nullam dictum felis eu pede mollis pretium." },
                new Post { Title = "3333 Integer tincidunt." },
                new Post { Title = "3333 Cras dapibus." },
                new Post { Title = "3333 Vivamus elementum semper nisi." },
                new Post { Title = "3333 Aenean vulputate eleifend tellus." },
                new Post { Title = "3333 Aenean leo ligula, porttitor eu, consequat vitae, eleifend ac, enim." },
                new Post { Title = "3333 Aliquam lorem ante, dapibus in, viverra quis, feugiat a, tellus." },
                new Post { Title = "3333 Phasellus viverra nulla ut metus varius laoreet." },
                new Post { Title = "3333 Quisque rutrum." },
                new Post { Title = "3333 Aenean imperdiet." },
                new Post { Title = "3333 Etiam ultricies nisi vel augue." },
                new Post { Title = "3333 Curabitur ullamcorper ultricies nisi." },
                new Post { Title = "3333 Nam eget dui." },
                new Post { Title = "3333 Etiam rhoncus." },
                new Post { Title = "3333 Maecenas tempus, tellus eget condimentum rhoncus, sem quam semper libero, sit amet adipiscing sem neque sed ipsum." },
                new Post { Title = "4444 Best Boutiques on the Eastside"},
                new Post { Title = "4444 Avoiding over-priced Hipster joints"},
                new Post { Title = "4444 Where to buy Mars Bars"},
                new Post { Title = "4444 Best Boutiques on the Eastside2"},
                new Post { Title = "4444 Avoiding over-priced Hipster joints2" },
                new Post { Title = "4444 Where to buy Mars Bars2"},
                new Post { Title = "4444 Lorem ipsum dolor sit amet, consectetuer adipiscing elit." },
                new Post { Title = "4444 Aenean commodo ligula eget dolor." },
                new Post { Title = "4444 Aenean massa." },
                new Post { Title = "4444 Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus." },
                new Post { Title = "4444 Donec quam felis, ultricies nec, pellentesque eu, pretium quis, sem." },
                new Post { Title = "4444 Nulla consequat massa quis enim." },
                new Post { Title = "4444 Donec pede justo, fringilla vel, aliquet nec, vulputate eget, arcu." },
                new Post { Title = "4444 In enim justo, rhoncus ut, imperdiet a, venenatis vitae, justo." },
                new Post { Title = "4444 Nullam dictum felis eu pede mollis pretium." },
                new Post { Title = "4444 Integer tincidunt." },
                new Post { Title = "4444 Cras dapibus." },
                new Post { Title = "4444 Vivamus elementum semper nisi." },
                new Post { Title = "4444 Aenean vulputate eleifend tellus." },
                new Post { Title = "4444 Aenean leo ligula, porttitor eu, consequat vitae, eleifend ac, enim." },
                new Post { Title = "4444 Aliquam lorem ante, dapibus in, viverra quis, feugiat a, tellus." },
                new Post { Title = "4444 Phasellus viverra nulla ut metus varius laoreet." },
                new Post { Title = "4444 Quisque rutrum." },
                new Post { Title = "4444 Aenean imperdiet." },
                new Post { Title = "4444 Etiam ultricies nisi vel augue." },
                new Post { Title = "4444 Curabitur ullamcorper ultricies nisi." },
                new Post { Title = "4444 Nam eget dui." },
                new Post { Title = "4444 Etiam rhoncus." },
                new Post { Title = "4444 Maecenas tempus, tellus eget condimentum rhoncus, sem quam semper libero, sit amet adipiscing sem neque sed ipsum." },
                new Post { Title = "5555 Best Boutiques on the Eastside"},
                new Post { Title = "5555 Avoiding over-priced Hipster joints"},
                new Post { Title = "5555 Where to buy Mars Bars"},
                new Post { Title = "5555 Best Boutiques on the Eastside2"},
                new Post { Title = "5555 Avoiding over-priced Hipster joints2" },
                new Post { Title = "5555 Where to buy Mars Bars2"},
                new Post { Title = "5555 Lorem ipsum dolor sit amet, consectetuer adipiscing elit." },
                new Post { Title = "5555 Aenean commodo ligula eget dolor." },
                new Post { Title = "5555 Aenean massa." },
                new Post { Title = "5555 Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus." },
                new Post { Title = "5555 Donec quam felis, ultricies nec, pellentesque eu, pretium quis, sem." },
                new Post { Title = "5555 Nulla consequat massa quis enim." },
                new Post { Title = "5555 Donec pede justo, fringilla vel, aliquet nec, vulputate eget, arcu." },
                new Post { Title = "5555 In enim justo, rhoncus ut, imperdiet a, venenatis vitae, justo." },
                new Post { Title = "5555 Nullam dictum felis eu pede mollis pretium." },
                new Post { Title = "5555 Integer tincidunt." },
                new Post { Title = "5555 Cras dapibus." },
                new Post { Title = "5555 Vivamus elementum semper nisi." },
                new Post { Title = "5555 Aenean vulputate eleifend tellus." },
                new Post { Title = "5555 Aenean leo ligula, porttitor eu, consequat vitae, eleifend ac, enim." },
                new Post { Title = "5555 Aliquam lorem ante, dapibus in, viverra quis, feugiat a, tellus." },
                new Post { Title = "5555 Phasellus viverra nulla ut metus varius laoreet." },
                new Post { Title = "5555 Quisque rutrum." },
                new Post { Title = "5555 Aenean imperdiet." },
                new Post { Title = "5555 Etiam ultricies nisi vel augue." },
                new Post { Title = "5555 Curabitur ullamcorper ultricies nisi." },
                new Post { Title = "5555 Nam eget dui." },
                new Post { Title = "5555 Etiam rhoncus." },
                new Post { Title = "5555 Maecenas tempus, tellus eget condimentum rhoncus, sem quam semper libero, sit amet adipiscing sem neque sed ipsum." },
                new Post { Title = "6666 Best Boutiques on the Eastside"},
                new Post { Title = "6666 Avoiding over-priced Hipster joints"},
                new Post { Title = "6666 Where to buy Mars Bars"},
                new Post { Title = "6666 Best Boutiques on the Eastside2"},
                new Post { Title = "6666 Avoiding over-priced Hipster joints2" },
                new Post { Title = "6666 Where to buy Mars Bars2"},
                new Post { Title = "6666 Lorem ipsum dolor sit amet, consectetuer adipiscing elit." },
                new Post { Title = "6666 Aenean commodo ligula eget dolor." },
                new Post { Title = "6666 Aenean massa." },
                new Post { Title = "6666 Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus." },
                new Post { Title = "6666 Donec quam felis, ultricies nec, pellentesque eu, pretium quis, sem." },
                new Post { Title = "6666 Nulla consequat massa quis enim." },
                new Post { Title = "6666 Donec pede justo, fringilla vel, aliquet nec, vulputate eget, arcu." },
                new Post { Title = "6666 In enim justo, rhoncus ut, imperdiet a, venenatis vitae, justo." },
                new Post { Title = "6666 Nullam dictum felis eu pede mollis pretium." },
                new Post { Title = "6666 Integer tincidunt." },
                new Post { Title = "6666 Cras dapibus." },
                new Post { Title = "6666 Vivamus elementum semper nisi." },
                new Post { Title = "6666 Aenean vulputate eleifend tellus." },
                new Post { Title = "6666 Aenean leo ligula, porttitor eu, consequat vitae, eleifend ac, enim." },
                new Post { Title = "6666 Aliquam lorem ante, dapibus in, viverra quis, feugiat a, tellus." },
                new Post { Title = "6666 Phasellus viverra nulla ut metus varius laoreet." },
                new Post { Title = "6666 Quisque rutrum." },
                new Post { Title = "6666 Aenean imperdiet." },
                new Post { Title = "6666 Etiam ultricies nisi vel augue." },
                new Post { Title = "6666 Curabitur ullamcorper ultricies nisi." },
                new Post { Title = "6666 Nam eget dui." },
                new Post { Title = "6666 Etiam rhoncus." },
                new Post { Title = "6666 Maecenas tempus, tellus eget condimentum rhoncus, sem quam semper libero, sit amet adipiscing sem neque sed ipsum." },
            };

            //hook random categories
            Random rand = new Random();
            foreach (var post in posts)
            {
                var comments = new List<Comment>()
                {
                    new Comment() { Content = "1sssssssssssss sdasdsad ssdsda"},
                    new Comment() { Content = "2sssssssssssss sdasdsad ssdsda"},
                    new Comment() { Content = "3sssssssssssss sdasdsad ssdsda"},
                    new Comment() { Content = "4sssssssssssss sdasdsad ssdsda"},
                    new Comment() { Content = "5sssssssssssss sdasdsad ssdsda"},
                    new Comment() { Content = "6sssssssssssss sdasdsad ssdsda"},
                    new Comment() { Content = "7sssssssssssss sdasdsad ssdsda"},
                    new Comment() { Content = "8sssssssssssss sdasdsad ssdsda"},
                    new Comment() { Content = "9sssssssssssss sdasdsad ssdsda"},
                    new Comment() { Content = "111111111 ssssss sss dddd dsss"},
                    new Comment() { Content = "222222222 ssssss sss dddd dsss"},
                    new Comment() { Content = "333333333 ssssss sss dddd dsss"},
                    new Comment() { Content = "444444444 ssssss sss dddd dsss"},
                    new Comment() { Content = "555555555 ssssss sss dddd dsss"},
                    new Comment() { Content = "666666666 ssssss sss dddd dsss"},
                    new Comment() { Content = "777777777 ssssss sss dddd dsss"},
                    new Comment() { Content = "888888888 ssssss sss dddd dsss"},
                    new Comment() { Content = "999999999 ssssss sss dddd dsss"},
                    new Comment() { Content = "0000000000000 sda dss ssss   sdsdasd"},
                    new Comment() { Content = "3262652745724 sda dss ssss   sdsdasd7" }
                };
                post.Category = categories[rand.Next(0, 19)];
                post.Comments = comments;
            }

            return posts;
        }


        private static List<Category> SeedCategories()
        {
            var categories = new List<Category>()
            {
                new Category() { Name = "Cat Azure"},
                new Category() { Name = "Cat .NET" },
                new Category() { Name = "Cat Visual Studio" },
                new Category() { Name = "Cat SQL Server" },
                new Category() { Name = "Cat Other" },
                new Category() { Name = "Cat Azure2"},
                new Category() { Name = "Cat .NET2" },
                new Category() { Name = "Cat Visual Studio2" },
                new Category() { Name = "Cat SQL Server2" },
                new Category() { Name = "Cat Other2" },
                new Category() { Name = "Cat Azure3"},
                new Category() { Name = "Cat .NET3" },
                new Category() { Name = "Cat Visual Studio3" },
                new Category() { Name = "Cat SQL Server3" },
                new Category() { Name = "Cat Other3" },
                new Category() { Name = "Cat Azure4"},
                new Category() { Name = "Cat .NET4" },
                new Category() { Name = "Cat Visual Studio4" },
                new Category() { Name = "Cat SQL Server4" },
                new Category() { Name = "Cat Other4" },
            };
            return categories;
        }
        #endregion
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
