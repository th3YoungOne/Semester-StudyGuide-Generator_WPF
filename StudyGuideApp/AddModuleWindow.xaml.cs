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

namespace StudyGuideApp
{
    /// <summary>
    /// Interaction logic for AddModuleWindow.xaml
    /// </summary>
    public partial class AddModuleWindow : Window
    {
        public AddModuleWindow()
        {
            InitializeComponent();
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            //object of the calendar window
            DashboardWindow window = new DashboardWindow();

            //displays calendar window
            window.Show();

            //hides current window
            Close();
        }
    }
}
