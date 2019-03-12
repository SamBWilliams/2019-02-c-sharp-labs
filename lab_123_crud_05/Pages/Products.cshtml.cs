using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using lab_123_crud_05.Models;

namespace lab_123_crud_05.Pages
{
    public class ProductsModel : PageModel
    {
        private StoreDatabase db;
        public IEnumerable<Product> products;
        public IList<Product> Product { get; set; }

        [BindProperty]
        public Product product { get; set; }


        public ProductsModel(StoreDatabase injectedContext)
        {
            db = injectedContext;
        }

        //public String display { get; set; }

        //HTTP GET REQUEST
        public void OnGet()
        {

            ViewData["Title"] = "List of Products";
            products = db.Products.ToList();

        }

        //HTTP POST
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Products.Add(product);
                    db.SaveChanges();
                    return RedirectToPage("/Products");
                }
                catch (Exception) { }
            }
            return Page();
        }
    }
}