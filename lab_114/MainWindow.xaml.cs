using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

namespace lab_114
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        
        List<Customer> customers = new List<Customer>();
        Customer customer;
        public MainWindow()
        {
            InitializeComponent();
            initialise();
        }

        void initialise()
        {
            using (var db = new NorthwindEntities())
            {
                customers = db.Customers.ToList<Customer>();

                custList.ItemsSource = customers;
                custList.DisplayMemberPath = "ContactName";


            }
        }

        private void CustList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            customer = (Customer)custList.SelectedItem;
            custText.Text = customer.ContactName;
            displayCity.Content = customer.City;
        }

        private void UpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            customer = (Customer)custList.SelectedItem;
            var db = new NorthwindEntities();
            var upDateCity = db.Customers.Where(c => c.City == displayCity.Content.ToString()).FirstOrDefault();

            upDateCity.City = (string)cityList.ItemsSource;



        }
    }
}
