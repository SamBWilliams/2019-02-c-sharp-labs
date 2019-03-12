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
        List<Order> orders = new List<Order>();

        private readonly lab_123_crud_05.Models.StoreDatabase _context;

        public OrderPageModel(StoreDatabase injectedContext)
        {
            db = injectedContext;
        }

        [BindProperty]
        public Product Product { get; set; }

        [BindProperty]
        public Order order { get; set; }

        [BindProperty]
        public OrderDetail Odetails { get; set; }


        public async Task<IActionResult> OnGetAsync(int id)
        {
            Product = await db.Products.FirstOrDefaultAsync(m => m.ProductID == id);

            if (Product == null)
            {
                return NotFound();
            }
            return Page();
        }


        //public IActionResult OnPost()
        //{
        //   // Order o = new Order();

        //    products.Add(Product);
        //    orders.Add(Order);

        //    foreach (var p in products)
        //    {
        //        foreach(var o in orders)
        //        {
        //            OrderDetail od = new OrderDetail(p.ProductID, o.OrderID);
        //            db.OrderDetails.Add(od);
        //            db.SaveChanges();
        //        }

        //        //OrderDetail od = new OrderDetail(p.ProductID, o.OrderID);
        //        //db.OrderDetails.Add(od);
        //    }
        //    return Page();
        //}



        public IActionResult OnPost(Product product)
        {
            if (ModelState.IsValid)
            {
                products.Add(product);
                foreach (var p in products)
                {
                    Order o = new Order(DateTime.Now, p.Price, p.ProductID);
                    db.Orders.Add(o);                   
                    db.SaveChanges();
                }               
            }
            return Page();
        }

    }
}