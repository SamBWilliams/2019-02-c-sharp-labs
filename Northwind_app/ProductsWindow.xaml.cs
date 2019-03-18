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
using System.Windows.Shapes;

namespace Northwind_app
{
    /// <summary>
    /// Interaction logic for ProductsWindow.xaml
    /// </summary>
    public partial class ProductsWindow : Window
    {
        Product product;
        public ProductsWindow()
        {
            InitializeComponent();
            initialize();
        }

        public void initialize()
        {
            using (var db = new NorthwindEntities())
            {
                var rows = db.Products.Select(row => row);
                productTable.ItemsSource = rows.ToList();
            }
        }





        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
        }

        private void AvgByCat_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new NorthwindEntities())
            {
                var averageQuery =
                    (from p in db.Products
                     group p by p.CategoryID into cateProds
                     select new
                     {
                         cateProds.Key,
                         AvgPrice = cateProds.Average(c => c.UnitPrice)
                     });
                productTable.ItemsSource = averageQuery.ToList();
            }
        }
    }
}
