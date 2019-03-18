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
    /// Interaction logic for OrderDetails.xaml
    /// </summary>
    public partial class OrderDetails : Window
    {
        public OrderDetails()
        {
            InitializeComponent();
           // initialize();
        }

        public void initialize(Order ord)
        {
            //using (var db = new NorthwindEntities())
            //{
            //    var rows = db.Order_Details.Select(row => row);
            //    orderDet.ItemsSource = rows.ToList();

            //    var oRows = db.Orders.Select(row => row);
            //    orders.ItemsSource = oRows.ToList();
            //}

            using (var db = new NorthwindEntities())
            {
                var ordDeets =
                    (from od in db.Order_Details
                     where od.OrderID == ord.OrderID
                     select new { od.ProductID, od.Product, od.Quantity, od.UnitPrice });

                orderDet.ItemsSource = ordDeets.ToList();
            }

        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
        }
    }
}
