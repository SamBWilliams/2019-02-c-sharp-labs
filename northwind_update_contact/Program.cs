using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace northwind_update_contact
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new NorthwindEntities())
            {
                string[] names = { "John", "Chris", "James", "Alice", "Emily" };
                Random rnd = new Random();
                int nameChooser = rnd.Next(names.Length);

                var custToUpdate = db.Customers.Where(c => c.CustomerID == "ALFKI").FirstOrDefault();

                for (int i = 0; i < 1000; i++)
                {
                    custToUpdate.ContactName = nameChooser.ToString();
                    db.SaveChanges();
                }
                Console.WriteLine(custToUpdate);
            }
        }
    }
}
