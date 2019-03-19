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
        public static Order order;
        Queries query = new Queries();
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
            string id = idTxt.Text;
            string name = nameTxt.Text;
            string company = compTxt.Text;

            query.updateCustomer(id, name, company);
        }

        private void OrderBtn_Click(object sender, RoutedEventArgs e)
        {
            string id = idTxt.Text;
            query.showCustOrders(id, orderHistory);
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

        private void DelBtn_Click(object sender, RoutedEventArgs e)
        {
            string id = idTxt.Text;
            query.deleteCustomer(id);
        }
    }
}
