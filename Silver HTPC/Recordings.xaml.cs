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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Silver_HTPC
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Recordings : Window
    {
        private static List<Button> RecordButtonsList = new List<Button>();
        private static List<Grid> RecordButtonsGrids = new List<Grid>();
        private int RecordIndex = 0;
        private Button play;
        public Recordings()
        {
            InitializeComponent();
            RecordButtonsList.Add(record1);
            RecordButtonsList.Add(record2);
            RecordButtonsList.Add(record3);

            RecordButtonsGrids.Add(GridRecord1);
            RecordButtonsGrids.Add(GridRecord2);
            RecordButtonsGrids.Add(GridRecord3);
            record1.Focus();
            
        }
        private void Record_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Down)
            {
                if (RecordIndex < RecordButtonsList.Count - 1)
                {
                    RecordIndex += 1;
                    Console.WriteLine("RecordIndex: " + RecordIndex);
                }
                else
                {
                    RecordIndex = 0;
                    Console.WriteLine("RecordIndex: " + RecordIndex);
                }
            }
            else if (e.Key == Key.Up)
            {
                if (RecordIndex != 0)
                {
                    RecordIndex -= 1;
                    Console.WriteLine("RecordIndex: " + RecordIndex);
                }
                else
                {
                    RecordIndex = RecordButtonsList.Count - 1;
                    Console.WriteLine("RecordIndex: " + RecordIndex);
                }
            }
        }
        private void Recording_GotFocus(object sender, RoutedEventArgs e)
        {
            Button thisButton = e.Source as Button;
            Console.WriteLine(RecordIndex);
            thisButton.Background = Brushes.Red;
            thisButton.Height = 100;
            RecordButtonsGrids[RecordIndex].Height = 100;

            play = new Button();
            play.Width = 100;
            play.Height = 30;
            play.Name = "Play1";
            play.Content = "Play";
            play.Background = Brushes.Aqua;
            play.VerticalContentAlignment = VerticalAlignment.Top;
            play.HorizontalContentAlignment = HorizontalAlignment.Left;
            play.VerticalAlignment = VerticalAlignment.Top;
            play.HorizontalAlignment = HorizontalAlignment.Left;
            play.Margin = new Thickness(0, 0, 0, 10);
            play.FontSize = 13;
            //play.KeyDown += Play_KeyDown;
            //play.GotFocus += Play_GotFocus;
            //play.LostFocus += Play_LostFocus;
            //play.KeyUp += Play_KeyUp;
            Grid.SetColumn(play, 1);
            //Grid.SetColumnSpan(play, 2);
            Grid.SetRow(play, 2);
            //Grid.SetRowSpan(play, 1);
            RecordButtonsGrids[RecordIndex].Children.Add(play);
            //play.Focus();
        }

        private void Recording_LostFocus(object sender, RoutedEventArgs e)
        {
            Button thisButton = e.Source as Button;
            //Console.WriteLine(thisButton.Name.ToString());
            thisButton.Background = Brushes.White;
            thisButton.Height = 60;
            RecordButtonsGrids[RecordIndex].Height = 60;
            RecordButtonsGrids[RecordIndex].Children.Remove(play);

        }



    }
}
