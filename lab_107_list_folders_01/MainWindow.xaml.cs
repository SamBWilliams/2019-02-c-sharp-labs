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
using System.Xml.Linq;
using System.Xml;
using System.IO;

namespace lab_107_list_folders_01
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            game();
        }

        // list box : list all folders in project root
        //manually create folders

        public void game()
        {
            try
            {
                string[] readAllText = File.ReadAllLines("nameFile.txt");
                nameBox.Text = readAllText[0];
                levelBox.Text = readAllText[1];
                scoreBox.Text = readAllText[2];

                string dir = new DirectoryInfo(@"C:\labs\lab_107_list_folders_01\bin\Debug").Name;
                listFolders.Items.Add(dir);
            }
            catch (Exception) { }
        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {

            string nameText = nameBox.Text;
            string levelText = levelBox.Text;
            string scoreText = scoreBox.Text;

            string[] allText = { nameText, levelText, scoreText };
            File.WriteAllLines("nameFile.txt", allText);


        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            int num = int.Parse(scoreBox.Text) + 1;

            scoreBox.Text = num.ToString();

        }

        private void MinBtn_Click(object sender, RoutedEventArgs e)
        {
            int num = int.Parse(scoreBox.Text) - 1;

            scoreBox.Text = num.ToString();
        }

        private void CreateFolder_Click(object sender, RoutedEventArgs e)
        {
            Directory.CreateDirectory(folderText.Text);

        }
    }
}
