using System;
using System.IO;
using System.Linq;
using System.Windows;
using System.Xml.Linq;

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
            //obj of the module class
            StudyGuideLibrary.Module module = new StudyGuideLibrary.Module();   

            //checks if module code is entered
            if (string.IsNullOrEmpty(textBox.Text)) { MessageBox.Show("You must enter a module code to proceed.", "No Module Code Entered!", MessageBoxButton.OK); }
            else
            {
                module.code = textBox.Text;
                if (string.IsNullOrEmpty(textBox2.Text)){ MessageBox.Show("You must enter a module name to proceed.", "No Module Name Entered!", MessageBoxButton.OK); }
                else
                {
                    module.name = textBox2.Text;
                    int numCreds;
                    if(!int.TryParse(textBox3.Text, out numCreds)){ MessageBox.Show("You must enter the number of credits for the module to proceed.", "No Module Credits Entered!", MessageBoxButton.OK); }
                    else
                    {
                        module.credits= numCreds;
                        int numHrsWeek;
                        if (!int.TryParse(textBox4.Text, out numHrsWeek)) { MessageBox.Show("You must enter the number of weeks for the module to proceed.", "No Module Weeks Entered!", MessageBoxButton.OK); }
                        else
                        {
                            module.classHrsPerWeek= numHrsWeek;
                        }
                    }
                }
            }
            //@"C:\Users\lab_services_student\Documents\GitHub\Semester-StudyGuide-Generator_WPF\StudyGuideApp\bin\Debug"
            string FileName = "ModuleData.xml";
            if (File.Exists(FileName))
            {
                XDocument doc = XDocument.Load(FileName);

                XElement newMod = new XElement("ModuleInfo", new XElement("Code", module.code), new XElement("Name", module.name), new XElement("Credits", module.credits), new XElement("HoursPerWeek", module.classHrsPerWeek));
                
                var parentElement = doc.Descendants("Module").First();
                parentElement.Add(newMod);
                doc.Save(FileName);
            }
            else
            {
                //creates temporary xml file wil root parent element to save the module data to
                XDocument xmlDoc = new XDocument(new XElement("Module"));

                //saves module info under the "Semester" root element 
                XElement firstMod = new XElement("ModuleInfo", new XElement("Code", module.code), new XElement("Name", module.name), new XElement("Credits", module.credits), new XElement("HoursPerWeek", module.classHrsPerWeek));

                //adds the modElement to xml element
                xmlDoc.Root?.Add(firstMod);
                //saves the xml doc into a file
                xmlDoc.Save("ModuleData.xml");
            }

            MessageBox.Show("Module Information Saved!", "Message", MessageBoxButton.OK);

            //object of the calendar window
            DashboardWindow window = new DashboardWindow();

            //displays calendar window
            window.Show();

            //hides current window
            Close();
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
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
