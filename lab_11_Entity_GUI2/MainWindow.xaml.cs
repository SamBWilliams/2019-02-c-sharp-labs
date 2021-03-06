﻿using System;
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
//using System.Windows.Data.MultiBinding;

namespace lab_11_Entity_GUI2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<string> customerList = new List<string>();
        List<Customer> customers = new List<Customer>();
        Customer customer;
        List<string> cities = new List<string>();
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

                foreach(var c in customers)
                {
                    //c.ToString();
                    customerList.Add($"{c.ContactName} has ID {c.CustomerID}");
                }
                Listbox01.ItemsSource = customerList;
            }

            using(var db = new NorthwindEntities())
            {
                customers = db.Customers.ToList<Customer>();
                Listbox02.ItemsSource = customers;
            }
            using (var db = new NorthwindEntities())
            {
                customers = db.Customers.ToList<Customer>();
                Listbox03.ItemsSource = customers;
                Listbox03.DisplayMemberPath = "ContactName";
            }

            //Populate static box
            cBstaticCity.Items.Add("New York");
            cBstaticCity.Items.Add("Paris");
            cBstaticCity.Items.Add("London");

            using(var db = new NorthwindEntities())
            {
                cities =
                    (from cust in db.Customers
                     select cust.City).Distinct().OrderBy(city=>city).ToList<string>(); //Descending
                cBboundToCity.ItemsSource = cities;
            }

        }

        private void Listbox03_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            customer = (Customer)Listbox03.SelectedItem;
            TextBoxName.Text = customer.ContactName;
        }

        private void CBstaticCity_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //MessageBox.Show($"You chose {cBstaticCity.SelectedItem}");

        }

        private void CBboundToCity_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
