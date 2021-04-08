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
        private int Start = 0;
        


        public Music()
        {
            InitializeComponent();
            
            
            MusicButtonsList.Add(music1);
            MusicButtonsList.Add(music2);
            MusicButtonsList.Add(music3);
            MusicButtonsList.Add(music4);
            MusicButtonsList.Add(music5);
            MusicButtonsList.Add(music6);

            MusicButtonsGrids.Add(ButtonGrid1);
            MusicButtonsGrids.Add(ButtonGrid2);
            MusicButtonsGrids.Add(ButtonGrid3);
            MusicButtonsGrids.Add(ButtonGrid4);
            MusicButtonsGrids.Add(ButtonGrid5);
            MusicButtonsGrids.Add(ButtonGrid6);

            CoverPhotosList.Add("Image/PokerFace.png");
            CoverPhotosList.Add("Image/WalkTheLine.jpg");
            CoverPhotosList.Add("Image/helpBeatles.jpg");
            CoverPhotosList.Add("Image/inmylifeBeatles.jpg");
            CoverPhotosList.Add("Image/letsgetmarriedJaggedEdge.jpg");
            CoverPhotosList.Add("Image/iwishCarlThomas.jpg");
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
                delete.KeyUp += Delete_KeyUp;
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
            //Console.WriteLine("HereP");
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
            Console.WriteLine("HereD");
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
            Console.WriteLine("Lost Delete Focus " + Switche);
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
            //MusicButtonsGrids[MusicIndex].Children.Remove(play);
            //MusicButtonsGrids[MusicIndex].Children.Remove(delete);
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
            /**
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
            **/
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
            if (e.Key == Key.Down)
            {
                for (int i = 0; i < MusicButtonsList.Count; i++)
                {
                    MusicButtonsList[i].Focusable = true;
                }
                Keyboard.ClearFocus();
                this.Loaded += new RoutedEventHandler(Login_Focus);
            }
            /**
            if (e.Key == Key.Left)
            {
                
                Console.WriteLine("MusicIndex Left: " + MusicIndex);
                MusicButtonsList[MusicIndex].Focusable = true;
                //MusicButtonsList[MusicIndex].Focus();
                this.Loaded += new RoutedEventHandler(Login_Focus);

                

            }
            **/
        }
        private void Play_KeyDown(object sender, KeyEventArgs e)
        {
            Button thisbutton = sender as Button;
            Console.WriteLine("Play_KEYDOWN");
            // scroll.ScrollToHorizontalOffset(btn.TranslatePoint(new Point(), stack).X - offset);
            if (e.Key == Key.Down)
            {
                ViewMusicList.ScrollToVerticalOffset(thisbutton.TranslatePoint(new Point(), MusicList).Y-50);
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
                    Keyboard.ClearFocus();
                    
                    this.Loaded += new RoutedEventHandler(Login_Focus);
                    ViewMusicList.ScrollToTop();
                }
                //play.Focusable = false;
                //MusicButtonsGrids[MusicIndex].Children.Remove(play);
                //MusicButtonsList[MusicIndex].Focus();
                Switche = false;
            }
            else if(e.Key == Key.Up)
            {
                //SortButton.Focus();
                ViewMusicList.ScrollToVerticalOffset(thisbutton.TranslatePoint(new Point(), MusicList).Y - 150);
                
                if (MusicIndex != 0)
                {
                    MusicIndex -= 1;
                    Console.WriteLine("MusicIndex: " + MusicIndex);
                }
                else
                {
                    //MusicIndex = MusicButtonsList.Count - 1;
                    //Console.WriteLine("MusicIndex: " + MusicIndex);
                    MusicButtonsGrids[0].Children.Remove(play);
                    MusicButtonsGrids[0].Children.Remove(delete);
                    MusicButtonsGrids[0].Height = 50;
                    MusicButtonsList[0].Height = 50;
                    
                    for(int i=0; i< MusicButtonsList.Count; i++)
                    {
                        MusicButtonsList[i].Focusable = false;
                    }
                    //Keyboard.ClearFocus();
                    SortButton.Focus();
                }
                Switche = false;
                
            }
            
            



        }
        private void Play_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter && Start>0)
            {
                Console.WriteLine("Paste Image");
                Image CoverPhoto = new Image();
                CoverPhoto.Source = new BitmapImage(new Uri(CoverPhotosList[MusicIndex], UriKind.RelativeOrAbsolute));
                CoverPhoto.Width = 180;
                CoverPhoto.Height = 140;
                CoverPhoto.VerticalAlignment = VerticalAlignment.Stretch;
                CoverPhoto.HorizontalAlignment = HorizontalAlignment.Stretch;
                CoverPhoto.Stretch = Stretch.UniformToFill;
                //Grid.SetRow(CoverPhoto, 0);
                //Grid.SetColumn(CoverPhoto ,0);
                Cover.Children.Clear();

                Border br = new Border();
                br.BorderBrush = Brushes.Black;
                br.BorderThickness = new Thickness(1);
                br.Child = CoverPhoto;
                
                Cover.Children.Add(br);

                Image reverse = new Image();
                reverse.Source = new BitmapImage(new Uri("Image/reverse.png", UriKind.RelativeOrAbsolute));
                //reverse.Width = 50;
                //reverse.Height = 30;
                //reverse.VerticalAlignment = VerticalAlignment.Top;
                //reverse.VerticalAlignment = VerticalAlignment.Stretch;
                //reverse.HorizontalAlignment = HorizontalAlignment.Stretch;
                reverse.Stretch = Stretch.Uniform;

                Image playPause = new Image();
                playPause.Source = new BitmapImage(new Uri("Image/PlayPause.png", UriKind.RelativeOrAbsolute));
                playPause.Stretch = Stretch.Uniform;

                Image forward = new Image();
                forward.Source = new BitmapImage(new Uri("Image/Forward.png", UriKind.RelativeOrAbsolute));
                forward.Stretch = Stretch.Uniform;

                //playPause.Source = new BitmapImage(new Uri("Image/"));

                MusicOptions.Children.Clear();
                MusicDuration.Children.Clear();

                Button reverseMusic = new Button();
                //playMusic.Content = "But";
                reverseMusic.Height = 30;
                reverseMusic.Width = 50;
                //playMusic.Background = Brushes.Black;
                reverseMusic.Content = reverse;
                reverseMusic.GotFocus += Button_GotFocus;
                reverseMusic.LostFocus += ButtonMusicPlaying_LostFocus;
                //reverseMusic.Focusable = false;

                
                MusicOptions.Children.Add(reverseMusic);

                Button playPauseMusic = new Button();
                playPauseMusic.Height = 30;
                playPauseMusic.Width = 50;
                playPauseMusic.Content = playPause;
                playPauseMusic.GotFocus += Button_GotFocus;
                playPauseMusic.LostFocus += ButtonMusicPlaying_LostFocus;

                MusicOptions.Children.Add(playPauseMusic);

                Button forwardMusic = new Button();
                forwardMusic.Height = 30;
                forwardMusic.Width = 50;
                forwardMusic.Content = forward;
                forwardMusic.GotFocus += Button_GotFocus;
                forwardMusic.LostFocus += ButtonMusicPlaying_LostFocus;

                MusicOptions.Children.Add(forwardMusic);

                Slider slideDuration = new Slider();
                slideDuration.Maximum = 100;
                MusicDuration.Children.Add(slideDuration);
                
                //playMusic.Focus();
                // new BitmapImage(new Uri(@"pack://application:,,,/Image/spotify-download-logo.png", UriKind.RelativeOrAbsolute));
            }
            Start += 1;

        }

        private void Delete_KeyUp(object sender, KeyEventArgs e)
        {
            Button thisbutton = sender as Button;
            if(e.Key == Key.Enter)
            {
                DeleteMessage.Visibility = Visibility.Visible;
                //MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Are you sure?", "Delete Confirmation", System.Windows.MessageBoxButton.YesNo);
                
                

                TextBlock DeleteMessageTb = new TextBlock();
                DeleteMessageTb.Text = "Would you like to delete the following Song:";
                Grid.SetRow(DeleteMessageTb, 0);
                Grid.SetColumn(DeleteMessageTb, 0);
                Grid.SetColumnSpan(DeleteMessageTb, 2);
                DeleteMessageTb.VerticalAlignment = VerticalAlignment.Center;
                DeleteMessageTb.HorizontalAlignment = HorizontalAlignment.Center;
                DeleteMessageTb.FontFamily = new FontFamily("Segoe UI Black");
                DeleteMessageTb.FontSize = 16;

                String searchFor = "SongNameTb" + (MusicIndex +1); 
                String songName = ((TextBlock)MusicButtonsGrids[MusicIndex].FindName(searchFor)).Text;

                TextBlock DeleteSongTb = new TextBlock();
                DeleteSongTb.Text = songName;
                Grid.SetRow(DeleteSongTb,1);
                Grid.SetColumn(DeleteSongTb, 0);
                Grid.SetColumnSpan(DeleteSongTb, 2);
                DeleteSongTb.VerticalAlignment = VerticalAlignment.Center;
                DeleteSongTb.HorizontalAlignment = HorizontalAlignment.Center;
                DeleteSongTb.FontSize = 14;

                Button yes = new Button();
                yes.Width = 50;
                yes.Content = "Yes";
                yes.GotFocus += Button_GotFocus;
                yes.LostFocus += Button_LostFocus;
                yes.KeyUp += Yes_KeyUp;
                Grid.SetRow(yes, 2);
                Grid.SetColumn(yes, 0);
                yes.VerticalAlignment = VerticalAlignment.Center;
                yes.HorizontalAlignment = HorizontalAlignment.Center;

                Button no = new Button();
                no.Width = 50;
                no.Content = "No";
                no.GotFocus += Button_GotFocus;
                no.LostFocus += Button_LostFocus;
                no.KeyUp += No_KeyUp;
                Grid.SetRow(no, 2);
                Grid.SetColumn(no, 1);
                no.VerticalAlignment = VerticalAlignment.Center;
                no.HorizontalAlignment = HorizontalAlignment.Center;



                DeleteMessage.Children.Clear();
                DeleteMessage.Children.Add(DeleteMessageTb);
                DeleteMessage.Children.Add(DeleteSongTb);
                DeleteMessage.Children.Add(yes);
                DeleteMessage.Children.Add(no);

                for (int i = 0; i < MusicButtonsList.Count; i++)
                {
                    MusicButtonsList[i].Focusable = false;
                }

                Keyboard.ClearFocus();
                MusicButtonsGrids[MusicIndex].Children.Remove(play);
                MusicButtonsGrids[MusicIndex].Children.Remove(delete);
                MusicButtonsGrids[MusicIndex].Height = 50;
                MusicButtonsList[MusicIndex].Height = 50;
                yes.Focus();
                //Popup a = new Popup();
                Console.Write("Delete Entered on");
            }
        }

        private void Yes_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key==Key.Enter)
            {
                for (int i = 0; i < MusicButtonsList.Count; i++)
                {
                    MusicButtonsList[i].Focusable = true;
                }
                DeleteMessage.Visibility = Visibility.Hidden;
                MusicList.Children.Remove(MusicButtonsList[MusicIndex]);
                MusicButtonsList.RemoveAt(MusicIndex);
                MusicButtonsGrids.RemoveAt(MusicIndex);
                CoverPhotosList.RemoveAt(MusicIndex);


                Keyboard.ClearFocus();
                Switche = false;
                if (MusicButtonsList.Count == MusicIndex)
                {
                    MusicIndex -= 1;
                    MusicButtonsList[MusicIndex].Focus();
                }
                else if (MusicButtonsList.Count > 0) {
                    //MusicIndex += 1;
                    MusicButtonsList[MusicIndex].Focus();
                }
                else
                {
                    SortButton.Focus();
                }
                
                //this.Loaded+= new RoutedEventHandler(Login_Focus);

            }

        }

        private void No_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                for (int i = 0; i < MusicButtonsList.Count; i++)
                {
                    MusicButtonsList[i].Focusable = true;
                }
                DeleteMessage.Visibility = Visibility.Hidden;
                Switche = false;
                MusicButtonsList[MusicIndex].Focus();

            }
        }



            private void Delete_KeyDown(object sender, KeyEventArgs e)
        {
            Button thisbutton = sender as Button;
            Console.WriteLine("Delete_KEYDOWN");

            if (e.Key == Key.Down)
            {
                ViewMusicList.ScrollToVerticalOffset(thisbutton.TranslatePoint(new Point(), MusicList).Y - 50);
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
                    Keyboard.ClearFocus();

                    this.Loaded += new RoutedEventHandler(Login_Focus);
                    ViewMusicList.ScrollToTop();
                }
                //play.Focusable = false;
                //MusicButtonsGrids[MusicIndex].Children.Remove(play);
                //MusicButtonsList[MusicIndex].Focus();
                Switche = false;
            }
            else if (e.Key == Key.Up)
            {
                ViewMusicList.ScrollToVerticalOffset(thisbutton.TranslatePoint(new Point(), MusicList).Y - 150);
                if (MusicIndex != 0)
                {
                    MusicIndex -= 1;
                    Console.WriteLine("MusicIndex: " + MusicIndex);
                }
                else
                {
                    //MusicIndex = MusicButtonsList.Count - 1;
                    //Console.WriteLine("MusicIndex: " + MusicIndex);
                    MusicButtonsGrids[0].Children.Remove(play);
                    MusicButtonsGrids[0].Children.Remove(delete);
                    MusicButtonsGrids[0].Height = 50;
                    MusicButtonsList[0].Height = 50;

                    for (int i = 0; i < MusicButtonsList.Count; i++)
                    {
                        MusicButtonsList[i].Focusable = false;
                    }
                    //Keyboard.ClearFocus();
                    SortButton.Focus();
                }
                //Switche = false;
                Switche = false;
            }
            /**
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
            **/


        }

        private void Music_LostFocus(object sender, RoutedEventArgs e)
        {
            Button thisButton = sender as Button;
            thisButton.Background = Brushes.White;
            thisButton.Height = 50;
            MusicButtonsGrids[MusicIndex].Height = 50;
            Console.WriteLine(MusicIndex + "a");
            if (MusicIndex != 0)
            {
                MusicButtonsGrids[MusicIndex - 1].Height = 50;
                MusicButtonsList[MusicIndex - 1].Height = 50;
                // MusicIndex += 1;

            }
            else
            {
                MusicButtonsGrids[MusicButtonsGrids.Count-1].Height = 50;
                MusicButtonsList[MusicButtonsGrids.Count - 1].Height = 50;
                //MusicIndex = 0;
                //MusicButtonsGrids[MusicIndex + 1].Height = 50;
            }

            if (MusicIndex < MusicButtonsGrids.Count - 1)
            {
                MusicButtonsGrids[MusicIndex + 1].Height = 50;
                MusicButtonsList[MusicIndex + 1].Height = 50;
            }
            else
            {
                MusicButtonsGrids[0].Height = 50;
                MusicButtonsList[0].Height = 50;
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
            //thisButton.Height = 44;
        }

        private void ButtonMusicPlaying_LostFocus(object sender, RoutedEventArgs e)
        {
            Button thisButton = sender as Button;
            thisButton.Background = Brushes.White;
            
        }
        private void Button_GotFocus(object sender, RoutedEventArgs e)
        {
            Button thisButton = sender as Button;
            thisButton.Background = Brushes.Red;
            //thisButton.Height = 60;
        }
    }
}
