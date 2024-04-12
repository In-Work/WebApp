using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;
using WebAppDB.Data;
using WebApp.Extensions;
using System.Collections.Generic;

namespace WebApp.Controllers
{
    public class CartController : Controller
    {
        private readonly ApplicationDbContext _context;
        private Cart _cart;

        public CartController(ApplicationDbContext context, Cart cart)
        {
            _context = context; 
            _cart = cart;
        }

        public IActionResult Index()
        {
            return View(_cart.Items.Values);
        }

        [Authorize]
        public IActionResult Add(int id, string returnUrl)
        {
            var item = _context.Dishes.Find(id);
            if (item != null)
            {
                _cart.AddToCart(item);
            }
            return Redirect(returnUrl);
        }
        public IActionResult Delete(int id)
        {
            _cart.RemoveFromCart(id);
            return RedirectToAction("Index");
        }

    }

}
