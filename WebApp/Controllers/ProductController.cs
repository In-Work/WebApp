using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WebAppDB.Entities;

namespace WebApp.Controllers
{
    public class ProductController : Controller
    {
        public List<Dish> _dishes;
        private List<DishGroup> _dishGroups;
        private int _pageSize;
        public ProductController()
        {
            _pageSize = 3;
            SetupData();
        }

        private void SetupData()
        {
            _dishGroups = new List<DishGroup>
            {
                new DishGroup {DishGroupId=1, GroupName="Стартеры"},
                new DishGroup {DishGroupId=2, GroupName="Салаты"},
                new DishGroup {DishGroupId=3, GroupName="Супы"},
                new DishGroup {DishGroupId=4, GroupName="Основные блюда"},
                new DishGroup {DishGroupId=5, GroupName="Напитки"},
                new DishGroup {DishGroupId=6, GroupName="Десерты"}
            };

            _dishes = new List<Dish>            {
                new Dish 
                {
                    DishId = 1, 
                    DishName="Суп-харчо",
                    Description="Очень острый, невкусный",
                    Calories =200, 
                    DishGroupId=3, 
                    Image="Суп.jpg" 
                },
                new Dish 
                { 
                    DishId = 2, 
                    DishName="Борщ",
                    Description="Много сала, без сметаны",
                    Calories =330,
                    DishGroupId=3,
                    Image="Борщ.jpg" 
                },
                new Dish 
                { 
                    DishId = 3, 
                    DishName="Котлета пожарская",
                    Description="Хлеб - 80%, Морковь - 20%",
                    Calories =635, 
                    DishGroupId=4, 
                    Image="Котлета.jpg" 
                },
                new Dish 
                { 
                    DishId = 4, 
                    DishName="Макароны по-флотски",
                    Description="С охотничьей колбаской",
                    Calories =524,
                    DishGroupId=4,
                    Image="Макароны.jpg" 
                },
                new Dish 
                { 
                    DishId = 5, 
                    DishName="Компот",
                    Description="Быстро растворимый, 2 литра",
                    Calories =180,
                    DishGroupId=5,
                    Image="Компот.jpg" 
                }
            };
        }

        public IActionResult Index(int pageNo = 1)
        {
            var items = _dishes
           .Skip((pageNo - 1) * _pageSize)
           .Take(_pageSize)
           .ToList();
            return View(items);
        }
    }
}
