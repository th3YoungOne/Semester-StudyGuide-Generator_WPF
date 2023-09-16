using System;
using System.Collections.Generic;
using System.IO;
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
    /// Interaction logic for DashboardWindow.xaml
    /// </summary>
    public partial class DashboardWindow : Window
    {
        public DashboardWindow()
        {
            InitializeComponent();
        }

        //add module button
        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            //object of the calendar window
            AddModuleWindow window = new AddModuleWindow();

            //displays calendar window
            window.Show();

            //hides current window
            Close();
        }

        //remove module button
        private void removeButton_Click(object sender, RoutedEventArgs e)
        {

        }

        //exit button
        private void exitButton_Click(object sender, RoutedEventArgs e)
        {
            //change according to your saved file path!!!
            string folderPath = @"C:\Users\lab_services_student\Documents\GitHub\Semester-StudyGuide-Generator_WPF\StudyGuideApp\bin\Debug\";

            try
            {
                string[] xmlFiles = Directory.GetFiles(folderPath, "*.xml");

                //deletes all xmlFiles to avoid recursive data user
                if (xmlFiles.Length > 0)
                {
                    foreach (var item in xmlFiles)
                    {
                        File.Delete(item);
                    }
                    //exits the app
                    Application.Current.Shutdown();
                }
                else { Application.Current.Shutdown();}
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex}","Error!",MessageBoxButton.OK);
            }
        }
    }
}
