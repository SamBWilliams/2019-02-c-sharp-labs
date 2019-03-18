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
    /// Interaction logic for CustDetails.xaml
    /// </summary>
    public partial class CustDetails : Window
    {
        //Customer customer;
        Order order;
        
        public CustDetails()
        {
            InitializeComponent();
        }


        public void initialize(Customer cust)
        {
            idTxt.Text = cust.CustomerID;
            nameTxt.Text = cust.ContactName;
            compTxt.Text = cust.CompanyName;
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            CustomerWindow cw = new CustomerWindow();
            cw.Show();
            this.Close();
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            nameTxt.IsReadOnly = false;
            compTxt.IsReadOnly = false;
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            using(var db = new NorthwindEntities())
            {
                var updateCustomer =
                    db.Customers.Where(c => c.CustomerID == idTxt.Text).FirstOrDefault();

                updateCustomer.ContactName = nameTxt.Text;
                updateCustomer.CompanyName = compTxt.Text;
                db.SaveChanges();
            }
        }

        private void OrderBtn_Click(object sender, RoutedEventArgs e)
        {
            //using (var db = new NorthwindEntities())
            //{
            //    var orderDetailsQuery =
            //        (from ord in db.Orders
            //         join cust in db.Customers
            //         on ord.CustomerID equals CustomerWindow.customer.CustomerID
            //         where CustomerWindow.customer.ContactName == nameTxt.Text
            //         select new { ord.OrderID, ord.OrderDate, CustomerWindow.customer.ContactName }
            //         );

            //    orderHistory.ItemsSource = orderDetailsQuery.ToList();
            //}

            using (var db = new NorthwindEntities())
            {
                var custOrders =
                    (from ord in db.Orders
                     where CustomerWindow.customer.CustomerID == idTxt.Text
                     select new { ord.OrderID, ord.OrderDate, ord.EmployeeID /*CustomerWindow.customer.ContactName*/ });

                orderHistory.ItemsSource = custOrders.ToList();
            }
        }

        private void Row_Click(object sender, MouseButtonEventArgs e)
        {
            var orderId = orderHistory.SelectedCells.ToString();

            
            // order =(Order)orderId;
            //MessageBox.Show(Convert.ToString(orderHistory.SelectedCells));
            //MessageBox.Show(orderId);
            OrderDetails od = new OrderDetails();
            od.Show();
            od.initialize(order);
            //order = orderHistory.SelectedItem as Order;

            //using (var db = new NorthwindEntities())
            //{
            //    var ordDeets =
            //        (from od in db.Order_Details
            //         where od.OrderID == order.OrderID
            //         select new { od.ProductID, od.Product, od.Quantity, od.UnitPrice });

            //    orderDetails.ItemsSource = ordDeets.ToList();
            //}
        }

        private void OrderHistory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            //order = (Order)orderHistory.SelectedItem;
            //using (var db = new NorthwindEntities())
            //{              
            //    var ordDeets =
            //        (from od in db.Order_Details
            //         where od.OrderID == order.OrderID
            //         select new { od.ProductID, od.Product, od.Quantity, od.UnitPrice });

            //    orderDetails.ItemsSource = ordDeets.ToList();
            //}
        }

        private void OrdDetailBtn_Click(object sender, RoutedEventArgs e)
        {
            IList<DataGridCellInfo> cells = orderDetails.SelectedCells;
            foreach (DataGridCellInfo cell in cells)
            {
                string header = cell.Column.Header as string;
                order = cell.Item as Order;
                //string item = (string)cell.Item;


                using (var db = new NorthwindEntities())
                {
                    var ordDeets =
                        (from od in db.Order_Details
                         where od.OrderID == order.OrderID
                         select new { od.ProductID, od.Product, od.Quantity, od.UnitPrice });

                    orderDetails.ItemsSource = ordDeets.ToList();
                }
            }
        }
    }
}
