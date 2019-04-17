using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using lab_123_crud_04.Models;

namespace lab_123_crud_04.Pages
{
    public class IndexModel : PageModel
    {
        private readonly lab_123_crud_04.Models.StoreDatabase _context;

        public IndexModel(lab_123_crud_04.Models.StoreDatabase context)
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
