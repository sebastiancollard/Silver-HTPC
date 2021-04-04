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
        private static List<String> CoverPhotosList = new List<String>();
        private int MusicIndex=0;
        private Button play;
        private Button delete;
        private bool DeleteFocused = false;
        private bool PlayFocused = false;
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

            CoverPhotosList.Add("Image/PokerFace.png");
            CoverPhotosList.Add("Image/WalkTheLine.jpg");
            CoverPhotosList.Add("Image/helpBeatles.jpg");
            CoverPhotosList.Add("Image/inmylifeBeatles.jpg");
            // https://stackoverflow.com/questions/43676458/set-focus-on-passwordbox-when-application-starts
            this.Loaded += new RoutedEventHandler(Login_Focus);
            Console.WriteLine("dada");

         

        }

        private void Grid_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {

        }

        void Login_Focus(object sender , RoutedEventArgs e)
        {
            MusicButtonsList[MusicIndex].Focus();
        }

        // https://docs.microsoft.com/en-us/dotnet/desktop/wpf/advanced/how-to-change-the-color-of-an-element-using-focus-events?view=netframeworkdesktop-4.8
        private void Music_GotFocus(object sender, RoutedEventArgs e)
        {
            Button thisButton = sender as Button;
            Console.WriteLine(thisButton.Name.ToString() + Switche);
            thisButton.Height =80;
            MusicButtonsGrids[MusicIndex].Height = 80;
            if (Switche==false)
            {
                thisButton.Background = Brushes.Aqua;

                play = new Button();
                play.Width = 100;
                play.Height = 30;
                play.Name = "Play1";
                play.Content = "Play";
                play.Background = Brushes.Aqua;
                play.VerticalContentAlignment = VerticalAlignment.Top;
                play.HorizontalContentAlignment = HorizontalAlignment.Left;
                play.VerticalAlignment = VerticalAlignment.Bottom;
                play.HorizontalAlignment = HorizontalAlignment.Left;
                play.KeyDown += Play_KeyDown;
                play.GotFocus += Play_GotFocus;
                play.LostFocus += Play_LostFocus;
                play.KeyUp += Play_KeyUp;
                Grid.SetColumn(play, 1);
                Grid.SetColumnSpan(play, 2);
                Grid.SetRow(play, 0);
                Grid.SetRowSpan(play, 1);
                //play.IsEnabled = true;
                //play.Focus();
                MusicButtonsGrids[MusicIndex].Children.Add(play);

               // KeyEventArgs args = new KeyEventArgs(Keyboard.PrimaryDevice,

                //Keyboard.PrimaryDevice.ActiveSource, 0, Key.Down);

                //args.RoutedEvent = Keyboard.KeyDownEvent;

                //InputManager.Current.ProcessInput(args);


                //MusicButtonsGrids[MusicIndex].Children.
                //InputSimulator = new InputSimilator();

                //MusicButtonsList[MusicIndex].Focusable = false;



                delete = new Button();
                delete.Width = 100;
                delete.Height = 30;
                delete.Name = "Delete1";
                delete.Content = "Delete";
                delete.Background = Brushes.Aqua;
                delete.VerticalContentAlignment = VerticalAlignment.Top;
                delete.HorizontalContentAlignment = HorizontalAlignment.Left;
                delete.VerticalAlignment = VerticalAlignment.Bottom;
                delete.HorizontalAlignment = HorizontalAlignment.Left;
                delete.KeyDown += Delete_KeyDown;
                delete.GotFocus += Delete_GotFocus;
                delete.LostFocus += Delete_LostFocus;
                Grid.SetColumn(delete, 2);
                Grid.SetColumnSpan(delete, 2);
                Grid.SetRow(delete, 0);
                Grid.SetRowSpan(delete, 1);

                MusicButtonsGrids[MusicIndex].Children.Add(delete);
                Console.WriteLine("a");
                //System.Threading.Thread.Sleep(1000);
                Switche = true;
                //MusicButtonsList[MusicIndex].Focusable = false;
                play.Focus();
                //Keyboard.ClearFocus();
                //MusicButtonsList[MusicIndex].Focusable = true;
                //Switche = true;

            }
            else
            {
                thisButton.Background = Brushes.White;
                
            }
            Switche = true;

            //StackOverFlow???
            //if (Switche == false)
            // {
            //Keyboard.Focus(play);
            //}

            //Switche = true;
            //Console.WriteLine("Switche" + Switche);





        }

        private void Play_GotFocus(object sender, RoutedEventArgs e)
        {
            Button thisButton = sender as Button;
            //Console.WriteLine("Here");
            thisButton.Background = Brushes.Red;
            PlayFocused = true;
            //MusicButtonsGrids[MusicIndex].Children.
            //play.back
           // ButtonGrid1.Children.Remove(play);
            //MusicButtonsGrids[MusicIndex].Children.Remove(play);
            //MusicButtonsGrids[MusicIndex].Children()
        }
        private void Delete_GotFocus(object sender, RoutedEventArgs e)
        {
            Button thisButton = sender as Button;
            Console.WriteLine("Here");
            thisButton.Background = Brushes.Red;
            DeleteFocused = true;
            //MusicButtonsGrids[MusicIndex].Children.
            //play.back
            // ButtonGrid1.Children.Remove(play);
            //MusicButtonsGrids[MusicIndex].Children.Remove(play);
            //MusicButtonsGrids[MusicIndex].Children()
        }
        private void Delete_LostFocus(object sender, RoutedEventArgs e)
        {
            Button thisButton = sender as Button;
            thisButton.Background = Brushes.Aqua;
            DeleteFocused = false;
            //ButtonGrid1.Children.Remove(thisButton);
            if (MusicIndex != 0)
            {
                MusicButtonsGrids[MusicIndex - 1].Children.Remove(play);
                MusicButtonsGrids[MusicIndex - 1].Children.Remove(delete);
                //MusicButtonsGrids[MusicIndex - 1].Children.Remove((Button) FindName("Play1"));

            }
            else
            {
                MusicButtonsGrids[MusicButtonsGrids.Count - 1].Children.Remove(play);
                MusicButtonsGrids[MusicButtonsGrids.Count - 1].Children.Remove(delete);

                //MusicButtonsGrids[MusicButtonsGrids.Count - 1].Children.Remove((Button) FindName("Play1"));
            }

            if (MusicIndex != MusicButtonsGrids.Count - 1)
            {
                MusicButtonsGrids[MusicIndex + 1].Children.Remove(play);
                MusicButtonsGrids[MusicIndex + 1].Children.Remove(delete);
                // MusicButtonsGrids[MusicIndex + 1].Children.Remove((Button) FindName("Play1"));
            }
            else
            {
                MusicButtonsGrids[0].Children.Remove(play);
                MusicButtonsGrids[0].Children.Remove(delete);
                // MusicButtonsGrids[0].Children.Remove((Button) FindName("Play1"));

            }

        }

            private void Play_LostFocus(object sender, RoutedEventArgs e)
        {
            Button thisButton = sender as Button;
            thisButton.Background = Brushes.Aqua;
            PlayFocused = false;
            Console.WriteLine("MusicIndexL" + MusicIndex);
            //ButtonGrid1.Children.Remove(thisButton);
            if (MusicIndex != 0)
            {
               MusicButtonsGrids[MusicIndex - 1].Children.Remove(play);
               MusicButtonsGrids[MusicIndex - 1].Children.Remove(delete);
                //MusicButtonsGrids[MusicIndex - 1].Children.Remove((Button) FindName("Play1"));

            }
            else
            {
                MusicButtonsGrids[MusicButtonsGrids.Count-1].Children.Remove(play);
                MusicButtonsGrids[MusicButtonsGrids.Count - 1].Children.Remove(delete);

                //MusicButtonsGrids[MusicButtonsGrids.Count - 1].Children.Remove((Button) FindName("Play1"));
            }
            
            if(MusicIndex!= MusicButtonsGrids.Count - 1)
            {
                MusicButtonsGrids[MusicIndex + 1].Children.Remove(play);
                MusicButtonsGrids[MusicIndex + 1].Children.Remove(delete);
                // MusicButtonsGrids[MusicIndex + 1].Children.Remove((Button) FindName("Play1"));
            }
            else
            {
                MusicButtonsGrids[0].Children.Remove(play);
                MusicButtonsGrids[0].Children.Remove(delete);
                // MusicButtonsGrids[0].Children.Remove((Button) FindName("Play1"));

            }
            

            
        }

       







            private void Music_KeyDown(object sender, KeyEventArgs e)
            {
           // for (int i = 0; i < MusicButtonsList.Count; i++)
           // {
           //     MusicButtonsList[i].Focusable = false;
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
            
            else if (e.Key == Key.Right && !PlayFocused && !DeleteFocused)
            {
               
                for(int i=0; i < MusicButtonsList.Count; i++)
                {
                    MusicButtonsList[i].Focusable=false;
                }
                MusicButtonsGrids[MusicIndex].Children.Remove(play);
                MusicButtonsGrids[MusicIndex].Children.Remove(delete);
                Switche = false;
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
                //MusicButtonsList[MusicIndex].Focus();
                this.Loaded += new RoutedEventHandler(Login_Focus);

                

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
                Switche = false;
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
                Switche = false;
            }
            



        }
        private void Play_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Console.WriteLine("Paste Image");
                Image CoverPhoto = new Image();
                CoverPhoto.Source = new BitmapImage(new Uri(CoverPhotosList[MusicIndex], UriKind.RelativeOrAbsolute));
                CoverPhoto.Width = 180;
                CoverPhoto.Height = 140;
                CoverPhoto.VerticalAlignment = VerticalAlignment.Stretch;
                CoverPhoto.HorizontalAlignment = HorizontalAlignment.Stretch;
                CoverPhoto.Stretch = Stretch.Uniform;
                //Grid.SetRow(CoverPhoto, 0);
                //Grid.SetColumn(CoverPhoto ,0);
                Cover.Children.Clear();

                Border br = new Border();
                br.BorderBrush = Brushes.Black;
                br.BorderThickness = new Thickness(1);
                br.Child = CoverPhoto;
                
                Cover.Children.Add(br);
                // new BitmapImage(new Uri(@"pack://application:,,,/Image/spotify-download-logo.png", UriKind.RelativeOrAbsolute));
            }

        }


            private void Delete_KeyDown(object sender, KeyEventArgs e)
        {
            Console.WriteLine("Delete_KEYDOWN");

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
                Switche = false;
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
                Switche = false;
            }
            else if (e.Key == Key.Right)
            {
                SortButton.Focus();
                for (int i = 0; i < MusicButtonsList.Count; i++)
                {
                    MusicButtonsList[i].Focusable = false;
                }
                MusicButtonsGrids[MusicIndex].Children.Remove(play);
                MusicButtonsGrids[MusicIndex].Children.Remove(delete);
                Switche = false;
                Console.WriteLine("MusicIndex: " + MusicIndex);


            }


        }

        private void Music_LostFocus(object sender, RoutedEventArgs e)
        {
            Button thisButton = sender as Button;
            thisButton.Background = Brushes.White;
            thisButton.Height = 50;
            MusicButtonsGrids[MusicIndex].Height = 50;
            //Console.WriteLine(MusicIndex + "a");
            if (MusicIndex != 0)
            {
                MusicButtonsGrids[MusicIndex - 1].Height = 50;
               // MusicIndex += 1;
                
            }
            else
            {
                MusicButtonsGrids[MusicButtonsGrids.Count-1].Height = 50;
                //MusicIndex = 0;
                //MusicButtonsGrids[MusicIndex + 1].Height = 50;
            }

            if (MusicIndex < MusicButtonsGrids.Count - 1)
            {
                MusicButtonsGrids[MusicIndex + 1].Height = 50;
            }
            else
            {
                MusicButtonsGrids[0].Height = 50;
            }
            
            //Switche = false;


            //MusicButtonsList[MusicIndex].Focusable = false;
            //Console.WriteLine("LostMusicFocus " + MusicIndex); Stack overflow

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
