using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebAppDB.Entities;

namespace WebApp.Areas.Admin.Pages
{
    public class CreateModel : PageModel
    {
        private readonly WebAppDB.Data.ApplicationDbContext _context;

        public CreateModel(WebAppDB.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["DishGroupId"] = new SelectList(_context.DishGroups, "DishGroupId", "DishGroupId");
            return Page();
        }

        [BindProperty]
        public Dish Dish { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Dishes.Add(Dish);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
