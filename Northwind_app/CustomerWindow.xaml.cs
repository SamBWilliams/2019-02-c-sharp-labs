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
            string name = nameTxt.Text;
            string company = compTxt.Text;

            if(nameTxt.Text != "") query.searchByName(name, custTable);
            else if (compTxt.Text != "") query.searchByCompany(company, custTable);


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

        private void SearchType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var comboBoxItem = (ComboBoxItem)searchType.SelectedItem;
            queryType = comboBoxItem.Content.ToString();
            MessageBox.Show("query type will be " + queryType);
        }
    }
}
