using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppDB.Data;
using WebAppDB.Entities;

namespace WebApp.Services
{
    public static class DbInitializer
    {
        public static async Task Seed(ApplicationDbContext context, UserManager<ApplicationUser> userManager,RoleManager<IdentityRole> roleManager)
        {
            context.Database.EnsureCreated();

            if (!context.Roles.Any())
            {
                var roleAdmin = new IdentityRole
                {
                    Name = "admin",
                    NormalizedName = "admin"
                };

                await roleManager.CreateAsync(roleAdmin);
            }

            if (!context.Users.Any())
            {
                var user = new ApplicationUser
                {
                    Email = "user@mail.ru",
                    UserName = "user@mail.ru"
                };

                await userManager.CreateAsync(user, "123456");

                var admin = new ApplicationUser
                {
                    Email = "admin@mail.ru",
                    UserName = "admin@mail.ru"
                };

                await userManager.CreateAsync(admin, "123456");

                admin = await userManager.FindByEmailAsync("admin@mail.ru");

                await userManager.AddToRoleAsync(admin, "admin");
            }

            if (!context.DishGroups.Any())
            {
                context.DishGroups.AddRange(
                new List<DishGroup>
                {
                    new DishGroup {GroupName="Стартеры"},
                    new DishGroup {GroupName="Салаты"},
                    new DishGroup {GroupName="Супы"},
                    new DishGroup {GroupName="Основные блюда"},
                    new DishGroup {GroupName="Напитки"},
                    new DishGroup {GroupName="Десерты"}
                });

                await context.SaveChangesAsync();
            }

            if (!context.Dishes.Any())
            {
                context.Dishes.AddRange(
                new List<Dish>
                {
                    new Dish 
                    {
                        DishName="Суп-харчо",
                        Description="Очень острый, невкусный",
                        Calories =200, 
                        DishGroupId=3, 
                        Image="Суп.jpg" 
                    },
                    new Dish 
                    {
                        DishName="Борщ",
                        Description="Много сала, без сметаны",
                        Calories =330, 
                        DishGroupId=3,
                        Image="Борщ.jpg" 
                    },
                    new Dish 
                    {
                        DishName="Котлета пожарская",
                        Description="Хлеб - 80%, Морковь - 20%",
                        Calories =635,
                        DishGroupId=4,
                        Image="Котлета.jpg" 
                    },
                    new Dish 
                    {
                        DishName="Макароны по-флотски",
                        Description="С охотничьей колбаской",
                        Calories =524, 
                        DishGroupId=4,
                        Image="Макароны.jpg" 
                    },
                    new Dish 
                    {
                        DishName="Компот",
                        Description="Быстро растворимый, 2 литра",
                        Calories =180, 
                        DishGroupId=5, 
                        Image="Компот.jpg" 
                    }
                });

                await context.SaveChangesAsync();
            }


        }
    }
}
