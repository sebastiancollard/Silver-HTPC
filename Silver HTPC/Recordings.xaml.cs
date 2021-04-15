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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Media.Animation;
using System.Windows.Threading;
using System.Windows.Media.Effects;

namespace Silver_HTPC
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Recordings : Window
    {
        private List<Button> RecordButtonsList = new List<Button>();
        private List<Grid> RecordButtonsGrids = new List<Grid>();
        private int RecordIndex = 0;
        private Button play;
        private Button delete;
        private bool hidden = true;
        private bool showRecordingButtons = false;
        private bool recordingStarted = false;
        private DispatcherTimer dispatcherTimer;
        private DispatcherTimer dispatcherTimerNotification;
        Grid sidemenu;
        private DispatcherTimer dispatcherTimerTime;

        public Recordings()
        {
            dispatcherTimerTime = new DispatcherTimer();
            dispatcherTimerTime.Interval = new TimeSpan(0, 0, 5);
            DispatcherTimer timer = new DispatcherTimer(new TimeSpan(0, 0, 1), DispatcherPriority.Normal, delegate
            {
                this.guide_time.Content = DateTime.Now.ToString("hh:mm tt");
                this.guide_date.Content = DateTime.Now.ToString("MMMM dd, yyyy");
                this.guide_date1.Content = DateTime.Now.ToString("MMMM dd, yyyy"); ;
                this.guide_time1.Content = DateTime.Now.ToString("hh:mm tt"); ;
                //this.DateTimeReminder.Content = "\t" + DateTime.Now.ToString("hh:mm tt") +"\n\t"+  DateTime.Now.ToString("MMMM dd, yyyy");
            }, this.Dispatcher);

            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 5);

            dispatcherTimerNotification = new DispatcherTimer();
            dispatcherTimerNotification.Tick += new EventHandler(dispatcherTimerNotification_Tick);
            dispatcherTimerNotification.Interval = new TimeSpan(0, 0, 5);

            InitializeComponent();
            RecordButtonsList.Add(record1);
            RecordButtonsList.Add(record2);
            RecordButtonsList.Add(record3);

            sidemenu = panel;

            RecordButtonsGrids.Add(GridRecord1);
            RecordButtonsGrids.Add(GridRecord2);
            RecordButtonsGrids.Add(GridRecord3);
            this.Loaded += new RoutedEventHandler(Login_Focus);

        }

        void Login_Focus(object sender, RoutedEventArgs e)
        {
            RecordButtonsList[0].Focus();
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
            thisButton.Style = (Style)FindResource("HoverButton");
            thisButton.Background = (LinearGradientBrush)FindResource("ButtonHoverBackground");
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
                play.Style = (Style)FindResource("StandardButton");
                this.Background = (LinearGradientBrush)FindResource("ButtonNormalBackground");
                play.VerticalContentAlignment = VerticalAlignment.Top;
                play.HorizontalContentAlignment = HorizontalAlignment.Left;
                play.VerticalAlignment = VerticalAlignment.Top;
                play.HorizontalAlignment = HorizontalAlignment.Left;
                play.Margin = new Thickness(0, 0, 0, 10);
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
                delete.Style = (Style)FindResource("StandardButton");
                delete.Background = (LinearGradientBrush)FindResource("ButtonNormalBackground");
                delete.VerticalContentAlignment = VerticalAlignment.Top;
                delete.HorizontalContentAlignment = HorizontalAlignment.Left;
                delete.VerticalAlignment = VerticalAlignment.Top;
                delete.HorizontalAlignment = HorizontalAlignment.Right;
                delete.KeyDown += Delete_KeyDown;
                delete.GotFocus += Delete_GotFocus;
                delete.LostFocus += Delete_LostFocus;
                delete.FontSize = 20;
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
                thisButton.Style = (Style)FindResource("StandardButton");
                thisButton.Background = (LinearGradientBrush)FindResource("ButtonNormalBackground");

            }
        }

        private void Recording_LostFocus(object sender, RoutedEventArgs e)
        {
            Button thisButton = e.Source as Button;
            Console.WriteLine("Lost it");
            thisButton.Style = (Style)FindResource("StandardButton");
            thisButton.Background = (LinearGradientBrush)FindResource("ButtonNormalBackground");
            RecordButtonsGrids[RecordIndex].Height = 60;
            RecordButtonsList[RecordIndex].Height = 60;
            // This works for some weird reason


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
            thisButton.Style = (Style)FindResource("HoverButton");
            thisButton.Background = (LinearGradientBrush)FindResource("ButtonHoverBackground");

        }
        private void Delete_GotFocus(object sender, RoutedEventArgs e)
        {
            Button thisButton = sender as Button;
            Console.WriteLine("HereD");
            thisButton.Style = (Style)FindResource("HoverButton");
            thisButton.Background = (LinearGradientBrush)FindResource("DangerButtonHoverBackground");

            //MusicButtonsGrids[MusicIndex].Children.
            //play.back
            // ButtonGrid1.Children.Remove(play);
            //MusicButtonsGrids[MusicIndex].Children.Remove(play);
            //MusicButtonsGrids[MusicIndex].Children()
        }
        private void Play_LostFocus(object sender, RoutedEventArgs e)
        {
            Button thisButton = sender as Button;
            thisButton.Style = (Style)FindResource("StandardButton");
            thisButton.Background = (LinearGradientBrush)FindResource("ButtonNormalBackground");
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
                if (RecordButtonsGrids.Count != 1)
                {
                    RecordButtonsGrids[RecordButtonsGrids.Count - 1].Children.Remove(play);
                    RecordButtonsGrids[RecordButtonsGrids.Count - 1].Children.Remove(delete);
                }

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
                if (RecordButtonsGrids.Count != 1)
                {
                    RecordButtonsGrids[0].Children.Remove(play);
                    RecordButtonsGrids[0].Children.Remove(delete);
                    // MusicButtonsGrids[0].Children.Remove((Button) FindName("Play1"));
                }
                

            }
            
            



        }
        private void Delete_LostFocus(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Lost Delete Focus ");
            Button thisButton = sender as Button;
            thisButton.Style = (Style)FindResource("StandardButton");
            thisButton.Background = (LinearGradientBrush)FindResource("ButtonNormalBackground");

            //ButtonGrid1.Children.Remove(thisButton);

            if (RecordIndex != 0)
            {
                RecordButtonsGrids[RecordIndex - 1].Children.Remove(play);
                RecordButtonsGrids[RecordIndex - 1].Children.Remove(delete);
                //MusicButtonsGrids[MusicIndex - 1].Children.Remove((Button) FindName("Play1"));

            }
            else
            {
                if (RecordButtonsGrids.Count != 1)
                {
                    RecordButtonsGrids[RecordButtonsGrids.Count - 1].Children.Remove(play);
                    RecordButtonsGrids[RecordButtonsGrids.Count - 1].Children.Remove(delete);
                }

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
                if (RecordButtonsGrids.Count != 1)
                {
                    RecordButtonsGrids[0].Children.Remove(play);
                    RecordButtonsGrids[0].Children.Remove(delete);
                    // MusicButtonsGrids[0].Children.Remove((Button) FindName("Play1"));
                }

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
            else if (e.Key == Key.Right)
            {
                RecordButtonsList[RecordIndex].Height = 60;
                RecordButtonsGrids[RecordIndex].Height = 60;
                for (int i = 0; i < RecordButtonsList.Count; i++)
                {
                    RecordButtonsList[i].Focusable = false;
                }
                //Keyboard.ClearFocus();
                play.Focusable = false;
                delete.Focusable = false;
                RecordButtonsGrids[RecordIndex].Children.Remove(play);
                RecordButtonsGrids[RecordIndex].Children.Remove(delete);
                Sort_Button.Focusable = true;
                DeleteMultiple_Button.Focusable = true;
                Sort_Button.Focus();
            }
            else if(e.Key == Key.O) { 
                DeleteMessage.Visibility = Visibility.Visible;
                //MusicGrid.Effect = new BlurEffect();
                RecordingList.Effect = new BlurEffect();
                Sort_Button.Effect = new BlurEffect();
                DeleteMultiple_Button.Effect = new BlurEffect();
                //MusicDuration.Effect = new BlurEffect();
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

                
                char a = RecordButtonsGrids[RecordIndex].Name[10];
                String searchFor = "RecordName" + a;
                //Console.WriteLine("Search for: " + a);
                String recordName = ((TextBlock)RecordButtonsGrids[RecordIndex].FindName(searchFor)).Text;
                //MusicIndex -= 1;

                TextBlock DeleteSongTb = new TextBlock();
                DeleteSongTb.Text = recordName;
                
                //TextBlock DeleteSongTb = new TextBlock();
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
                yes.Style = (Style)FindResource("StandardButton");

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

                for (int i = 0; i < RecordButtonsList.Count; i++)
                {
                    RecordButtonsList[i].Focusable = false;
                }

                Keyboard.ClearFocus();
                RecordButtonsGrids[RecordIndex].Children.Remove(play);
                RecordButtonsGrids[RecordIndex].Children.Remove(delete);
                RecordButtonsGrids[RecordIndex].Height = 50;
                RecordButtonsList[RecordIndex].Height = 50;
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
            else if (e.Key == Key.Back)
            {
                MainWindow home = new MainWindow();
                home.Show();
                this.Close();
            }
            else if(e.Key == Key.O)
            {
                for(int i=0; i< RecordButtonsList.Count; i++)
                {
                    RecordButtonsList[i].Focusable = false;
                }
                Sort_Button.Focusable = false;
                DeleteMultiple_Button.Focusable = false;
                play.Focusable = false;
                delete.Focusable = false;
                recordingStarted = true;
                ShowRecording.Visibility = Visibility.Visible;
                RecordingStartingSp.Visibility = Visibility.Visible; dispatcherTimer.Start();
                panel.Visibility = Visibility.Visible;

            }







        }
        private void Yes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.O)
            {

                //char a = MusicButtonsGrids[MusicIndex].Name[10];
                //String searchFor = "SongNameTb" + a;
                //String songName = ((TextBlock)MusicButtonsGrids[MusicIndex].FindName(searchFor)).Text;
                //MusicDeleteMessage.Content = songName + " has been deleted.";
                //Notification_popup0.Visibility = Visibility.Visible; dispatcherTimer.Start();
                char a = RecordButtonsGrids[RecordIndex].Name[10];
                String searchFor = "RecordName" + a;
                //Console.WriteLine("Search for: " + a);
                String recordName = ((TextBlock)RecordButtonsGrids[RecordIndex].FindName(searchFor)).Text;
                RecordingsDeleteMessage.Content = recordName + " has been deleted.";
                //MusicIndex -= 1;
                Notification_popup0.Visibility = Visibility.Visible; dispatcherTimerNotification.Start();
                RecordingList.Effect = null;
                Sort_Button.Effect = null;
                DeleteMultiple_Button.Effect = null;
                
                for (int i = 0; i < RecordButtonsList.Count; i++)
                {
                    RecordButtonsList[i].Focusable = true;
                }
                DeleteMessage.Visibility = Visibility.Hidden;
                //MusicGrid.Effect = null;
                RecordingList.Children.Remove(RecordButtonsList[RecordIndex]);
                RecordButtonsList.RemoveAt(RecordIndex);
                RecordButtonsGrids.RemoveAt(RecordIndex);
                for (int i = 0; i < RecordButtonsGrids.Count; i++)
                {
                    Console.WriteLine(RecordButtonsList[i].Name);
                }

                //Console.WriteLine("Remove :" + MusicIndex);



                //Keyboard.ClearFocus();
                if (RecordIndex ==RecordButtonsList.Count && RecordButtonsList.Count != 0)
                {
                    RecordIndex -= 1;
                    showRecordingButtons = false;

                    RecordButtonsList[RecordIndex].Focus();
                }
                else if (RecordButtonsList.Count != 0)
                {
                    showRecordingButtons = false;

                    RecordButtonsList[RecordIndex].Focus();
                }
                else
                {
                    Sort_Button.Focusable = true;
                    DeleteMultiple_Button.Focusable = true;
                    Sort_Button.Focus();
                }

            }


        }

        private void No_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.O)
            {
                RecordingList.Effect = null;
                
                Sort_Button.Effect = null;
                DeleteMultiple_Button.Effect = null;
                
                for (int i = 0; i < RecordButtonsList.Count; i++)
                {
                    RecordButtonsList[i].Focusable = true;
                }
                DeleteMessage.Visibility = Visibility.Hidden;
                showRecordingButtons = false;
                RecordButtonsList[RecordIndex].Focus();

            }
        }

        private void Button_LostFocus(object sender, RoutedEventArgs e)
        {
            Button thisButton = sender as Button;
            //thisButton.Background = Brushes.White;
            thisButton.Style = (Style)FindResource("StandardButton");
            thisButton.Background = (LinearGradientBrush)FindResource("ButtonNormalBackground");
            //thisButton.Height = 44;
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

        private void DeleteMultiple_GotFocus(object sender, RoutedEventArgs e)
        {
            Button thisButton = sender as Button;
            //thisButton.Background = Brushes.Red;
            thisButton.Style = (Style)FindResource("HoverButton");
            thisButton.Background = (LinearGradientBrush)FindResource("DangerButtonHoverBackground");
            Console.WriteLine("Here");
            //thisButton.Height = 60;
        }

        private void Button_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Left)
            {
                //RecordButtonsList[RecordIndex].Height = 60;
                //RecordButtonsGrids[RecordIndex].Height = 60;
                for (int i = 0; i < RecordButtonsList.Count; i++)
                {
                    RecordButtonsList[i].Focusable = true;
                }
                //Keyboard.ClearFocus();
                play.Focusable = true;
                delete.Focusable = true;
               
                Sort_Button.Focusable = false;
                DeleteMultiple_Button.Focusable = false;
                showRecordingButtons = false;
                this.Loaded += new RoutedEventHandler(Login_Focus);

            }
            else if(e.Key == Key.O)
            {
                MessageBox.Show("Sorry this feature has not been implemented! We aplogize for the inconvenience.", "Silver HTPC", MessageBoxButton.OK);
            }
            else if (e.Key == Key.Back)
            {
                MainWindow home = new MainWindow();
                home.Show();
                this.Close();
            }

        }



        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (recordingStarted)
            {
                if (e.Key == Key.I && !hidden)
                {
                    //sidemenu.Margin = new Thickness(-400, 0, 400, 0);
                    hidden = true;

                    Storyboard sb = sidemenu.FindResource("SlideLeft") as Storyboard;
                    if (sb != null) { BeginStoryboard(sb); }

                }
                else if (e.Key == Key.I && hidden)
                {

                    //sidemenu.Margin = new Thickness(0, 0, 0, 0);
                    hidden = false;
                    Storyboard sb = sidemenu.FindResource("SlideRight") as Storyboard;
                    if (sb != null) { BeginStoryboard(sb); }
                }
                else if (e.Key == Key.Right)
                {


                }
                else if (e.Key == Key.Left)
                {

                }
                else if (e.Key == Key.Back)
                {
                    for (int i = 0; i < RecordButtonsList.Count; i++)
                    {
                        RecordButtonsList[i].Focusable = true;
                    }
                    Sort_Button.Focusable = false;
                    DeleteMultiple_Button.Focusable = false;
                    play.Focusable = true;
                    delete.Focusable = true;
                    recordingStarted = false;
                    ShowRecording.Visibility = Visibility.Hidden;
                    panel.Visibility = Visibility.Hidden;
                    play.Focus();


                }
            }
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {//For notification
         //Things which happen after 1 timer interval

            RecordingStartingSp.Visibility = Visibility.Collapsed;

            //Disable the timer
            dispatcherTimer.IsEnabled = false;
        }

        private void dispatcherTimerNotification_Tick(object sender, EventArgs e)
        {//For notification
         //Things which happen after 1 timer interval

            Notification_popup0.Visibility = Visibility.Collapsed;

            //Disable the timer
            dispatcherTimerNotification.IsEnabled = false;
        }
    }
}
