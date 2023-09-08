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

namespace StudyGuideApp
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

        private void beginButton_Click(object sender, RoutedEventArgs e)
        {

        }

        //info button
        private void infoButton_Click(object sender, RoutedEventArgs e)
        {
            //object of the info window
            InformationWindow window = new InformationWindow();

            //displays info window
            window.Show();

            //hides current window
            Close();
        }

        private void exitButton_Click(object sender, RoutedEventArgs e)
        {

        }



        //info button

    }
}
