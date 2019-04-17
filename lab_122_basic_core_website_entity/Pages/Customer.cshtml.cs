using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace lab_122_basic_core_website_entity.Pages
{
    public class CustomerModel : PageModel
    {
        public void OnGet()
        {
            ShowMe = "This is a string";
            using (var db = new Northwind())
            {
                Customers = db.Customers.OrderBy(c => c.CustomerID).ToList<Customer>().ToArray()
        }
    }
}