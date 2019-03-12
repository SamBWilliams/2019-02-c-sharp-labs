using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;
using System.Xml.Linq;
using System.IO;

namespace lab_30_northwind_to_xml
{
    class Program
    {
        static void Main(string[] args)
        {
            // add product /category / Northwind classes from last core project
            //Read northwind
            //extract products
            //Write to xml

            List<Product> products = new List<Product>();
            using (var db = new Northwind())
            {
               products = db.Products.OrderBy(p => p.ProductName).Take(3).ToList(); //Limit to 3 with take(3)
            }
            products.ForEach(p =>
            {
                Console.WriteLine(p.ProductName);
            });

            var xml = new XElement("Products",
                from p in products
                select new XElement("Product",
                new XAttribute("ID", p.ProductID),
                new XAttribute("Cost",p.Cost),
                new XAttribute("Name",p.ProductName)
                ));
            Console.WriteLine(xml.ToString());

            //write to file
            var doc = new XDocument(xml);
            doc.Save("Products.xml");


            //Now the test: 

            Console.WriteLine("\n\nFirstly read back the raw xml data as a string\n\n");

            Console.WriteLine(File.ReadAllText("Products.xml"));

            //as xml document

            var doc2 = XDocument.Load("Products.xml");

            //Creat object from products


            //Recap
            using (var db = new Northwind())
            {
                products = db.Products.Take(5).ToList();
            }
            //Created XML document from this list of products

            var xml5 = new XElement("Products",
                from p in products
                select new XElement("Product",
                    new XElement("ProductID", p.ProductID),
                    new XElement("ProductName", p.ProductName),
                    new XElement("Cost", p.Cost))
                );

            //Write to disk
            var xmlDocument5 = new XDocument(xml5);
            xmlDocument5.Save("FiveProducts.xml");

            //Read back to string
            Console.WriteLine("\n\nRead back 5 products\n\n");
            Console.WriteLine(File.ReadAllText("FiveProducts.xml"));

            //Deserialise
            Console.WriteLine("\n\nDeserialise back into Product Objects\n\n");

            //Create structue to hold list of desearialised object
            var productList = new Products();

            //Use streaming to get data here
            using (var reader = new StreamReader("FiveProducts.xml"))
            {
                //Deserialise back into products
                var serialiser = new XmlSerializer(typeof(Products));

                //do the work
                productList = (Products)serialiser.Deserialize(reader);
            }

            //job done; just output the list
            foreach(Product p in productList.ProductList)
            {
                Console.WriteLine($"{p.ProductID, -10}{p.ProductName,-50}{p.Cost,-10}");
            }
            

        }
    }
    public class Category
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        [Column(TypeName = "ntext")]
        public string Description { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        public Category()
        {
            this.Products = new List<Product>();
        }
    }
    public class Product
    {
        public int ProductID { get; set; }
        [Required]
        [StringLength(40)]
        public string ProductName { get; set; }
        [Column("UnitPrice", TypeName = "money")]
        public decimal? Cost { get; set; }
        [Column("UnitsInStock")]
        public short? Stock { get; set; }
        public bool Discontinued { get; set; }
        public int CategoryID { get; set; }
        //public virtual Category Category { get; set; }
    }


    public class Northwind : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string path = System.IO.Path.Combine(System.Environment.CurrentDirectory, "../../../../data/Northwind.db");
            // use SQLite
            optionsBuilder.UseSqlite($"Filename={path}");
            // use SQL
            //optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;" + "Initial Catalog=Northwind;" + "Integrated Security=true;" + "MultipleActiveResultSets=true;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .Property(category => category.CategoryName)
                .IsRequired()
                .HasMaxLength(40);
            // filter out discontinued products
            modelBuilder.Entity<Product>()
                .HasQueryFilter(p => !p.Discontinued);
        }
    }

    //This class will hold the deserialised object (casting xml back unto list of products)
    [XmlRoot("Products")]
    public class Products
    {
        [XmlElement("Product")]
        public List<Product> ProductList { get; set; }
    }
}
