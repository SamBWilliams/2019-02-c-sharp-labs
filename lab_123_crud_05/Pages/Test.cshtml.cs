using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using lab_123_crud_05.Models;
using Microsoft.EntityFrameworkCore;


namespace lab_123_crud_05.Pages
{
    public class TestModel : PageModel
    {
        private StoreDatabase db;
        public IEnumerable<Product> products;
        public IList<Product> Product { get; set; }
        List<Product> basket = new List<Product>();

        [BindProperty]
        public Product product { get; set; }


        public TestModel(StoreDatabase injectedContext)
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
        public IActionResult AddToList(TestModel testModel)
        {
            basket.Add(product);
            return Page();
        }

        public IActionResult OnPost(Product product)
        {
            if (ModelState.IsValid)
            {
                //products.Add(product);
                foreach (var p in products)
                {
                    p.Stock += 1;

                    Order o = new Order(DateTime.Now, p.Price, p.ProductID);
                    db.Orders.Add(o);
                    db.SaveChanges();

                }
            }

            return Page();
        }
    }
}