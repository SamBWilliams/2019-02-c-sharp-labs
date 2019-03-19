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
                     where customer.ContactName.Contains(name)
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
                     where customer.CompanyName.Contains(comp)
                     select customer);
                table.ItemsSource = searchQuery.ToList();
            }
        }

        public void searchByTitle(string cont, DataGrid table)
        {
            using (var db = new NorthwindEntities())
            {
                var searchQuery =
                    (from customer in db.Customers
                     where customer.ContactTitle == cont
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

        public void createCustomer(string name, string comp)
        {
            using (var db = new NorthwindEntities())
            {
                Customer custToCreate = new Customer
                {
                    CustomerID = name.Substring(0, 3) + comp.Substring(0, 2),
                    ContactName = name,
                    CompanyName = comp
                };
                db.Customers.Add(custToCreate);
                db.SaveChanges();
            }
        }

        public void deleteCustomer(string id)
        {
            using (var db = new NorthwindEntities())
            {
                Customer delCustomer = db.Customers.Where
                    (c => c.CustomerID == id).FirstOrDefault();

                db.Customers.Remove(delCustomer);
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

        public void showStockLower(int amount, DataGrid table)
        {
            using (var db = new NorthwindEntities())
            {
                var stockLower =
                    (from p in db.Products
                     where p.UnitsInStock < amount
                     join sup in db.Suppliers on p.ProductID equals sup.SupplierID
                     select new { p.ProductID, p.ProductName, p.UnitsInStock, p.UnitPrice, Supplier = sup.CompanyName});

                table.ItemsSource = stockLower.ToList();
            }
        }

        public void showStockHigher(int amount, DataGrid table)
        {
            using (var db = new NorthwindEntities())
            {
                var stockLower =
                    (from p in db.Products
                     where p.UnitsInStock > amount
                     join sup in db.Suppliers on p.ProductID equals sup.SupplierID
                     select new { p.ProductID, p.ProductName, p.UnitsInStock, p.UnitPrice, Supplier = sup.CompanyName });
                table.ItemsSource = stockLower.ToList();
            }
        }
    }
}
