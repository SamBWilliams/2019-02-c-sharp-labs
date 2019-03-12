using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.IO;

namespace lab_10_entity
{
    class Program
    {
        static List<Customer> customers = new List<Customer>();

        static void Main(string[] args)
        {
            
            

            //inseting new customer

            using (var db = new NorthwindEntities())
            {
                Customer customerToCreate = new Customer
                {
                    CustomerID = "5AMBW",
                    ContactName = "Sam",
                    City = "London",
                    CompanyName = "Sparta"
                };

                //Adds customer to local database
                db.Customers.Add(customerToCreate);

                //Write changes permanently to real database
                db.SaveChanges();
            }


            //CRUD

            //select one customer
            using (var db = new NorthwindEntities())
            {
                //linq query : Microsoft : Language independent query
                var customerToUpdate =
                    //select all customers in northwind
                    (from customer in db.Customers
                    //choose one where ID matches
                    where customer.CustomerID == "ALFKI"
                    //output this one selected
                    select customer).FirstOrDefault(); //Ensures only one

                Console.WriteLine("\n\nfinding one customer\n");
                Console.WriteLine($"{customerToUpdate.ContactName} lives in " +
                    $"{customerToUpdate.City}");
            }


            using (var db = new NorthwindEntities())
            {
                //LINQ lambda, allows for chaining such as .OrderBy
                var customerToUpdate =
                    db.Customers.Where(c => c.CustomerID == "5AMBW").FirstOrDefault();

                Console.WriteLine("\n\nfinding one customer\n");
                Console.WriteLine($"{customerToUpdate.ContactName} lives in " +
                    $"{customerToUpdate.City}");

                //UPDATE CUSTOMER
                customerToUpdate.ContactName = "Fred Flintstone";
                //UPDATE database permanently
                db.SaveChanges();
            }
            //have a look at customers after insert/update
            Console.WriteLine("\n\nView customers after INSERT and UPDATE\n\n");
            DisplayAll();

            //Delete customer

            using (var db = new NorthwindEntities())
            {
                Customer customerToDelete = db.Customers.Where
                    (c => c.CustomerID == "54MBW").FirstOrDefault();
                
                db.Customers.Remove(customerToDelete);
                
            }
            //have a look at customer after delete
            Console.WriteLine("\n\nView customers after deletion\n\n");
            DisplayAll();

        }
        static void DisplayAll()
        {
            
            using (var db = new NorthwindEntities())
            {
                //customers list = (read from northwind)
                //              (pull out all customers)
                //              (send to list of customers)
                customers = db.Customers.ToList<Customer>();
            }
            //use list
            foreach(var customer in customers)
            {
                Console.WriteLine($"{customer.ContactName} has ID " +
                    $"{customer.CustomerID} from {customer.City}");
            }
        }
    }
}
