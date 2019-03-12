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
    public class OrderPageModel : PageModel
    {

        private StoreDatabase db;
        //public IList<Product> Products { get; set; }

        List<Product> products = new List<Product>();

        private readonly lab_123_crud_05.Models.StoreDatabase _context;

        public OrderPageModel(lab_123_crud_05.Models.StoreDatabase context)
        {
            _context = context;
        }

        [BindProperty]
        public Product Product { get; set; }

        [BindProperty]
        public Order Order { get; set; }

        [BindProperty]
        public OrderDetail Odetails { get; set; }




        public async Task<IActionResult> OnGetAsync(int id)
        {

            Product = await _context.Products.FirstOrDefaultAsync(m => m.ProductID == id);

            if (Product == null)
            {
                return NotFound();
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            
            products.Add(Product);

            foreach (var p in products)
            {
                
                OrderDetail od = new OrderDetail(p.ProductID);
                db.OrderDetails.Add(od);
            }
            return Page();
        }



        //public IActionResult OnPost()
        //{
        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            db.Orders.Add(Products);
        //            db.SaveChanges();
        //            return RedirectToPage("/Products");
        //        }
        //        catch (Exception) { }

        //    }
        //    return Page();
        //}
    }
}