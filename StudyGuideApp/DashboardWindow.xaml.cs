using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Xml.Linq;
using StudyGuideLibrary;

namespace StudyGuideApp
{
    /// <summary>
    /// Interaction logic for DashboardWindow.xaml
    /// </summary>
    public partial class DashboardWindow : Window
    {
        private readonly viewModel ViewModel;
        public DashboardWindow()
        {
            InitializeComponent();
            //Declare a new XML Document Object
            XDocument readDoc = XDocument.Load("SemesterData.xml");

            //fills the semester textbox
            ClassMethods obj = new ClassMethods();
            Semester semInfo = obj.readSemDoc("SemesterData.xml");
            richTextBox.AppendText(semInfoDisplay(semInfo));


            //fills the module datagrid
            string fileName = "ModuleData.xml";
            if (File.Exists(fileName))
            {
                try
                {
                    XDocument readModDoc = XDocument.Load(fileName);
                    ObservableCollection<Module> modules = new ObservableCollection<Module>();

                    //Declare a new XML Document Object

                    foreach (var modElement in readModDoc.Descendants("Module"))
                    {
                        Module module = new Module
                        {
                            code = modElement.Element("ModuleInfo")?.Element("Code")?.Value,
                            name = modElement.Element("ModuleInfo")?.Element("Name")?.Value,
                            credits = int.TryParse(modElement.Element("ModuleInfo")?.Element("Credits")?.Value, out int credits) ? credits : 0,
                            classHrsPerWeek = int.TryParse(modElement.Element("ModuleInfo")?.Element("HoursPerWeek")?.Value, out int classHrsPerWeek) ? classHrsPerWeek : 0,
                        };
                        modules.Add(module);
                    }

                    this.ViewModel = new viewModel
                    {
                        moduleItems = modules
                    };
                    this.DataContext = this.ViewModel;

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex}", "Error Occured!", MessageBoxButton.OK);
                }
            }
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

        public string semInfoDisplay(Semester obj)
        {
            return $"Semester Duration (Weeks): {obj.weeks}\nStart Date: {obj.startDate.ToShortDateString()}\nEnd Date: {obj.endDate.ToShortDateString()}";
        }

        private void moduleDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //ModuleCalendarWindow window = new ModuleCalendarWindow();

            ////displays calendar window
            //window.Show();

            ////hides current window
            //Close();
        }
    }
}
