using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Northwind_app
{
    class Queries
    {
        public void searchByName(string name, DataGrid table)
        {
            using (var db = new NorthwindEntities())
            {
                var searchQuery =
                    (from customer in db.Customers
                     where customer.ContactName == name
                     select customer);
                table.ItemsSource = searchQuery.ToList();
            }
        }

        public void searchByCompany(string comp, DataGrid table)
        {
            using (var db = new NorthwindEntities())
            {
                var searchQuery =
                    (from customer in db.Customers
                     where customer.CompanyName == comp
                     select customer);
                table.ItemsSource = searchQuery.ToList();
            }
        }

        public void updateCustomer(string id, string name, string comp)
        {
            using (var db = new NorthwindEntities())
            {
                var updateCustomer =
                    db.Customers.Where(c => c.CustomerID == id).FirstOrDefault();

                updateCustomer.ContactName = name;
                updateCustomer.CompanyName = comp;
                db.SaveChanges();
            }
        }

        public void showCustOrders(string id, DataGrid table)
        {
            using (var db = new NorthwindEntities())
            {
                var custOrders =
                    (from ord in db.Orders
                     where CustomerWindow.customer.CustomerID == id
                     select new { ord.OrderID, ord.OrderDate, ord.EmployeeID });

                table.ItemsSource = custOrders.ToList();
            }
        }
    }
}
