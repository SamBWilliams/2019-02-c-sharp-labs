using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using lab_35_asp_core_entity_web.Models;

namespace lab_35_asp_core_entity_web.Pages
{
    public class CustomersModel : PageModel
    {
        private Northwind db;
        public IEnumerable<Customer> customers;

        //[BindProperties]
        public Customer customer { get; set; }


        public CustomersModel(Northwind injectedContext)
        {
            db = injectedContext;
        }

        //public String display { get; set; }

            //HTTP GET REQUEST
        public void OnGet()
        {
            ViewData["Title"] = "List of NorthWind Customers";
            customers = db.Customers.ToList();
            
        }

        //HTTP POST
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Customers.Add(customer);
                    db.SaveChanges();
                    return RedirectToPage("/Customers");
                }
                catch (Exception) { }
                
            }
            return Page();
        }
    }
}