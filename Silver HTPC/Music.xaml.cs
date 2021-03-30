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
            Button thisButton = e.Source as Button;
            Console.WriteLine(thisButton.Name.ToString());
            thisButton.Background = Brushes.Red;
            thisButton.Height =60;
            //Console.WriteLine(thisButton);
            //MusicButtonsGrids[MusicIndex].Height = 50;
        }
        
        private void Music_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Down)
            {
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



        private void Music_LostFocus(object sender, RoutedEventArgs e)
        {
            Button thisButton = e.Source as Button;
            thisButton.Background = Brushes.White;
            thisButton.Height = 40;
            MusicButtonsGrids[MusicIndex].Height = 40;

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
            Button thisButton = e.Source as Button;
            thisButton.Background = Brushes.White;
        }
    }
}
