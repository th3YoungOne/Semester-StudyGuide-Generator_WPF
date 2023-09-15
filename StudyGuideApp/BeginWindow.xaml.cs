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
using System.Xml.Linq;
using StudyGuideLibrary;

namespace StudyGuideApp
{
    /// <summary>
    /// Interaction logic for BeginWindow.xaml
    /// </summary>
    public partial class BeginWindow : Window
    {
        public BeginWindow()
        {
            InitializeComponent();
        }
        //semester object from dll library
        Semester semInfo = new Semester();

        //continue button
        private void continueButton_Click(object sender, RoutedEventArgs e)
        {
            //checks if number of weeks box is empty
            if(string.IsNullOrEmpty(textBox.Text)) { MessageBox.Show("Please enter the number of weeks in a semester.", "Empty Field!", MessageBoxButton.OK); }
            else
            {
                //checks if the number of weeks entered is a valid data type
                int numWeeks;
                if (!int.TryParse(textBox.Text, out numWeeks))
                {
                    MessageBox.Show("Please enter a numerical value for the number of weeks in a semester.", "Invalid Input!", MessageBoxButton.OK);
                }
                //saves the number of weeks value entered
                else { semInfo.weeks = Int32.Parse(textBox.Text); }
            }

            //checks if a start date has been selected by the user
            if (!startDate.SelectedDate.HasValue) { MessageBox.Show("Please select a start date for the semseter via the (select a date) tab.", "Unselected Start Date!", MessageBoxButton.OK); }
            else
            {
                //saves the start date to the semester object
                DataContext= semInfo;

                DateTime? selectedDate = datePicker.SelectedDate;

                semInfo.startDate = selectedDate.Value;

                //calculates and saves the end date of the semester
                DateTime endDate = selectedDate.addDays
                semInfo.endDate = selectedDate.Add;
            }

            //creates temporary xml file wil root parent element to save the semester data to
            XDocument xmlDoc = new XDocument(new XElement("Semester"));

            //saves semester info under the "Semester" root element 
            XElement semElement = new XElement("SemesterInfo", new XElement("Duration", semInfo.weeks), new XElement("Start Date", semInfo.startDate), new XElement("End Date", semInfo.endDate));

            //object of the dashboard window
            DashboardWindow window = new DashboardWindow();

            //displays dashboard window
            window.Show();

            //hides current window
            Close();
        }

        //return button
        private void returnButton_Click(object sender, RoutedEventArgs e)
        {
            //object of the main window
            MainWindow window = new MainWindow();

            //displays main window
            window.Show();

            //hides current window
            Close();
        }
    }
}
