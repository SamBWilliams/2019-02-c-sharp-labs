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

namespace lab_15_panels
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Tracks which panel we are on
        int index;

        public MainWindow()
        {
            InitializeComponent();
            Initialize();
        }

        void Initialize()
        {
            index = 1;
            displayPanel(index);
        }
        private void ButtonChangePanel_Click(object sender, RoutedEventArgs e)
        {
            index++;
            if (index == 4)
            {
                index = 1;
            }
            displayPanel(index);
        }
        void displayPanel(int index)
        {
            switch (index)
            {
                case 1:
                    StackPanel01.Visibility = Visibility.Visible;
                    StackPanel02.Visibility = Visibility.Collapsed;
                    StackPanel03.Visibility = Visibility.Collapsed;
                    break;
                case 2:
                    StackPanel01.Visibility = Visibility.Collapsed;
                    StackPanel02.Visibility = Visibility.Visible;
                    StackPanel03.Visibility = Visibility.Collapsed;
                    break;
                case 3:
                    StackPanel01.Visibility = Visibility.Collapsed;
                    StackPanel02.Visibility = Visibility.Collapsed;
                    StackPanel03.Visibility = Visibility.Visible;
                    break;
            }
        }

        private void ButtonChangeTab_Click(object sender, RoutedEventArgs e)
        {
            if (TabControl01.SelectedIndex < TabControl01.Items.Count - 1)
            {
                TabControl01.SelectedIndex++;
            }
            else
            {
                TabControl01.SelectedIndex = 0;
            }
        }
    }
}
