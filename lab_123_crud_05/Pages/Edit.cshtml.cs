using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using lab_123_crud_05.Models;

namespace lab_123_crud_05.Pages
{
    public class EditModel : PageModel
    {
        private readonly lab_123_crud_05.Models.StoreDatabase _context;

        public EditModel(lab_123_crud_05.Models.StoreDatabase context)
        {
            _context = context;
        }

        [BindProperty]
        public Product Product { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            
            Product = await _context.Products.FirstOrDefaultAsync(m => m.ProductID == id);

            if (Product == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Product).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return RedirectToPage("./Products");
        }

        private bool CustomerExists(int id)
        {
            return _context.Products.Any(e => e.ProductID == id);
        }
    }
}