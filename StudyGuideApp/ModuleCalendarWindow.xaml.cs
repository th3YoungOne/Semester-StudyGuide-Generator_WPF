using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Configuration;
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
using Microsoft.VisualBasic;
using StudyGuideLibrary;

namespace StudyGuideApp
{
    /// <summary>
    /// Interaction logic for ModuleCalendarWindow.xaml
    /// </summary>
    public partial class ModuleCalendarWindow : Window
    {
        Module modObj;

        private static ClassMethods obj = new ClassMethods();
        private List<double> weeklyStdHrs= new List<double>();
        private List<ModuleCalendar> hrsStudied = new List<ModuleCalendar>();
        public ModuleCalendarWindow(Semester semInfo,Module selectedMod)
        {
            InitializeComponent();

            //makes the object accessable all over the window
            modObj = selectedMod;

            //sets up the calendar start and end date
            ModuleCalendar.DisplayDateStart = semInfo.startDate;
            ModuleCalendar.DisplayDateEnd = semInfo.endDate;

            //loads any dates and hours studied for each specific modular
            string FileName = $"CalendarData.xml";
            if (File.Exists(FileName))
            {
                XDocument readModDoc = XDocument.Load(FileName);
                XElement moduleElement = readModDoc.Root.Elements($"{modObj.code}_info").FirstOrDefault();
                if (moduleElement != null)
                {
                    var callElements = readModDoc.Descendants($"{selectedMod.code}_info").ToList();
                    int cnt = 1;
                    foreach (var calElement in callElements)
                    {
                        MessageBox.Show($"number {cnt}");
                        ModuleCalendar date_hours = new ModuleCalendar
                        {
                            studyDate = DateTime.TryParse(calElement.Element("Date")?.Value, out DateTime startDate) ? startDate : DateTime.MinValue,
                            hoursStudied = int.TryParse(calElement.Element("Hours")?.Value, out int credits) ? credits : 0,
                        };
                        hrsStudied.Add(date_hours);
                    }
                }
            }

                //fills the textbox with the module's detailed information
                ModuleInfoTxtBox.AppendText(displayModInfo());


            double weeklyStudyHours = obj.weeklyHours(selectedMod.credits, semInfo.weeks, selectedMod.classHrsPerWeek);
            for (int x = 0; x < semInfo.weeks; x++)
            {
                weeklyStdHrs.Add(weeklyStudyHours);
            }

            //modifies the weekly hours studied, if there are any previous dates saved by the user that they have studied on
            int cnter = 0;
            double totHrs = 0.0;
            foreach (var item in hrsStudied)
            {
                totHrs += item.hoursStudied;
            }

            while (cnter < weeklyStdHrs.Count && totHrs != 0)
            {
                if (weeklyStdHrs[cnter] < totHrs)
                {
                    totHrs -= weeklyStdHrs[cnter];
                    weeklyStdHrs[cnter] = 0;
                }
                else
                {
                    weeklyStdHrs[cnter] -= totHrs;
                    totHrs = 0.0;
                }
                cnter++;
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

        public string displayModInfo()
        {
            ModuleInfoTxtBox.Document.Blocks.Clear();
            //gets the total hours studied for the module
            double totHrs = 0.0;
            foreach (var item in hrsStudied)
            {
                totHrs += item.hoursStudied;
            }

            return $"    Module Infomration\n\nCode: {modObj.code}\nName: {modObj.name}\nCredits: {modObj.credits}\nClass Hours per Week: {modObj.classHrsPerWeek}\nTotal Study Hours: {(obj.totStudyHours(modObj.credits) - totHrs)}";
        }

        public string displayWeeklyHrs()
        {
            int cnter = 1;

            weklyStdHrsTxtBox.Document.Blocks.Clear();
            string joint = "  Study Hours Per Week\n";
            foreach (var item in weeklyStdHrs)
            {
                string formatHrs = item.ToString("0.0");
                string[] hrsSplit = formatHrs.Split('.');
                joint += $"~ Week ({cnter}): {hrsSplit[0]}hrs {int.Parse(hrsSplit[1]) * 6}min\n";
                cnter++;
            }
            return joint;
        }

        private void ModuleCalendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime selectedDate = ModuleCalendar.SelectedDate ?? DateTime.MinValue;

            string studyHrs = Interaction.InputBox($"Enter your study hours for {selectedDate.ToLongDateString()}", $"{selectedDate.ToLongDateString()}");
            if(double.TryParse(studyHrs,out double hours))
            {
                hrsStudied.Add(new ModuleCalendar
                {
                   studyDate = selectedDate,
                    hoursStudied = hours
                });
                ModifyHrs(hours);


                string FileName = $"CalendarData.xml";
                if (File.Exists(FileName))
                {
                    try
                    {
                        XDocument doc = XDocument.Load(FileName);

                        XElement moduleElement = doc.Root.Elements($"{modObj.code}_info").FirstOrDefault();

                        //if the module element doesn't exist in the xml file, it means no dates have been sved yet so it creats a new element
                        if (moduleElement == null)
                        {
                            moduleElement = new XElement($"{modObj.code}_info");
                            doc.Root.Add(moduleElement);
                        }

                        XElement dateStudied = new XElement("Date", selectedDate.ToShortDateString());
                        XElement hoursStudied = new XElement("Hours", hours);

                        moduleElement.Add(dateStudied, hoursStudied);
                        doc.Save(FileName);
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show($"Error: {ex}");
                    }
                }
                else
                {
                    //creates temporary xml file wil root parent element to save the module data to
                    XDocument xmlDoc = new XDocument(new XElement("Calendar"));

                    //saves module info under the calendar root element 
                    XElement studyLog = new XElement($"{modObj.code}_info", new XElement("Date", selectedDate.ToShortDateString()), new XElement("Hours", hours));

                    //adds the calendar Element to xml element
                    xmlDoc.Root?.Add(studyLog);
                    //saves the xml doc into a file
                    xmlDoc.Save("CalendarData.xml");
                }
            }
            else
            {
                MessageBox.Show("Please enter a double value for the hours studied IE: 2.0", "Invalid Information Entered!", MessageBoxButton.OK);
            }
        }

        //this method is to modify the hours that te user has left to study for each specific module
        private void ModifyHrs(double hours)
        {
            int cnter = 0;
            while (cnter < weeklyStdHrs.Count && hours != 0.0)
            {
                if (weeklyStdHrs[cnter] < hours)
                {
                    hours -= weeklyStdHrs[cnter];
                    weeklyStdHrs[cnter] = 0.0;
                }
                else
                {
                    weeklyStdHrs[cnter] -= hours;
                    hours = 0.0;
                }
                cnter++;
            }
            ModuleInfoTxtBox.AppendText(displayModInfo());
            weklyStdHrsTxtBox.AppendText(displayWeeklyHrs());
        }

        private void datesStudiedButton_Click(object sender, RoutedEventArgs e)
        {
            string joint = "";
            foreach (var item in hrsStudied)
            {
                joint += $"~ Date: {item.studyDate.ToShortDateString()}\nHours Studied: {item.hoursStudied}hrs\n\n";
            }
            textBox.Text= joint;
            textBox.Visibility= Visibility.Visible;
            closeStudiedButton.Visibility = Visibility.Visible;
            datesStudiedButton.Visibility= Visibility.Hidden;  
        }

        private void closeStudiedButton_Click(object sender, RoutedEventArgs e)
        {
            textBox.Clear();
            textBox.Visibility = Visibility.Hidden;
            closeStudiedButton.Visibility = Visibility.Hidden;
            datesStudiedButton.Visibility = Visibility.Visible;
        }
    }
}
