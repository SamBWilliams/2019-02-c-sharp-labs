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
    public class IndexModel : PageModel
    {
        private readonly lab_35_asp_core_entity_web.Models.Northwind _context;

        public IndexModel(lab_35_asp_core_entity_web.Models.Northwind context)
        {
            _context = context;
        }

        public IList<Customer> Customer { get;set; }

        public async Task OnGetAsync()
        {
            Customer = await _context.Customers.ToListAsync();
        }
    }
}
