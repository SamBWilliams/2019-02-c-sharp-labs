using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.Entity;

namespace lab_34_wpf_database_app
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Product product;
        List<double> totalprice = new List<double>();
        List<Product> basket = new List<Product>();

        public MainWindow()
        {
            InitializeComponent();
            initialize();
        }

        public void initialize()
        {
            List<Product> products  = new List<Product>();

            using (var db = new StoreContext())
            {
                products = db.Products.ToList<Product>();
            }           
            nameList.ItemsSource = products;
            nameList.DisplayMemberPath = "ProductName";          
        }


        private void UpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            int num = int.Parse(noOfProducts.Text);
            randProducts(num);
            initialize();
        }

        private void NameList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                product = nameList.SelectedItem as Product;
                prodDetails.Items.Clear();
                prodDetails.Items.Add($"ID: {product.ProductID}");
                prodDetails.Items.Add($"Name: {product.ProductName}");
                prodDetails.Items.Add($"Price: {product.Price}");
                prodDetails.Items.Add($"Stock: {product.Stock}");
            }catch(Exception) { }          
        }

        private void BasketBtn_Click(object sender, RoutedEventArgs e)
        {
            reciept.Items.Clear();
            totalprice.Add(product.Price);
            basket.Add(product);
            totalLabel.Content = totalprice.Sum();
            prodDetails.Items.Clear();
            checkStock();
        }

        private void PurchaseBtn_Click(object sender, RoutedEventArgs e)
        {                     
            lowerStock();
            addToReceipt();
            basket.Clear();
            totalprice.Clear();
            totalLabel.Content = "0";
        }

        //Generate random products
        public void randProducts(int noOfProducts)
        {
            string[] prodNames = { "Smart TV", "Smart phone", "Tablet", "PC", "Macbook", "Sound system" };
            double[] prices = { 199.99, 399.99, 349.99, 149.99, 299.99, 449.99 };
            Random rand = new Random();
            using (var db = new StoreContext())
            {
                for (int i = 0; i < noOfProducts; i++)
                {
                    //Random rand = new Random();
                    int randName = rand.Next(prodNames.Length);
                    int randPrice = rand.Next(prices.Length);
                    var product0 = new Product();

                    product0.ProductName = prodNames[randName];
                    product0.Price = prices[randPrice];
                    product0.Stock = rand.Next(0, 20);
                    db.Products.Add(product0);
                    db.SaveChanges();
                }
            }
        }

        public void addToReceipt()
        {
            double subTotal = totalprice.Sum();
            double discount = 0;
            foreach (var p in basket)
            {
                reciept.Items.Add($"{p.ProductName} \nProduct code: {p.ProductID}\n{p.Price}");
                reciept.Items.Add("----------------------");
            }
            reciept.Items.Add($"Total: {totalprice.Sum()}");

            if (totalprice.Sum() > 1000)
            {
                discount = subTotal / 20;
                subTotal -= discount;
            }           
            reciept.Items.Add($"Discount: {Math.Round(discount, 2)}");
            reciept.Items.Add($"Subtotal: £{Math.Round(subTotal - discount, 2)}");
        }

        public void lowerStock()
        {
            foreach(var p in basket)
            {
                p.Stock -= 1;        
            }        
        }

        public void checkStock()
        {
            double prodPrice = product.Price;
            
            if (product.Stock <= 0)
            {
                MessageBox.Show($"Product code: {product.ProductID} - OUT OF STOCK");
                basket.Remove(product);
                totalLabel.Content = totalprice.Sum() - prodPrice;
                totalprice.Remove(product.Price);
            }
        }      
    }
    
    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }

        public Product() { }
    }

    public class StoreContext : DbContext
    {      
        public StoreContext() : base("TestDB5") { }
        public DbSet<Product> Products { get; set; }
    }
}
