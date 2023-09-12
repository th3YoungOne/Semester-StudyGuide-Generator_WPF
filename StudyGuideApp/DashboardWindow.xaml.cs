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

        }
    }
}
