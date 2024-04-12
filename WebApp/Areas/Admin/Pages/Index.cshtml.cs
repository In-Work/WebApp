using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebAppDB.Entities;

namespace WebApp.Areas.Admin.Pages
{
    public class IndexModel : PageModel
    {
        private readonly WebAppDB.Data.ApplicationDbContext _context;

        public IndexModel(WebAppDB.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Dish> Dish { get;set; }

        public async Task OnGetAsync()
        {
            Dish = await _context.Dishes
                .Include(d => d.Group).ToListAsync();
        }
    }
}
