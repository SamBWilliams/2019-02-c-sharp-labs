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
using System.Diagnostics;

namespace lab_115_nw_entity_with_OOP
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// 
    /// Read customers, cast to active customers and set
    /// isActive to true for all customers
    /// 
    /// Create two listboxes and radio button to enable or disable active customer
    /// 
    /// Click on customer to select and display all details on screen
    /// (TextBlock, StackPanel, Listbox2)
    /// 
    /// When you click on enable/disable button toggle button it will reverse state of customer
    /// the isActive changes (toggles)state
    /// 
    /// First list = only for active customers
    ///     State becomes inactive ==> remove from first listbox
    /// 
    /// second listbox = only for inactiv customers
    ///     inactive state : remove from first but add to secound listbox
    ///     
    /// Reverse the process ie when you click on inactive customer (second list box)
    /// you can then toggle the state back to enabled (use the radio/toggle button)
    /// Removed from inactive and add back to active list
    /// 
    /// 
    /// 
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Customer> customers = new List<Customer>();
        
        List<ActiveCustomer> actCustomers = new List<ActiveCustomer>();
        List<ActiveCustomer> inactCustomers = new List<ActiveCustomer>();
        ActiveCustomer customer;

        public MainWindow()
        {
            InitializeComponent();
            initialize();
        }

        void initialize()
        {

            using (var db = new NorthwindEntities())
            {
                customers = db.Customers.ToList();
            }
            foreach (var c in customers)
            {
                actCustomers.Add(new ActiveCustomer(c));
            }

            activeList.ItemsSource = actCustomers;
            activeList.DisplayMemberPath = "ContactName";
            inactiveList.ItemsSource = inactCustomers;
            inactiveList.DisplayMemberPath = "ContactName";
        }


        interface IActiveTool
        {
            void makeActive();
            void makeInactive();
        }

        class ActiveCustomer : Customer, IActiveTool
        {
            
            public bool isActive;

            public ActiveCustomer() { }
            public ActiveCustomer(Customer c)
            {                
                City = c.City;
                ContactName = c.ContactName;               
                CustomerID = c.CustomerID;               
                IsActive = true;
            }

            public bool IsActive { get; set; } = true;

            public void makeActive()
            {
                this.IsActive = true;
            }

            public void makeInactive()
            {
                this.IsActive = false;
            }

            
        }

        private void ActiveList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            customer = activeList.SelectedItem as ActiveCustomer;
            actBtn.IsChecked = true;
            custDetails.Items.Clear();
            custDetails.Items.Add($"Name: {customer.ContactName}");
            custDetails.Items.Add($"ID: {customer.CustomerID}");           
            custDetails.Items.Add($"City: {customer.City}");
            custDetails.Items.Add($"IsActive: {customer.IsActive}");
        }


        private void InactiveList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            customer = inactiveList.SelectedItem as ActiveCustomer;
            inactBtn.IsChecked = true;
            custDetails.Items.Clear();
            custDetails.Items.Add($"Name: {customer.ContactName}");
            custDetails.Items.Add($"ID: {customer.CustomerID}");
            custDetails.Items.Add($"City: {customer.City}");
            custDetails.Items.Add($"IsActive: {customer.IsActive}");
        }

        private void InactBtn_Checked(object sender, RoutedEventArgs e)
        {
            customer.makeInactive();
            if (actCustomers.Contains(customer))
            {
                inactCustomers.Add(customer);
                actCustomers.Remove(customer);
            }

            listUpdated();
        }

        private void ActBtn_Checked(object sender, RoutedEventArgs e)
        {
            
            customer.makeActive();
            if (!actCustomers.Contains(customer))
            {
                actCustomers.Add(customer);
                inactCustomers.Remove(customer);
            }

            listUpdated();
        }

        public void listUpdated()
        {
            activeList.SelectionChanged -= ActiveList_SelectionChanged;
            inactiveList.SelectionChanged -= InactiveList_SelectionChanged;
            activeList.Items.Refresh();
            inactiveList.Items.Refresh();
            activeList.SelectionChanged += ActiveList_SelectionChanged;
            inactiveList.SelectionChanged += InactiveList_SelectionChanged;
        }

        
    }

   
}
