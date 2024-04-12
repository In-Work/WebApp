using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebAppDB.Entities;

namespace WebApp.Areas.Admin.Pages
{
    public class DeleteModel : PageModel
    {
        private readonly WebAppDB.Data.ApplicationDbContext _context;

        public DeleteModel(WebAppDB.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Dish Dish { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Dish = await _context.Dishes
                .Include(d => d.Group).FirstOrDefaultAsync(m => m.DishId == id);

            if (Dish == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Dish = await _context.Dishes.FindAsync(id);

            if (Dish != null)
            {
                _context.Dishes.Remove(Dish);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
