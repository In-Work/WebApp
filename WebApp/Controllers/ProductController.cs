using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using WebApp.Extensions;
using WebApp.Models;
using WebAppDB.Data;
using WebAppDB.Entities;

namespace WebApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly int _pageSize;
        private readonly ApplicationDbContext _context;

        public ProductController(ApplicationDbContext context)
        {
            _pageSize = 3;
            _context = context;
        }

        [Route("Catalog")]
        [Route("Catalog/Page_{pageNo}")]
        public IActionResult Index(int? group, int pageNo = 1)
        {
            var dishesFiltered = _context.Dishes
                .Where(d => !group.HasValue || d.DishGroupId == group.Value);

            ViewData["Groups"] = _context.DishGroups;
            ViewData["CurrentGroup"] = group ?? 0;

            var model = ListViewModel<Dish>.GetModel(dishesFiltered, pageNo, _pageSize);
            var condition = Request.Headers["x-requested-with"]
                .ToString()
                .ToLower()
                .Equals("xmlhttprequest");

            if (Request.IsAjaxRequest())
            {
                return PartialView("_listpartial", model);
            }
            else
            {
                return View(model);
            }
        }
    }
}
