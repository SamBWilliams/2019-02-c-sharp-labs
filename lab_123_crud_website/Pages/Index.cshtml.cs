using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using lab_123_crud_website.Model;

namespace lab_123_crud_website.Pages
{
    public class IndexModel : PageModel
    {
        private readonly lab_123_crud_website.Model.Northwind _context;

        public IndexModel(lab_123_crud_website.Model.Northwind context)
        {
            _context = context;
        }

        public IList<Product> Product { get;set; }

        public async Task OnGetAsync()
        {
            Product = await _context.Products.ToListAsync();
        }
    }
}
