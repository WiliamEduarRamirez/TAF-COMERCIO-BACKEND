using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class Seed
    {
        public static async Task SeedData(DataContext context, UserManager<AppUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            if (!(await roleManager.Roles.AnyAsync()))
            {
                await roleManager.CreateAsync(new IdentityRole("admin"));
                await roleManager.CreateAsync(new IdentityRole("customer"));
            }

            if (!(await userManager.Users.AnyAsync()))
            {
                var users = new List<AppUser>()
                {
                    new AppUser {DisplayName = "Wiliam", UserName = "wiliam", Email = "wiliam@gmail.com"},
                    new AppUser {DisplayName = "admin", UserName = "admin", Email = "admin@gmail.com"},
                    /*new AppUser {DisplayName = "userTest", UserName = "userTest", Email = "userTest@gmail.com"},*/
                };
                foreach (var user in users)
                {
                    await userManager.CreateAsync(user, "P@ssword1998");
                }

                /*var roleCustomer = await roleManager.FindByNameAsync("customer");
                var roleAdmin = await roleManager.FindByNameAsync("admin");*/

                await userManager.AddToRoleAsync(users[0], "customer");
                await userManager.AddToRoleAsync(users[1], "admin");
                /*await userManager.AddToRoleAsync(users[4], "customer");
                await userManager.AddToRoleAsync(users[4], "admin");*/
            }

            if (!(await context.Types.AnyAsync()) && !(await context.Categories.AnyAsync()))
            {
                var listTypes = new List<string> {"Sofas", "Mesas", "Sillas", "Camas", "Escritorios", "Colchones"};
                var listCategories = new List<string>
                {
                    "SofasCategory", "MesasCategory", "SillasCategory", "CamasCategory", "EscritoriosCategory",
                    "ColchonesCategory"
                };
                var listMarks = new List<string>
                    {"SofasMark", "MesasMark", "SillasMark", "CamasMark", "EscritoriosMark", "ColchonesMark"};

                var types = new List<Type>();
                var categories = new List<Category>();

                foreach (var listType in listTypes)
                {
                    var type = new Type
                    {
                        Denomination = listType,
                        Description = listType,
                    };
                    types.Add(type);
                }

                for (var i = listCategories.Count - 1; i >= 0; i--)
                {
                    var category = new Category
                    {
                        Denomination = listCategories[i],
                        Description = listCategories[i],
                        Type = types[i]
                    };
                    categories.Add(category);
                }
                /*foreach (var listCategory in listCategories)
                {
                    var category = new Category
                    {
                        Denomination = listCategory,
                        Description = listCategory,
                        Type = types[]
                    };
                    categories.Add(category);
                }*/

                await context.Types.AddRangeAsync(types);
                await context.Categories.AddRangeAsync(categories);
                await context.SaveChangesAsync();
            }
        }
    }
}