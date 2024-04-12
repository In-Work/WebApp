using System.Collections.Generic;
using System.Linq;
using WebAppDB.Entities;

namespace WebApp.Models
{
    public class Cart
    {
        public Dictionary<int, CartItem> Items { get; set; }
        public Cart()
        {
            Items = new Dictionary<int, CartItem>();
        }

        public int Count
        {
            get
            {
                return Items.Sum(item => item.Value.Quantity);
            }
        }

        public int Calories
        {
            get
            {
                return Items.Sum(item => item.Value.Quantity * item.Value.Dish.Calories);
            }
        }

        public virtual void AddToCart(Dish dish)
        {
            if (Items.ContainsKey(dish.DishId))
            {
                Items[dish.DishId].Quantity++;
            }
            else
            {
                Items.Add(dish.DishId, new CartItem
                {
                    Dish = dish,
                    Quantity = 1
                });
            }
        }

        public virtual void RemoveFromCart(int id)
        {
            Items.Remove(id);
        }

        public virtual void ClearAll()
        {
            Items.Clear();
        }
    }

    public class CartItem
    {
        public Dish Dish { get; set; }
        public int Quantity { get; set; }
    }
}
