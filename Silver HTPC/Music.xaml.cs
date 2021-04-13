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
using System.Windows.Threading;
using System.Windows.Media.Effects;




namespace Silver_HTPC
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Music : Window
    {
        private List<Button> MusicButtonsList = new List<Button>();
        private List<Grid> MusicButtonsGrids = new List<Grid>();
        private List<String> CoverPhotosList = new List<String>();
        private int MusicIndex=0;
        private Button play;
        private Button delete;
        private Button reverseMusic = new Button();
        private Button playPauseMusic;
        private Button forwardMusic;
        private DateTime startTime;
        private DispatcherTimer timer;
        private DateTime addonTimer;
        private int timeInc = 0;
        private int timeDec = 0;
        private string songDuration;
        //private Slider slideDuration;
        private TextBlock currentMusicTimer;
        private int totalSeconds = 0;
        private DispatcherTimer dispatcherTimer;
        private bool Switche = false;
        private bool keepPlayFocus = false;
        private bool keepDeleteFocus = false;
        private int Start = 0;

        private DispatcherTimer dispatcherTimerTime;

        // (Style)FindResource("MyButtonStyle");
        //  (LinearGradientBrush)FindResource("ButtonHoverBackground");

        public Music()
        {
            dispatcherTimerTime = new DispatcherTimer();
            dispatcherTimerTime.Interval = new TimeSpan(0, 0, 5);
            DispatcherTimer timer = new DispatcherTimer(new TimeSpan(0, 0, 1), DispatcherPriority.Normal, delegate
            {
                this.guide_time.Content = DateTime.Now.ToString("hh:mm tt");
                this.guide_date.Content = DateTime.Now.ToString("MMMM dd, yyyy");
            }, this.Dispatcher);



            Console.WriteLine("Starting Program");
            reverseMusic.Visibility = Visibility.Hidden;
            InitializeComponent();
            //Music.

            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 5);


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
            //Switche = false;
           

            

         

        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {//For notification
         //Things which happen after 1 timer interval

            Notification_popup0.Visibility = Visibility.Collapsed;

            //Disable the timer
            dispatcherTimer.IsEnabled = false;
        }

        private void Music_GotFocus(object sender, RoutedEventArgs e)
        {
            Button thisButton = sender as Button;
            Console.WriteLine(thisButton.Name.ToString() + Switche);
            thisButton.Height = 80;
            MusicButtonsGrids[MusicIndex].Height = 80;
            if (!Switche)
            {
                Console.WriteLine("adding Buttons");
                //thisButton.Background = Brushes.Aqua;

                play = new Button();
                play.Width = 100;
                play.Height = 30;
                play.Name = "Play1";
                play.Content = "Play";
                
                play.VerticalContentAlignment = VerticalAlignment.Top;
                play.VerticalContentAlignment = VerticalAlignment.Top;
                play.HorizontalContentAlignment = HorizontalAlignment.Left;
                play.VerticalAlignment = VerticalAlignment.Bottom;
                play.HorizontalAlignment = HorizontalAlignment.Left;
                play.Style = (Style)FindResource("StandardButton");
                play.KeyDown += Play_KeyDown;
                play.GotFocus += Play_GotFocus;
                play.LostFocus += Play_LostFocus;
                Grid.SetColumn(play, 1);
                Grid.SetColumnSpan(play, 2);
                Grid.SetRow(play, 0);
                Grid.SetRowSpan(play, 1);
                play.IsEnabled = true;
                play.Focusable = true;
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
                
                delete.VerticalContentAlignment = VerticalAlignment.Top;
                delete.HorizontalContentAlignment = HorizontalAlignment.Left;
                delete.VerticalAlignment = VerticalAlignment.Bottom;
                delete.HorizontalAlignment = HorizontalAlignment.Left;
                delete.KeyDown += Delete_KeyDown;
                delete.GotFocus += Delete_GotFocus;
                delete.LostFocus += Delete_LostFocus;
                delete.Style = (Style)FindResource("StandardButton");
                Grid.SetColumn(delete, 2);
                Grid.SetColumnSpan(delete, 2);
                Grid.SetRow(delete, 0);
                Grid.SetRowSpan(delete, 1);
                delete.IsEnabled = true;
                delete.Focusable = true;

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
                //thisButton.Background = Brushes.White;
                
                Console.WriteLine("leaveWhite");
                //play.Focus();

            }
            Switche = true;

            if (keepPlayFocus)
            {
                play.Focus();
                keepPlayFocus = false;
            }
            else if (keepDeleteFocus)
            {
                delete.Focus();
                keepDeleteFocus = false;
            }

            //StackOverFlow???
            //if (Switche == false)
            // {
            //Keyboard.Focus(play);
            //}

            //Switche = true;
            //Console.WriteLine("Switche" + Switche);





        }

        

        // https://docs.microsoft.com/en-us/dotnet/desktop/wpf/advanced/how-to-change-the-color-of-an-element-using-focus-events?view=netframeworkdesktop-4.8
        

        private void Play_GotFocus(object sender, RoutedEventArgs e)
        {
           
            Button thisButton = sender as Button;
            Console.WriteLine("HereP");
            //thisButton.Background = Brushes.Red;
            thisButton.Style = (Style)FindResource("HoverButton");
            thisButton.Background = (LinearGradientBrush)FindResource("ButtonHoverBackground");



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
            //thisButton.Background = Brushes.Red;
            thisButton.Style = (Style)FindResource("HoverButton");
            thisButton.Background = (LinearGradientBrush)FindResource("ButtonHoverBackground");

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
            thisButton.Style = (Style)FindResource("StandardButton");
            thisButton.Background = (LinearGradientBrush)FindResource("ButtonNormalBackground");
            //thisButton.Background = Brushes.Aqua;

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
            thisButton.Style = (Style)FindResource("StandardButton");
            thisButton.Background = (LinearGradientBrush)FindResource("ButtonNormalBackground");

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
                if (MusicButtonsGrids.Count != 1)
                {
                    MusicButtonsGrids[MusicButtonsGrids.Count - 1].Children.Remove(play);
                    MusicButtonsGrids[MusicButtonsGrids.Count - 1].Children.Remove(delete);
                }

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
                if (MusicButtonsGrids.Count != 1)
                {
                    MusicButtonsGrids[0].Children.Remove(play);
                    MusicButtonsGrids[0].Children.Remove(delete);
                }
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
                play.Focusable = true;
                delete.Focusable = true;
                Switche = false;
                this.Loaded += new RoutedEventHandler(Login_Focus);
            }
            else if (e.Key == Key.Back)
            {
                MainWindow home = new MainWindow();
                home.Show();
                this.Close();
            }
            else if (e.Key == Key.O)
            {
                MessageBox.Show("Sorry this feature has not been implemented! We aplogize for the inconvenience.", "Silver HTPC", MessageBoxButton.OK);
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
                //for (int a = 0; a < 100; a++) {
                    ViewMusicList.ScrollToVerticalOffset(thisbutton.TranslatePoint(new Point(), MusicList).Y - 50);
                //ViewMusicList.scrollto
                
               // }
                
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
            else if(e.Key == Key.Left)
            {
                keepPlayFocus = true;
            }

            else if (e.Key == Key.O)
            {
                // Only worked because we move okclick.wav to the debug file
                //String path = System.IO.Directory.GetCurrentDirectory() + "/OkClick.wav";
                //Uri path = new Uri(@"pack://application:,,,/Sound/OkClick.wav", UriKind.RelativeOrAbsolute);
                // Console.WriteLine(path);
                System.Media.SoundPlayer player = new System.Media.SoundPlayer("/Sound/OkClick.wav");
                Console.WriteLine(player.SoundLocation);

                //MediaPlayer a = new MediaPlayer();
                // a.Source = new Uri("/Sound/OkClick.wav", UriKind.RelativeOrAbsolute);
                //Bitmap


                //var uri = new Uri
                //var Player = new MediaPlayer();
                //player.

                /**
                var sri = Application.GetResourceStream(new Uri("pack://application:,,,/Sound/OkClick.wav"));
                var ssad = sri.Stream;

                using (ssad = sri.Stream)
                {
                    System.Media.SoundPlayer player = new System.Media.SoundPlayer(ssad);
                    player.Load();
                    player.Play();
                }
                **/




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

                //reverseMusic = new Button();
                //playMusic.Content = "But";
                reverseMusic.Height = 30;
                reverseMusic.Width = 50;
                reverseMusic.Visibility = Visibility.Visible;
                //playMusic.Background = Brushes.Black;
                reverseMusic.Content = reverse;
                reverseMusic.GotFocus += Button_GotFocus;
                reverseMusic.LostFocus += ButtonMusicPlaying_LostFocus;
                reverseMusic.KeyDown += ReverseMusicOption_KeyDown;
                reverseMusic.Style = (Style)FindResource("StandardButton");
                //reverseMusic.Focusable = false;


                MusicOptions.Children.Add(reverseMusic);

                playPauseMusic = new Button();
                playPauseMusic.Height = 30;
                playPauseMusic.Width = 50;
                playPauseMusic.Content = playPause;
                playPauseMusic.GotFocus += Button_GotFocus;
                playPauseMusic.LostFocus += ButtonMusicPlaying_LostFocus;
                playPauseMusic.KeyDown += PlayPauseMusicOption_KeyDown;
                playPauseMusic.Style = (Style)FindResource("StandardButton");

                MusicOptions.Children.Add(playPauseMusic);

                forwardMusic = new Button();
                forwardMusic.Height = 30;
                forwardMusic.Width = 50;
                forwardMusic.Content = forward;
                forwardMusic.GotFocus += Button_GotFocus;
                forwardMusic.LostFocus += ButtonMusicPlaying_LostFocus;
                forwardMusic.KeyDown += ForwardMusicOption_KeyDown;
                forwardMusic.Style = (Style)FindResource("StandardButton");

                MusicOptions.Children.Add(forwardMusic);


                timer = new DispatcherTimer();
                timer.Interval = TimeSpan.FromSeconds(1);
                timer.Tick += timer_tick;
                timer.Start();
                startTime = DateTime.Now;
                //subtractFromTime = DateTime.Now;

                //currentMusicTimer = new TextBlock();
                String searchFor = "SongDurationTb" + (MusicIndex + 1);
                songDuration = ((TextBlock)MusicButtonsGrids[MusicIndex].FindName(searchFor)).Text;
                songDuration = songDuration.Replace("m", "");
                songDuration = songDuration.Replace("s", "");
                MusicTime.Text = songDuration;


                Slider slideDuration = new Slider();
                slideDuration.Maximum = 100;
                slideDuration.Focusable = false;
                //MusicDuration.Children.Add(currentMusicTimer);
                MusicDuration.Children.Add(slideDuration);
                //MusicTime.Text = 
                currentMusicTime.Visibility = Visibility.Visible;
                MusicTime.Visibility = Visibility.Visible;

                //playMusic.Focus();
                // new BitmapImage(new Uri(@"pack://application:,,,/Image/spotify-download-logo.png", UriKind.RelativeOrAbsolute));
            }
            
            else if (e.Key == Key.Back)
            {
                MainWindow home = new MainWindow();
                home.Show();
                Switche = false;
                this.Close();
            }
            
            Start += 1;





        }

        private void PlayPauseMusicOption_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.O)
            {
                if (timer.IsEnabled)
                {
                    timer.Stop();
                }
                else
                {
                    timer.Start();
                }
            }
            else if (e.Key == Key.Back)
            {
                MainWindow home = new MainWindow();
                home.Show();
                this.Close();
            }
            else if (e.Key == Key.Left)
            {
                reverseMusic.Focusable = true;
                reverseMusic.Focus();
            }

        }
        private void ForwardMusicOption_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.O)
            {
                DateTime tempStartTime = startTime.AddSeconds(15);
                //if (tempStartTime.CompareTo(DateTime.Now.AddSeconds(timeInc)) >= 0)
                //{
                    timeInc += 15;
                    Console.WriteLine(startTime);
                    //addonTimer = DateTime.Now.AddSeconds(15);
                    //Console.WriteLine("Adding Seconds" + startTime);
                //}
            }
            else if (e.Key == Key.Back)
            {
                MainWindow home = new MainWindow();
                home.Show();
                this.Close();
            }
            else if(e.Key == Key.Right)
            {
                Console.WriteLine("goRight");
                reverseMusic.Focusable = false;
                playPauseMusic.Focusable = false;
                
            }
            else if (e.Key == Key.Left)
            {
                playPauseMusic.Focusable = true;
                playPauseMusic.Focus();
            }

        }
        private void ReverseMusicOption_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.O)
            {
                timeDec += 15;
            }
            else if (e.Key == Key.Back)
            {
                MainWindow home = new MainWindow();
                home.Show();
                this.Close();
            }
            else if(e.Key == Key.Left)
            {
                for (int i = 0; i < MusicButtonsList.Count; i++)
                {
                    MusicButtonsList[i].Focusable = true;
                }
                Keyboard.ClearFocus();
                play.Focusable = true;
                delete.Focusable = true;
                Switche = false;
                this.Loaded += new RoutedEventHandler(Login_Focus);

                //delete.Focus();


            }
        }
          

        private void timer_tick(object sender, EventArgs e)
        {
            currentMusicTime.Text = (DateTime.Now.AddSeconds(timeInc) - startTime.AddSeconds(timeDec)).ToString(@"mm\:ss");
            //Timespan difference = (DateTime.Now - startTime);
        }

       

        private void Yes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key==Key.O)
            {
                char a = MusicButtonsGrids[MusicIndex].Name[10];
                String searchFor = "SongNameTb" + a;
                String songName = ((TextBlock)MusicButtonsGrids[MusicIndex].FindName(searchFor)).Text;
                MusicDeleteMessage.Content = songName + " has been deleted.";
                Notification_popup0.Visibility = Visibility.Visible; dispatcherTimer.Start();
                MusicList.Effect = null;
                Cover.Effect = null;
                MusicOptions.Effect = null;
                MusicOptions.Effect = null;
                SortButton.Effect = null;
                DeleteMultiple.Effect = null;
                MusicDuration.Effect = null;
                for (int i = 0; i < MusicButtonsList.Count; i++)
                {
                    MusicButtonsList[i].Focusable = true;
                }
                DeleteMessage.Visibility = Visibility.Hidden;
                //MusicGrid.Effect = null;
                MusicList.Children.Remove(MusicButtonsList[MusicIndex]);
                MusicButtonsList.RemoveAt(MusicIndex);
                MusicButtonsGrids.RemoveAt(MusicIndex);
                for (int i = 0; i < MusicButtonsGrids.Count; i++)
                {
                    Console.WriteLine(MusicButtonsList[i].Name);
                }
               
                Console.WriteLine("Remove :" + MusicIndex);
                CoverPhotosList.RemoveAt(MusicIndex);
                currentMusicTime.Visibility = Visibility.Hidden;
                MusicTime.Visibility = Visibility.Hidden;
                Cover.Children.Clear();
                MusicOptions.Children.Clear();
                MusicDuration.Children.Clear();


                Keyboard.ClearFocus();
                Switche = false;
                if (MusicButtonsList.Count !=0 && MusicButtonsList.Count == MusicIndex)
                {
                    MusicIndex -= 1;
                    MusicButtonsList[MusicIndex].Focus();
                }
                else if(MusicButtonsList.Count != 0){
                    MusicButtonsList[MusicIndex].Focus();
                }
                else
                {
                    SortButton.Focus();
                }
                
                //this.Loaded+= new RoutedEventHandler(Login_Focus);

            }
            

        }

        private void No_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.O)
            {
                MusicList.Effect = null;
                Cover.Effect = null;
                MusicOptions.Effect = null;
                MusicOptions.Effect = null;
                SortButton.Effect = null;
                DeleteMultiple.Effect = null;
                MusicDuration.Effect = null;
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
            else if (e.Key == Key.Right)
            {
                if (reverseMusic.IsVisible)
                {
                    Keyboard.ClearFocus();
                    for (int i = 0; i < MusicButtonsList.Count; i++)
                    {
                         MusicButtonsList[i].Focusable = false;
                    }

                    play.Focusable = false;
                    delete.Focusable = false;
                    reverseMusic.Focus();

                    MusicButtonsGrids[MusicIndex].Children.Remove(play);
                    MusicButtonsGrids[MusicIndex].Children.Remove(delete);

                }
                else
                {
                    
                    keepDeleteFocus = true;
                }
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
            if (e.Key == Key.O)
            {
                DeleteMessage.Visibility = Visibility.Visible;
                //MusicGrid.Effect = new BlurEffect();
                MusicList.Effect = new BlurEffect();
                Cover.Effect = new BlurEffect();
                MusicOptions.Effect = new BlurEffect();
                MusicOptions.Effect = new BlurEffect();
                SortButton.Effect = new BlurEffect();
                DeleteMultiple.Effect = new BlurEffect();
                MusicDuration.Effect = new BlurEffect();
                //DeleteMessage.Effect = null;
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

                char a = MusicButtonsGrids[MusicIndex].Name[10];
                String searchFor = "SongNameTb" + a;
                //Console.WriteLine("Search for: " + a);
                String songName = ((TextBlock)MusicButtonsGrids[MusicIndex].FindName(searchFor)).Text;
                //MusicIndex -= 1;

                TextBlock DeleteSongTb = new TextBlock();
                DeleteSongTb.Text = songName;
                Grid.SetRow(DeleteSongTb, 1);
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
                yes.KeyDown += Yes_KeyDown;
                Grid.SetRow(yes, 2);
                Grid.SetColumn(yes, 0);
                yes.VerticalAlignment = VerticalAlignment.Center;
                yes.HorizontalAlignment = HorizontalAlignment.Center;
                yes.VerticalContentAlignment = VerticalAlignment.Top;
                yes.Style =  (Style)FindResource("StandardButton");

                Button no = new Button();
                no.Width = 50;
                no.Content = "No";
                no.GotFocus += Button_GotFocus;
                no.LostFocus += Button_LostFocus;
                no.KeyDown += No_KeyDown;
                Grid.SetRow(no, 2);
                Grid.SetColumn(no, 1);
                no.VerticalAlignment = VerticalAlignment.Center;
                no.HorizontalAlignment = HorizontalAlignment.Center;
                no.Style = (Style)FindResource("StandardButton");



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
                Console.WriteLine("Delete Entered on");
            }
            else if (e.Key == Key.Back)
            {
                MainWindow home = new MainWindow();
                home.Show();
                this.Close();
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
            //thisButton.Background = Brushes.White;
            thisButton.Style = (Style)FindResource("StandardButton");
            thisButton.Background = (LinearGradientBrush)FindResource("ButtonNormalBackground");
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
            //thisButton.Background = Brushes.White;
            thisButton.Style = (Style)FindResource("StandardButton");
            thisButton.Background = (LinearGradientBrush)FindResource("ButtonNormalBackground");
            //thisButton.Height = 44;
        }

        private void ButtonMusicPlaying_LostFocus(object sender, RoutedEventArgs e)
        {
            Button thisButton = sender as Button;
            //thisButton.Background = Brushes.White;
            thisButton.Style = (Style)FindResource("StandardButton");
            thisButton.Background = (LinearGradientBrush)FindResource("ButtonNormalBackground");
            Console.WriteLine("bye");

        }
        private void Button_GotFocus(object sender, RoutedEventArgs e)
        {
            Button thisButton = sender as Button;
            //thisButton.Background = Brushes.Red;
            thisButton.Style = (Style)FindResource("HoverButton");
            thisButton.Background = (LinearGradientBrush)FindResource("ButtonHoverBackground");
            Console.WriteLine("Here");
            //thisButton.Height = 60;
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

        void Login_Focus(object sender, RoutedEventArgs e)
        {
            //Keyboard.ClearFocus();
            Console.WriteLine("dadae " + Switche);
            Switche = false;
            /**
            for (int i = 0; i < MusicButtonsList.Count; i++)
            {
                MusicButtonsList[i].Focusable = true;
                MusicButtonsList[i].IsEnabled = true;
                MusicButtonsList[i].GotFocus += Music_GotFocus;
                MusicButtonsList[i].LostFocus += Music_LostFocus;
            }
            //  MusicButtonsList[MusicIndex].Focus();
            // MusicButtonsList[MusicIndex].Focus();
            MusicList.Focusable = true;
            MusicList.IsEnabled = true;
            ViewMusicList.Focusable = true;
            ViewMusicList.IsEnabled = true;

            
            play.KeyDown += Play_KeyDown;
            play.GotFocus += Play_GotFocus;
            play.LostFocus += Play_LostFocus;

            delete.KeyDown += Delete_KeyDown;
            delete.GotFocus += Delete_GotFocus;
            delete.LostFocus += Delete_LostFocus;
            **/

            //Keyboard.Focus(MusicButtonsList[0]);
            Console.WriteLine("dadae " + Switche);
            MusicButtonsList[0].Focus();
            //SortButton.Focus();

        }
    }
}
