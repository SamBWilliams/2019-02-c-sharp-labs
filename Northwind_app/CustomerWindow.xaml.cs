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
using System.Data.Entity.Core.Objects;

namespace Northwind_app
{
    /// <summary>
    /// Interaction logic for CustomerWindow.xaml
    /// </summary>
    
    
    public partial class CustomerWindow : Window
    {

        Queries query = new Queries();
        public static Customer customer;
        NorthwindEntities db = new NorthwindEntities();
        string queryType;

        public CustomerWindow()
        {
            InitializeComponent();
            initialize();
        }

        public void initialize()
        {
            using (var db = new NorthwindEntities())
            {
                var rows = db.Customers.Select(row => row);
                custTable.ItemsSource = rows.ToList();
            }          
        }


        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
        }

        private void SearchBtn_Click(object sender, RoutedEventArgs e)
        {
            string search = nameTxt.Text;
            string titleSearch = titles.Text;

            if(searchType.Text == "ContactName") query.searchByName(search, custTable);   
            else if(searchType.Text == "CompanyName") query.searchByCompany(search, custTable);
            else if(searchType.Text == "ContactTitle") query.searchByTitle(titleSearch, custTable);

            
        }

        private void CustTable_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Row_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            customer = custTable.SelectedItem as Customer;
            CustDetails cd = new CustDetails();
            cd.Show();
            cd.initialize(customer);
            this.Close();
        }

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            initialize();
        }

        private void SearchType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var comboBoxItem = (ComboBoxItem)searchType.SelectedItem;
            string selection = comboBoxItem.Content.ToString();

            if (selection == "ContactTitle")
            {
                titles.Visibility = Visibility.Visible;
                nameTxt.Visibility = Visibility.Hidden;
            }
            else
            {
                titles.Visibility = Visibility.Hidden;
                nameTxt.Visibility = Visibility.Visible;
            }
                
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            CreateCustomer cc = new CreateCustomer();
            cc.Show();
        }
    }
}
