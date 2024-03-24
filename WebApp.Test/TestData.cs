using WebAppDB.Entities;

namespace WebApp.Test
{
    internal static class TestData
    {
        public static List<Dish> GetDishesList()
        {
            return new List<Dish>
            {
                new Dish{ DishId = 1 },
                new Dish{ DishId = 2 },
                new Dish{ DishId = 3 },
                new Dish{ DishId = 4 },
                new Dish{ DishId = 5 }
            };
        }

        public static IEnumerable<object[]> Params()
        {
            yield return new object[] { 1, 3, 1 };
            yield return new object[] { 2, 2, 4 };
        }
    }

}
