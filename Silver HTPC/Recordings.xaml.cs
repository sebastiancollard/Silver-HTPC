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
        private Button delete;
        private bool showRecordingButtons = false;
        public Recordings()
        {
            InitializeComponent();
            RecordButtonsList.Add(record1);
            RecordButtonsList.Add(record2);
            RecordButtonsList.Add(record3);

            RecordButtonsGrids.Add(GridRecord1);
            RecordButtonsGrids.Add(GridRecord2);
            RecordButtonsGrids.Add(GridRecord3);
            this.Loaded += new RoutedEventHandler(Login_Focus);

        }

        void Login_Focus(object sender, RoutedEventArgs e)
        {
            RecordButtonsList[RecordIndex].Focus();
        }
        private void Record_KeyDown(object sender, KeyEventArgs e)
        {
            /**
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
            **/
        }
        private void Recording_GotFocus(object sender, RoutedEventArgs e)
        {
            Button thisButton = sender as Button;
            Console.WriteLine(showRecordingButtons);
            Sort_Button.Focusable = false;
            DeleteMultiple_Button.Focusable = false;
            thisButton.Height = 100;
            RecordButtonsGrids[RecordIndex].Height = 100;

            if (showRecordingButtons == false)
            {

                Console.WriteLine("Focusing");
                //thisButton.Background = Brushes.Red;


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
                play.KeyDown += Play_KeyDown;
                play.GotFocus += Play_GotFocus;
                play.LostFocus += Play_LostFocus;
                //play.KeyUp += Play_KeyUp;
                Grid.SetColumn(play, 1);
                //Grid.SetColumnSpan(play, 2);
                Grid.SetRow(play, 2);
                //Grid.SetRowSpan(play, 1);

                delete = new Button();
                delete.Width = 100;
                delete.Height = 30;
                delete.Name = "Delete1";
                delete.Content = "Delete";
                delete.Background = Brushes.Aqua;
                delete.VerticalContentAlignment = VerticalAlignment.Top;
                delete.HorizontalContentAlignment = HorizontalAlignment.Left;
                delete.VerticalAlignment = VerticalAlignment.Top;
                delete.HorizontalAlignment = HorizontalAlignment.Right;
                delete.KeyDown += Delete_KeyDown;
                delete.GotFocus += Delete_GotFocus;
                delete.LostFocus += Delete_LostFocus;
                //delete.KeyUp += Delete_KeyUp;
                Grid.SetColumn(delete, 1);
                //Grid.SetColumnSpan(delete, 2);
                Grid.SetRow(delete, 2);
                //Grid.SetRowSpan(delete, 1);
                Console.WriteLine("Adding");

                RecordButtonsGrids[RecordIndex].Children.Add(play);
                RecordButtonsGrids[RecordIndex].Children.Add(delete);
                showRecordingButtons = true;
                play.Focus();

            }
            else
            {
                showRecordingButtons = true;
                thisButton.Background = Brushes.White;
            }
        }

        private void Recording_LostFocus(object sender, RoutedEventArgs e)
        {
            Button thisButton = e.Source as Button;
            Console.WriteLine("Lost");
            thisButton.Background = Brushes.White;
            // This works for some weird reason
            play.Background = Brushes.Aqua;
            delete.Background = Brushes.Aqua;

            //thisButton.Height = 60;
            Console.WriteLine("R: " + RecordIndex);
            //RecordButtonsGrids[RecordIndex].Height = 60;
            //RecordButtonsGrids[RecordIndex].Children.Remove(play);
            if (RecordIndex != 0)
            {
                RecordButtonsGrids[RecordIndex - 1].Height = 60;
                RecordButtonsList[RecordIndex - 1].Height = 60;
                //MusicButtonsGrids[MusicIndex - 1].Children.Remove((Button) FindName("Play1"));

            }
            else
            {
                RecordButtonsGrids[RecordButtonsGrids.Count - 1].Height = 60;
                RecordButtonsList[RecordButtonsGrids.Count - 1].Height = 60;

                //MusicButtonsGrids[MusicButtonsGrids.Count - 1].Children.Remove((Button) FindName("Play1"));
            }

            if (RecordIndex != RecordButtonsGrids.Count - 1)
            {
                RecordButtonsGrids[RecordIndex + 1].Height = 60;
                RecordButtonsList[RecordIndex + 1].Height = 60;
                // MusicButtonsGrids[MusicIndex + 1].Children.Remove((Button) FindName("Play1"));
            }
            else
            {
                RecordButtonsGrids[0].Height = 60;
                RecordButtonsList[0].Height = 60;
                // MusicButtonsGrids[0].Children.Remove((Button) FindName("Play1"));

            }

        }

        private void Play_GotFocus(object sender, RoutedEventArgs e)
        {
            
            Button thisButton = sender as Button;
            thisButton.Background = Brushes.Red;
           
        }
        private void Delete_GotFocus(object sender, RoutedEventArgs e)
        {
            Button thisButton = sender as Button;
            Console.WriteLine("HereD");
            thisButton.Background = Brushes.Red;

            //MusicButtonsGrids[MusicIndex].Children.
            //play.back
            // ButtonGrid1.Children.Remove(play);
            //MusicButtonsGrids[MusicIndex].Children.Remove(play);
            //MusicButtonsGrids[MusicIndex].Children()
        }
        private void Play_LostFocus(object sender, RoutedEventArgs e)
        {
            Button thisButton = sender as Button;
            thisButton.Background = Brushes.Aqua;
            Console.WriteLine("RecordIndexL" + RecordIndex);
            //RecordButtonsGrids[RecordIndex].Children.Remove(play);

            //ButtonGrid1.Children.Remove(thisButton);
            //MusicButtonsGrids[MusicIndex].Children.Remove(play);
            //MusicButtonsGrids[MusicIndex].Children.Remove(delete);
            
            if (RecordIndex != 0)
            {
                RecordButtonsGrids[RecordIndex - 1].Children.Remove(play);
                RecordButtonsGrids[RecordIndex - 1].Children.Remove(delete);
                //MusicButtonsGrids[MusicIndex - 1].Children.Remove((Button) FindName("Play1"));

            }
            else
            {
                RecordButtonsGrids[RecordButtonsGrids.Count - 1].Children.Remove(play);
                RecordButtonsGrids[RecordButtonsGrids.Count - 1].Children.Remove(delete);

                //MusicButtonsGrids[MusicButtonsGrids.Count - 1].Children.Remove((Button) FindName("Play1"));
            }

            if (RecordIndex != RecordButtonsGrids.Count - 1)
            {
                RecordButtonsGrids[RecordIndex + 1].Children.Remove(play);
                RecordButtonsGrids[RecordIndex + 1].Children.Remove(delete);
                // MusicButtonsGrids[MusicIndex + 1].Children.Remove((Button) FindName("Play1"));
            }
            else
            {
                RecordButtonsGrids[0].Children.Remove(play);
                RecordButtonsGrids[0].Children.Remove(delete);
                // MusicButtonsGrids[0].Children.Remove((Button) FindName("Play1"));

            }
            
            



        }
        private void Delete_LostFocus(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Lost Delete Focus ");
            Button thisButton = sender as Button;
            thisButton.Background = Brushes.Aqua;

            //ButtonGrid1.Children.Remove(thisButton);
            
            if (RecordIndex != 0)
            {
                RecordButtonsGrids[RecordIndex - 1].Children.Remove(play);
                RecordButtonsGrids[RecordIndex - 1].Children.Remove(delete);
                //MusicButtonsGrids[MusicIndex - 1].Children.Remove((Button) FindName("Play1"));

            }
            else
            {
                RecordButtonsGrids[RecordButtonsGrids.Count - 1].Children.Remove(play);
                RecordButtonsGrids[RecordButtonsGrids.Count - 1].Children.Remove(delete);

                //MusicButtonsGrids[MusicButtonsGrids.Count - 1].Children.Remove((Button) FindName("Play1"));
            }

            if (RecordIndex != RecordButtonsGrids.Count - 1)
            {
                RecordButtonsGrids[RecordIndex + 1].Children.Remove(play);
                RecordButtonsGrids[RecordIndex + 1].Children.Remove(delete);
                // MusicButtonsGrids[MusicIndex + 1].Children.Remove((Button) FindName("Play1"));
            }
            else
            {
                RecordButtonsGrids[0].Children.Remove(play);
                RecordButtonsGrids[0].Children.Remove(delete);
                // MusicButtonsGrids[0].Children.Remove((Button) FindName("Play1"));

            }
            

        }
        private void Delete_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Down)
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
                showRecordingButtons = false;
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
                showRecordingButtons = false;
            }

        }
            private void Play_KeyDown(object sender, KeyEventArgs e)
        {
            Button thisbutton = sender as Button;
            Console.WriteLine("Play_KEYDOWN");
            // scroll.ScrollToHorizontalOffset(btn.TranslatePoint(new Point(), stack).X - offset);
            if (e.Key == Key.Down)
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
                showRecordingButtons = false;
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
                showRecordingButtons = false;
            }
            






        }



    }
}
