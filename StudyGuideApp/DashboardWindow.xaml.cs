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
using StudyGuideDLL;

namespace StudyGuideApp
{
    /// <summary>
    /// Interaction logic for DashboardWindow.xaml
    /// </summary>
    public partial class DashboardWindow : Window
    {
        private readonly viewModel ViewModel;
        protected static Semester semInfo;
        public DashboardWindow()
        {
            InitializeComponent();
            //Declare a new XML Document Object
            XDocument readDoc = XDocument.Load("SemesterData.xml");

            //fills the semester textbox
            ClassMethods obj = new ClassMethods();
            semInfo = obj.readSemDoc("SemesterData.xml");
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
                    var modElements = readModDoc.Descendants("ModuleInfo").ToList();
                    foreach (var modElement in readModDoc.Descendants("ModuleInfo"))
                    {
                        Module module = new Module
                        {
                            code = modElement.Element("Code")?.Value,
                            name = modElement.Element("Name")?.Value,
                            credits = int.TryParse(modElement.Element("Credits")?.Value, out int credits) ? credits : 0,
                            classHrsPerWeek = int.TryParse(modElement.Element("HoursPerWeek")?.Value, out int classHrsPerWeek) ? classHrsPerWeek : 0,
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
            else
            {
                MessageBox.Show("XML file not found.", "File Not Found", MessageBoxButton.OK);
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

        //exit button
        private void exitButton_Click(object sender, RoutedEventArgs e)
        {
            string[] xmlFiles = { "SemesterData.xml", "ModuleData.xml", "CalendarData.xml" };

            for (int i = 0; i < xmlFiles.Length; i++)
            {
                if (File.Exists(xmlFiles[i])) { File.Delete(xmlFiles[i]); }
            }
            //exits the app
            Application.Current.Shutdown();

            //change according to your saved file path!!!
            //string folderPath = @"C:\Users\lab_services_student\Documents\GitHub\Semester-StudyGuide-Generator_WPF\StudyGuideApp\bin\Debug\";
            //MessageBoxResult result = MessageBox.Show("Are you sure you wish to exist the app?", "Exiting Program...", MessageBoxButton.YesNo);
            //if (result == MessageBoxResult.Yes)
            //{
            //    try
            //    {
            //        string[] xmlFiles = Directory.GetFiles(folderPath, "*.xml");

            //        //deletes all xmlFiles to avoid recursive data user
            //        if (xmlFiles.Length > 0)
            //        {
            //            foreach (var item in xmlFiles)
            //            {
            //                File.Delete(item);
            //            }
            //            //exits the app
            //            Application.Current.Shutdown();
            //        }
            //        else { Application.Current.Shutdown(); }
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show($"Error: {ex}", "Error!", MessageBoxButton.OK);
            //    }
            //}
        }

        public string semInfoDisplay(Semester obj)
        {
            return $"Semester Duration: {obj.weeks} weeks\nStart Date: {obj.startDate.ToShortDateString()}\nEnd Date: {obj.endDate.ToShortDateString()}";
        }

        private void moduleDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Module selectedMod = (Module)moduleDataGrid.SelectedItem;
            ModuleCalendarWindow window = new ModuleCalendarWindow(semInfo, selectedMod);

            //displays calendar window
            window.Show();

            //hides current window
            Close();
        }
    }
}
