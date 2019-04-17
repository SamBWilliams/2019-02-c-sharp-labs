using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using lab_123_crud_05.Models;

namespace lab_123_crud_05.Pages
{
    public class OrdersModel : PageModel
    {

        private StoreDatabase db;
        public IEnumerable<Order> orders;
        public IList<Order> Order { get; set; }


        [BindProperty]
        public Product product { get; set; }


        public OrdersModel(StoreDatabase injectedContext)
        {
            db = injectedContext;
        }


        public void OnGet()
        {
            ViewData["Title"] = "List of Products";
            orders = db.Orders.ToList();
        }
    }
}