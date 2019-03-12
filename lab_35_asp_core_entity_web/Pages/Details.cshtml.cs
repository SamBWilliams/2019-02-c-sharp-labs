using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using lab_35_asp_core_entity_web.Models;

namespace lab_35_asp_core_entity_web.Pages
{
    public class DetailsModel : PageModel
    {
        private readonly lab_35_asp_core_entity_web.Models.Northwind _context;

        public DetailsModel(lab_35_asp_core_entity_web.Models.Northwind context)
        {
            _context = context;
        }

        public Customer Customer { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Customer = await _context.Customers.FirstOrDefaultAsync(m => m.CustomerID == id);

            if (Customer == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
