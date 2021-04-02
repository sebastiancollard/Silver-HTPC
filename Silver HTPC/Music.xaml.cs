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

namespace Silver_HTPC
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Music : Window
    {
        private static List<Button> MusicButtonsList = new List<Button>();
        private static List<Grid> MusicButtonsGrids = new List<Grid>();
        private int MusicIndex=0;
        private Button play;
        private bool Switche = false;


        public Music()
        {
            InitializeComponent();

            MusicButtonsList.Add(music1);
            MusicButtonsList.Add(music2);
            MusicButtonsList.Add(music3);
            MusicButtonsList.Add(music4);

            MusicButtonsGrids.Add(ButtonGrid1);
            MusicButtonsGrids.Add(ButtonGrid2);
            MusicButtonsGrids.Add(ButtonGrid3);
            MusicButtonsGrids.Add(ButtonGrid4);

            MusicButtonsList[MusicIndex].Focus();
            Console.WriteLine("dada");

         

        }

        private void Grid_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {

        }

        // https://docs.microsoft.com/en-us/dotnet/desktop/wpf/advanced/how-to-change-the-color-of-an-element-using-focus-events?view=netframeworkdesktop-4.8
        private void Music_GotFocus(object sender, RoutedEventArgs e)
        {
            Button thisButton = sender as Button;
            Console.WriteLine(thisButton.Name.ToString());
            thisButton.Height =80;
            MusicButtonsGrids[MusicIndex].Height = 80;

            if (Switche==false)
            {
                thisButton.Background = Brushes.Red;

                play = new Button();
                play.Width = 100;
                play.Height = 30;
                //play.Name = "Play1";
                play.Content = "Play";
                play.Background = Brushes.Aqua;
                play.VerticalContentAlignment = VerticalAlignment.Top;
                play.HorizontalContentAlignment = HorizontalAlignment.Left;
                play.VerticalAlignment = VerticalAlignment.Bottom;
                play.HorizontalAlignment = HorizontalAlignment.Left;
                play.KeyDown += Play_KeyDown;
                play.GotFocus += Play_GotFocus;
                play.LostFocus += Play_LostFocus;
                Grid.SetColumn(play, 1);
                Grid.SetColumnSpan(play, 2);
                Grid.SetRow(play, 0);
                Grid.SetRowSpan(play, 1);

                MusicButtonsGrids[MusicIndex].Children.Add(play);
                //MusicButtonsGrids[MusicIndex].Children.Remove(play);
                //Console.WriteLine(thisButton);
            }
            else
            {
                thisButton.Background = Brushes.White;
            }
            Switche = true;

        }

        private void Play_GotFocus(object sender, RoutedEventArgs e)
        {
            Button thisButton = sender as Button;
            Console.WriteLine("Here");
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
            //thisButton.Background = Brushes.Black;
            //ButtonGrid1.Children.Remove(thisButton);
            Switche = false;
            if (MusicIndex != 0)
            {
                MusicButtonsGrids[MusicIndex - 1].Children.Remove(thisButton);

            }
            else
            {
                MusicButtonsGrids[MusicButtonsGrids.Count-1].Children.Remove(thisButton);
            }

            if(MusicIndex!= MusicButtonsGrids.Count - 1)
            {
                MusicButtonsGrids[MusicIndex + 1].Children.Remove(thisButton);
            }
            else
            {
                MusicButtonsGrids[0].Children.Remove(thisButton);
            }
        }
            
                
            

        


            private void Music_KeyDown(object sender, KeyEventArgs e)
            {
           // for (int i = 0; i < MusicButtonsList.Count; i++)
           // {
            //    MusicButtonsList[i].Focusable = true;
            //}
            
            if (e.Key == Key.Down)
            {

                //play.Focus();
                
                /**
                if (MusicIndex < MusicButtonsList.Count - 1)
                {
                    MusicIndex += 1;
                    Console.WriteLine("MusicIndex: " + MusicIndex);
                }
                else
                {
                    MusicIndex = 0;
                    Console.WriteLine("MusicIndex: " + MusicIndex);
                }
                **/
                
                
                
            }
            
            else if (e.Key == Key.Right)
            {
               
                for(int i=0; i < MusicButtonsList.Count; i++)
                {
                    MusicButtonsList[i].Focusable=false;
                }
                SortButton.Focus();
                Console.WriteLine("MusicIndex: " + MusicIndex);

            }
            else if (e.Key == Key.Up)
            {
                
            }
            /**
            int tempMusicIndex = MusicIndex + 1;
            if (tempMusicIndex < MusicButtonsList.Count())
            {
                Console.WriteLine("MusicIndex: " + MusicIndex);
                Console.WriteLine("MusicSize: " + MusicButtonsList.Count());
                MusicIndex += 1;
                MusicButtonsList[MusicIndex].Focus();
            }
            **/
        }

        /**
        private void Music_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Up)
            {
                if (MusicIndex != 0)
                {
                    MusicIndex -= 1;
                    Console.WriteLine("MusicIndex: " + MusicIndex);
                }
                else
                {
                    MusicIndex = MusicButtonsList.Count - 1;
                    Console.WriteLine("MusicIndex: " + MusicIndex);
                }
            }
            
        }
        **/

        private void Button_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Left)
            {
                
                Console.WriteLine("MusicIndex Left: " + MusicIndex);
                MusicButtonsList[MusicIndex].Focusable = true;
                MusicButtonsList[MusicIndex].Focus();

            }
        }
        private void Play_KeyDown(object sender, KeyEventArgs e)
        {
            Console.WriteLine("Play_KEYDOWN");

            if (e.Key == Key.Down)
            {
               // for (int i = 0; i < MusicButtonsList.Count; i++)
                //{
                 //   MusicButtonsList[i].Focusable = true;
               // }

                if (MusicIndex < MusicButtonsList.Count - 1)
                {
                    MusicIndex += 1;
                    Console.WriteLine("MusicIndexP: " + MusicIndex);
                }
                else
                {
                    MusicIndex = 0;
                    Console.WriteLine("MusicIndexP: " + MusicIndex);
                }
                //play.Focusable = false;
                //MusicButtonsGrids[MusicIndex].Children.Remove(play);
                //MusicButtonsList[MusicIndex].Focus();
            }
            else if(e.Key == Key.Up)
            {
                if (MusicIndex != 0)
                {
                    MusicIndex -= 1;
                    Console.WriteLine("MusicIndex: " + MusicIndex);
                }
                else
                {
                    MusicIndex = MusicButtonsList.Count - 1;
                    Console.WriteLine("MusicIndex: " + MusicIndex);
                }
            }
            

        }

            private void Music_LostFocus(object sender, RoutedEventArgs e)
        {
            Button thisButton = sender as Button;
            thisButton.Background = Brushes.White;
            thisButton.Height = 50;
            MusicButtonsGrids[MusicIndex].Height = 50;

            /**
            if (MusicIndex!=0 && MusicIndex < MusicButtonsList.Count - 1)
            {
                MusicButtonsGrids[MusicIndex].Height = 40;
            }
            **/

            /**
            for(int i=0; i<MusicButtonsGrids.Count; i++)
            {
                if (i != MusicIndex)
                {
                    MusicButtonsGrids[i].Height = 40;
                }
            }
            **/
        }
        private void Button_LostFocus(object sender, RoutedEventArgs e)
        {
            Button thisButton = sender as Button;
            thisButton.Background = Brushes.White;
            thisButton.Height = 44;
        }
        private void Button_GotFocus(object sender, RoutedEventArgs e)
        {
            Button thisButton = sender as Button;
            thisButton.Background = Brushes.Red;
            thisButton.Height = 60;
        }
    }
}
