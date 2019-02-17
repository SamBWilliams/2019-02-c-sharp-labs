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



namespace lab_105_game_name_and_score_01
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

        //Create a gaming home page
        //Name of gamer (Saved to text file)
        //Level reached
        //Top Score

        public void game()
        {
            //var loadXml = XDocument.Load("name.xml");
            ////var nameLoaded = loadXml.InnerText;
            //nameBox.Text = loadXml.ToString();
            string[] readAllText = File.ReadAllLines("nameFile.txt");
            nameBox.Text = readAllText[0];
            levelBox.Text = readAllText[1];
            scoreBox.Text = readAllText[2];
            //nameBox.Text = File.ReadAllText("nameFile.txt");

        }

        

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //var nameXML = new XElement("name", nameBox.Text);
            //recieve(nameXML);
            //nameXML.Save("name.xml");
            string nameText = nameBox.Text;
            string levelText = levelBox.Text;
            string scoreText = scoreBox.Text;

            string[] allText = { nameText, levelText, scoreText };
            File.WriteAllLines("nameFile.txt",allText);


        }

        //public XElement recieve(XElement xml)
        //{
        //    var innerXml = xml.Value;
        //    return innerXml;
        //}
    }
}
