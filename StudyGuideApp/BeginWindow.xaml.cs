﻿using System;
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
    /// Interaction logic for BeginWindow.xaml
    /// </summary>
    public partial class BeginWindow : Window
    {
        public BeginWindow()
        {
            InitializeComponent();
        }

        Semester semInfo = new Semester();
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

            if (!startDate.SelectedDate.HasValue) { MessageBox.Show("Please select a start date for the semseter via the (select a date) tab.", "Unselected Start Date!", MessageBoxButton.OK); }
            else
            {
                DateTime? selectedDate = startDate.SelectedDate.GetValueOrDefault();
            }


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
