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
    /// Interaction logic for ModuleCalendarWindow.xaml
    /// </summary>
    public partial class ModuleCalendarWindow : Window
    {
        public ModuleCalendarWindow()
        {
            InitializeComponent();
        }

        private void returnButton_Click(object sender, RoutedEventArgs e)
        {
            //object of the dashboard window
            DashboardWindow window = new DashboardWindow();

            //displays dashboard window
            window.Show();

            //hides current window
            Close();
        }

        private void ListViewItem_Selected(object sender, RoutedEventArgs e)
        {

        }
    }
}
