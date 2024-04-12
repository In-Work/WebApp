using WebAppDB.Data;
using WebAppDB.Entities;

namespace WebApp.Test
{
    internal static class TestData
    {
        public static List<Dish> GetDishesList()
        {
            return new List<Dish>
            {
                new Dish{ DishId = 1, DishGroupId = 1},
                new Dish{ DishId = 2, DishGroupId = 1},
                new Dish{ DishId = 3, DishGroupId = 2},
                new Dish{ DishId = 4, DishGroupId = 2},
                new Dish{ DishId = 5, DishGroupId = 3}
            };
        }

        public static IEnumerable<object[]> Params()
        {
            yield return new object[] { 1, 3, 1 };
            yield return new object[] { 2, 2, 4 };
        }

        public static void FillContext(ApplicationDbContext context)
        {
            context.DishGroups.Add(new DishGroup{ GroupName = "fake group" });

            context.AddRange(new List<Dish>
            {
                new Dish{ DishId=1, DishGroupId=1},
                new Dish{ DishId=2, DishGroupId=1},
                new Dish{ DishId=3, DishGroupId=2},
                new Dish{ DishId=4, DishGroupId=2},
                new Dish{ DishId=5, DishGroupId=3}
            });

            context.SaveChanges();
        }

    }

}
