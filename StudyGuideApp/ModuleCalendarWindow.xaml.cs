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
using StudyGuideLibrary;

namespace StudyGuideApp
{
    /// <summary>
    /// Interaction logic for ModuleCalendarWindow.xaml
    /// </summary>
    public partial class ModuleCalendarWindow : Window
    {
        private static ClassMethods obj = new ClassMethods();
        private List<int> weeklyStdHrs= new List<int>();
        public ModuleCalendarWindow(Semester semInfo,Module selectedMod)
        {
            InitializeComponent();

            //sets up the calendar start and end date
            ModuleCalendar.DisplayDateStart = semInfo.startDate;
            ModuleCalendar.DisplayDateEnd = semInfo.endDate;

            //fills the textbox with the module's detailed information
            ModuleInfoTxtBox.AppendText(displayModInfo(selectedMod));


            int weeklyStudyHrs = obj.weeklyHours(selectedMod.credits, semInfo.weeks, selectedMod.classHrsPerWeek);

            for (int x = 0; x < (semInfo.weeks + 1); x++)
            {
                weeklyStdHrs.Add(weeklyStudyHrs);
            }
            weklyStdHrsTxtBox.AppendText(displayWeeklyHrs());
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

        public string displayModInfo(Module modInfo)
        { 
            return $"    Module Infomration\n\nCode: {modInfo.code}\nName: {modInfo.name}\nCredits: {modInfo.credits}\nClass Hours per Week: {modInfo.classHrsPerWeek}\nTotal Study Hours: {obj.studyHours(modInfo.credits)}";
        }

        public string displayWeeklyHrs()
        {
            int cnter = 1;
            string joint = "  Study Hours Per Week\n";
            foreach (var item in weeklyStdHrs)
            {
                joint += $"Week ({cnter}): {item}\n";
                cnter++;
            }
            return joint;
        }

        private void ListViewItem_Selected(object sender, RoutedEventArgs e)
        {

        }
    }
}
