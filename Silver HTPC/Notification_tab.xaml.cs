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

namespace Silver_HTPC
{
    /// <summary>
    /// Interaction logic for Notification_tab.xaml
    /// </summary>
    public partial class Notification_tab : Window
    {
        public Notification_tab()
        {
            InitializeComponent();
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Back)
            {
                MainWindow home = new MainWindow();
                home.Show();
                this.Close();
            }
        }
    }
}
