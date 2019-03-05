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

namespace lab_117_entity_tab
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Customer> customers = new List<Customer>();
        List<Order> orders = new List<Order>();
        Customer customer;
        Order order;
        Order_Detail orderDetail;
        Product product;

        enum tabs
        {
            Customers,
            Orders
        }

        public MainWindow()
        {
            InitializeComponent();
            Initialise();
        }
        void Initialise()
        {
            using (var db = new NorthwindEntities())
            {
                customers = db.Customers.ToList<Customer>();
                ListBox01.ItemsSource = customers;

            }
        }

        private void ListBox01_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            customer = (Customer)ListBox01.SelectedItem;
        }

        private void ListBox01_MouseDoubleClick(object sender, EventArgs e)
        {
            customer = (Customer)ListBox01.SelectedItem;
            TabControl01.SelectedIndex = (int)tabs.Orders;
            using (var db = new NorthwindEntities())
            {
                orders =
                    db.Orders
                    .Where(order => order.CustomerID == customer.CustomerID)
                    .ToList<Order>();
                ListBoxOrders.ItemsSource = orders;
            }

        }

        private void ListBoxOrders_SelectionChanged(object sender, EventArgs e)
        {

        }

        private void ListBoxOrders_MouseDoubleClick(object sender, EventArgs e)
        {


        }

        private void ButtonAddCustomer_Click(object sender, RoutedEventArgs e)
        {
            //var w = new Window();
            //w.Visibility = Visibility.Visible;

            var windowaddcustomer = new WindowAddCustomer();
            windowaddcustomer.Visibility = Visibility.Visible;

        }

        //void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    if (tab.IsSelected && e.Source is TabControl)
        //    {
        //        customerList.SelectionChanged += SelectionChanged;
        //        orderList.SelectionChanged -= OrderSelectionChanged;
        //        orderDetailsList.SelectionChanged -= ProductSelectionChanged;
        //    }
        //    else if (tab1.IsSelected && e.Source is TabControl)
        //    {
        //        customerList.SelectionChanged -= SelectionChanged;
        //        orderList.SelectionChanged += OrderSelectionChanged;
        //        orderDetailsList.SelectionChanged -= ProductSelectionChanged;
        //    }
        //    else if (tab2.IsSelected && e.Source is TabControl)
        //    {
        //        customerList.SelectionChanged -= SelectionChanged;
        //        orderList.SelectionChanged -= OrderSelectionChanged;
        //        orderDetailsList.SelectionChanged += ProductSelectionChanged;
        //    }
        //    else if (tab3.IsSelected && e.Source is TabControl)
        //    {
        //        customerList.SelectionChanged -= SelectionChanged;
        //        orderList.SelectionChanged -= OrderSelectionChanged;
        //        orderDetailsList.SelectionChanged -= ProductSelectionChanged;
        //    }
        //}
    }
}
