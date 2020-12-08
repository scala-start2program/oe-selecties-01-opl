using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Policy;
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

namespace Prb.Verkeerslichten.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        Random rnd = new Random();
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            HandleTrafficLights();
        }
        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            HandleTrafficLights();
        }
        private void HandleTrafficLights()
        {
            int randomColor = rnd.Next(1, 4);
            string fileName = "";
            if (randomColor == 1)
            {
                lblInfo.Content = "ORANJE" + Environment.NewLine + "Als het veilig is dan zou je nu best stoppen.";
                lblInfo.Background = Brushes.Orange;
                lblInfo.Foreground = Brushes.White;
                fileName = "verkeer_oranje.png";
            }
            else if (randomColor == 2)
            {
                lblInfo.Content = "ROOD" + Environment.NewLine + "Gooi onmiddellijk alles dicht!";
                lblInfo.Background = Brushes.Tomato;
                lblInfo.Foreground = Brushes.White;
                fileName = "verkeer_rood.png";                
            }
            else
            {
                lblInfo.Content = "GROEN" + Environment.NewLine + "Karren maar.  Alles veilig.";
                lblInfo.Background = Brushes.ForestGreen;
                lblInfo.Foreground = Brushes.White;
                fileName = "verkeer_groen.png";
            }
            SetTrafficLightImagePath(fileName);
        }
        private void SetTrafficLightImagePath(string fileName)
        {

            string pad = Environment.CurrentDirectory;
            DirectoryInfo directoryInfo = new DirectoryInfo(pad);
            directoryInfo = new DirectoryInfo(directoryInfo.Parent.Parent.Parent.FullName);
            Uri uri = new Uri(directoryInfo.FullName + "/afbeeldingen/" + fileName);
            imgTrafficLight.Source = new BitmapImage(uri);

        }

    }
}
