﻿using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebAppDB.Entities;

namespace WebApp.Areas.Admin.Pages
{
    public class CreateModel : PageModel
    {
        private readonly WebAppDB.Data.ApplicationDbContext _context;
        private readonly IWebHostEnvironment _environment;

        public CreateModel(WebAppDB.Data.ApplicationDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _environment = env;
        }

        public IActionResult OnGet()
        {
        ViewData["DishGroupId"] = new SelectList(_context.DishGroups, "DishGroupId", "DishGroupId", "GroupName");
            return Page();
        }

        [BindProperty]
        public Dish Dish { get; set; }

        [BindProperty]
        public IFormFile Image { get; set; }

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

            if (Image != null)
            {
                var fileName = $"{Dish.DishId}" + Path.GetExtension(Image.FileName);
                Dish.Image = fileName;
                var path = Path.Combine(_environment.WebRootPath, "Images", fileName);
                using (var fStream = new FileStream(path, FileMode.Create))
                {
                    await Image.CopyToAsync(fStream);
                }
                await _context.SaveChangesAsync();
            }


            return RedirectToPage("./Index");
        }
    }
}
