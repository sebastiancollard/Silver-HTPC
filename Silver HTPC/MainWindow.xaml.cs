using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Silver_HTPC
{
    /// <summary>
    /// Interaction logic for test.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static int currentButtonSelectionIndex=0;
        private static int volume = 40;
        private int profileIndex = 0;
        private static Button[] menuButtonList;
        private static StackPanel[] stackPanelList;
        private DispatcherTimer dispatcherTimer;
        public static string[,] content=new string[,] { { "Live TV", "Image/tv_icon.png" }, { "Gallery", "Image/gallery_icon.png" }, { "Music", "Image/music_icon.png" }, { "Recordings", "Image/record_icon.png" }, { "Search", "Image/search_icon.png" }, { "Netflix", "Image/netflix_icon.png" }, { "Settings", "Image/settings_icon.png" }, { "Notification", "Image/notification_icon.png" }, { "Other Apps", "Image/apps_icon.png" } , {"John Doe","Image/profile_icon.png" } };
        private static Label selectedLabel;
        private static string[,] profiles;
        private static List<Button> profileBtns = new List<Button>();
        public MainWindow()
        {
            InitializeComponent();
            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 5); 

            DispatcherTimer timer = new DispatcherTimer(new TimeSpan(0, 0, 1), DispatcherPriority.Normal, delegate
            {
                this.time_label.Content = DateTime.Now.ToString("hh:mm tt");
                this.date_label.Content = DateTime.Now.ToString("MMMM dd, yyyy");
            }, this.Dispatcher);

            //list of buttons, stack panels and content
            //content=> possible mitigation -> reading from a file (log file)
            menuButtonList = new Button[] { munu_button1, munu_button2, munu_button3, munu_button4, munu_button5,munu_button6,munu_button7,munu_button8,munu_button9,profile_button};
            profiles = new String[,] { { "John Doe", "Image/profile_icon.png" }, { "Add Profile", "Image/add_profile.png" } };
            Vol.Content = volume;
            //profiles.Append<string>("Add profile");
            

            foreach (Button btn in menuButtonList)
                btn.Background=  (LinearGradientBrush)FindResource("ButtonNormalBackground"); 

            stackPanelList = new StackPanel[] { stackPan_Button1, stackPan_Button2, stackPan_Button3, stackPan_Button4, stackPan_Button5, stackPan_Button6, stackPan_Button7, stackPan_Button8, stackPan_Button9, stackPan_Profile };
            //content = 
            //dynamically add content to static buttons
            for (int i = 0; i < 10; i++)
            {
                stackPanelList[i].Children.Clear();
                Image image = new Image();
                if (i == 9)
                {
                    image.Height = 25;
                    image.Width = 25;
                }
                else
                {
                    image.Height = 60;
                    image.Width = 60;
                }
                Uri imageUri = new Uri(content[i,1], UriKind.Relative);
                image.Source = new BitmapImage(imageUri);
                stackPanelList[i].Children.Add(image);
                /*Label lbl = new Label();
                lbl.FontSize = 25;
                lbl.Content = content[i,0];
                stackPanelList[i].Children.Add(lbl);*/
            }

            //Set it to the button content
            //munu_button1.Focus();
            setButtonFocus(currentButtonSelectionIndex);
        }
        /*
        private void select(object sender, KeyEventArgs e)
        {
            var btn = sender as Button;
            if (e.Key == Key.Enter)
            {
                if (btn == munu_button8)
                {
                    Notification_tab notification_window = new Notification_tab();
                    notification_window.Show();
                    this.Hide();
                }
                else if (btn == munu_button1)
                {
                    Photos_Videos photos_Videos_Window = new Photos_Videos();
                    photos_Videos_Window.Show();
                    this.Close();
                }
                else if (btn == munu_button4)
                {
                    Recordings recording_Window = new Recordings();
                    recording_Window.Show();
                    this.Close();
                }
                else if (btn == munu_button2)
                {
                    Photos_Videos photos_Videos_Window = new Photos_Videos();
                    photos_Videos_Window.Show();
                    this.Close();
                }
                else if (btn == munu_button5)
                {
                    Photos_Videos photos_Videos_Window = new Photos_Videos();
                    photos_Videos_Window.Show();
                    this.Close();
                }
                else if (btn == munu_button7)
                {
                    Settings settings_Window = new Settings();
                    settings_Window.Show();
                    this.Close();
                }
                else if (btn == munu_button3)
                {
                    Music music_Window = new Music();
                    music_Window.Show();
                    this.Close();
                }else if (btn == profile_button)
                {
                    MessageBox.Show("create one");
                }
            }

        }*/

        public void setButtonFocus(int button_index)
        {
            //currentButtonSelectionIndex = button_index;
            Button button = menuButtonList[button_index];
            button.Style = (Style)FindResource("HoverButton");
            button.Background = (LinearGradientBrush)FindResource("ButtonHoverBackground");
            //if (button_index != 9) //not profile button
            //{
            selectedLabel = new Label();
                selectedLabel.Name = "labelSelected";
                selectedLabel.FontSize = 20;
                //selectedLabel.Foreground = Brushes.WhiteSmoke;
                selectedLabel.Content = content[button_index, 0];
                stackPanelList[button_index].Children.Add(selectedLabel);
            //}
            //button.Foreground = Brushes.White;
            button.Height *= 1.2;
            if (button_index == 7)
            {
                notifyDot.Margin = new Thickness(410, 310, 0, 0);
            }
        }

        public void updateContent(int button_index)
        {
            if (button_index < 7)
            {
                for (int i = button_index; i > 0; i--)
                {
                    string tmp0 = content[i, 0];
                    string tmp1 = content[i, 1];
                    content[i, 0] = content[i - 1, 0];
                    content[i, 1] = content[i - 1, 1];
                    content[i - 1, 0] = tmp0;
                    content[i - 1, 1] = tmp1;

                }
                
            }
            
        }
        public void resetButtonFocus(int button_index)
        {
            Button button = menuButtonList[button_index];
            //button.ClearValue(Button.BackgroundProperty); 
            //button.ClearValue(Button.ForegroundProperty);
            //if (button_index != 9)
            //{
            button.Style = (Style)FindResource("StandardButton");
            button.Background = (LinearGradientBrush)FindResource("ButtonNormalBackground");
            stackPanelList[button_index].Children.Remove(selectedLabel);
            //}
            
            button.Height /= 1.2;
            if (button_index == 7)
            {
                notifyDot.Margin = new Thickness(410, 323, 0, 0);
            }
        }

        public void setProfileButtonFocus(int button_index)
        {
            //currentButtonSelectionIndex = button_index;
            Button button = profileBtns[button_index];
            button.Style = (Style)FindResource("HoverButton");
            button.Background = (LinearGradientBrush)FindResource("ButtonHoverBackground");
            //if (button_index != 9) //not profile button
            //{
            //button.Foreground = Brushes.WhiteSmoke;
            
            
            //}
            //button.Foreground = Brushes.White;
            button.Height *= 1.2;
        }
        public void resetProfileButtonFocus(int button_index)
        {
            Button button = profileBtns[button_index];
            //button.ClearValue(Button.BackgroundProperty);
            //button.ClearValue(Button.ForegroundProperty);
            button.Style = (Style)FindResource("StandardButton");
            button.Background = (LinearGradientBrush)FindResource("ButtonNormalBackground");
            button.Height /= 1.2;
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (ProfilePopup.Visibility==Visibility.Hidden){
                switch (e.Key)
                {
                    case Key.Right:
                        if (currentButtonSelectionIndex != 2 && currentButtonSelectionIndex != 5 && currentButtonSelectionIndex != 8 && currentButtonSelectionIndex != 9)
                        {
                            resetButtonFocus(currentButtonSelectionIndex);
                            currentButtonSelectionIndex = (currentButtonSelectionIndex + 1) % 9;
                            setButtonFocus(currentButtonSelectionIndex);
                        }

                        break;
                    case Key.Left:
                        if (currentButtonSelectionIndex != 0 && currentButtonSelectionIndex != 3 && currentButtonSelectionIndex != 6 && currentButtonSelectionIndex != 9)
                        {
                            resetButtonFocus(currentButtonSelectionIndex);
                            currentButtonSelectionIndex = (currentButtonSelectionIndex - 1) % 9;
                            setButtonFocus(currentButtonSelectionIndex);
                        }

                        break;
                    case Key.Down:
                        if (currentButtonSelectionIndex == 9)
                        {
                            resetButtonFocus(currentButtonSelectionIndex);
                            currentButtonSelectionIndex = 0;
                            setButtonFocus(currentButtonSelectionIndex);
                        }
                        else if (currentButtonSelectionIndex < 6)
                        {
                            resetButtonFocus(currentButtonSelectionIndex);
                            currentButtonSelectionIndex = (currentButtonSelectionIndex + 3) % 9;
                            setButtonFocus(currentButtonSelectionIndex);
                        }

                        break;
                    case Key.Up:
                        if (currentButtonSelectionIndex >= 3 && currentButtonSelectionIndex != 9)
                        {
                            resetButtonFocus(currentButtonSelectionIndex);
                            currentButtonSelectionIndex = (currentButtonSelectionIndex - 3) % 9;
                            setButtonFocus(currentButtonSelectionIndex);
                        }
                        else
                        {
                            resetButtonFocus(currentButtonSelectionIndex);
                            currentButtonSelectionIndex = 9;
                            setButtonFocus(currentButtonSelectionIndex);
                        }
                        break;
                    case Key.Z:
                        if (e.Key == Key.Z)
                        { //hardcoded to show notification
                            Notification_popup0.Visibility = Visibility.Visible;
                            notifyDot.Visibility = Visibility.Visible;
                            dispatcherTimer.Start();
                        }
                        break;
                    case Key.S:
                        Settings settings = new Settings();
                        settings.Show();
                        this.Close();
                        break;
                    case Key.G:
                        TV_Guide tv = new TV_Guide();
                        tv.Show();
                        this.Close();
                        break;
                    case Key.OemQuestion:
                        Settings setting = new Settings();
                        setting.Show();
                        this.Close();
                        break;
                    case Key.OemPlus:
                        Vol1.Visibility = Visibility.Visible;
                        Vol2.Visibility = Visibility.Visible;
                        Vol.Visibility = Visibility.Visible;
                        volume+=2;
                        Vol.Content = volume;
                        if (volume >= 45 && volume<50)
                        {
                            Vol2.Margin = new Thickness(724 ,368, 0, 0);
                        }
                        if (volume >= 50)
                        {
                            Vol2.Margin = new Thickness(697, 377, 0, 0);
                        }
                        dispatcherTimer.Start();
                        break;
                    case Key.OemMinus:
                        Vol1.Visibility = Visibility.Visible;
                        Vol2.Visibility = Visibility.Visible;
                        Vol.Visibility = Visibility.Visible;
                        volume-=2;
                        Vol.Content = volume;
                        if (volume >= 45 && volume<50)
                        {
                            Vol2.Margin = new Thickness(724, 368, 0, 0);
                        }
                        if (volume < 45)
                        {
                            Vol2.Margin = new Thickness(742, 351, 0, 0);
                        }
                        dispatcherTimer.Start();
                        break;
                    case Key.O:
                        /*{ "Live TV", "Image/tv_icon.png" }, { "Gallery", "Image/gallery_icon.png" }, { "Music", "Image/music_icon.png" }, { "Recordings", "Image/record_icon.png" }, { "Search", "Image/search_icon.jpg" }, { "Netflix", "Image/netflix_icon.png" }, { "Settings", "Image/settings_icon.png" }, { "Notification", "Image/notification_icon.png" }, { "Other Apps", "Image/apps_icon.png" } , {"John Doe","Image/profile_icon.png" }*/
                        if (Notification_popup0.Visibility!=Visibility.Visible){
                            bool dontClose = false;
                                resetButtonFocus(currentButtonSelectionIndex);
                                switch (content[currentButtonSelectionIndex, 0])
                                {
                                    case "Live TV":
                                        TV_Guide tvG = new TV_Guide();
                                        tvG.Show();
                                        break;
                                    case "Gallery":
                                        Photos_Videos gallery = new Photos_Videos();
                                        gallery.Show();
                                        break;
                                    case "Music":
                                        Music music = new Music();
                                        music.Show();
                                        break;
                                    case "Recordings":
                                        Recordings rec = new Recordings();
                                        rec.Show();
                                        break;
                                    case "Search":
                                        Search search = new Search();
                                        search.Show();
                                        break;
                                    case "Netflix":
                                        dontClose = true;
                                        MessageBox.Show("No screens made for third party");
                                        break;
                                    case "Settings":
                                        Settings sett = new Settings();
                                        sett.Show();
                                        break;
                                    case "Notification":
                                        Notification_tab notif = new Notification_tab();
                                        notif.Show();
                                        notifyDot.Visibility = Visibility.Hidden;
                                        break;
                                    case "Other Apps":
                                        OtherApplications otherApp = new OtherApplications();
                                        otherApp.Show();
                                        content[6, 0] = "Prime Videos";
                                        content[6, 1] = "Image/primevid_icon.png";
                                        updateContent(6);
                                        break;
                                    default://profile
                                        MainGrid.Effect = new BlurEffect();
                                        dontClose = true;
                                        profileBtns.Clear();
                                        ProfilePopup.Visibility = Visibility.Visible;
                                        Profiles_header.Visibility = Visibility.Visible;
                                        for (int i = 0; i <2; i++)
                                        {
                                            Button profile = new Button();
                                        profile.HorizontalContentAlignment = HorizontalAlignment.Center;
                                            StackPanel sPanel1 = new StackPanel();
                                        sPanel1.HorizontalAlignment = HorizontalAlignment.Center;
                                            sPanel1.Orientation = Orientation.Vertical;
                                        Image image = new Image();    
                                        Uri imageUri = new Uri(profiles[i, 1], UriKind.Relative);
                                            image.Source = new BitmapImage(imageUri);
                                        image.Height = 55;
                                        image.Width = 55;
                                        sPanel1.Children.Add(image);
                                        profile.Name = "profile" + i.ToString();
                                        TextBox textBox = new TextBox();
                                        textBox.Background = Brushes.Transparent;
                                            textBox.Text = profiles[i,0];
                                        textBox.BorderBrush = Brushes.Transparent;
                                            profile.Height = 90;
                                            profile.Width = 170;
                                            textBox.FontSize = 20;
                                            sPanel1.Children.Add(textBox);
                                        profile.Content = sPanel1;
                                        profile.Background = (LinearGradientBrush)FindResource("ButtonNormalBackground");
                                        profileBtns.Add(profile);
                                        ProfilePopup.Children.Add(profile);
                                        }
                                        //ProfilePopup.Children.Add

                                        setProfileButtonFocus(profileIndex);
                                        //Console.WriteLine(profileIndex);
                                        break;
                                }
                                if (!dontClose)
                                {
                                    updateContent(currentButtonSelectionIndex);
                                    currentButtonSelectionIndex = 0;
                                    this.Close();
                                }
                        }
                        else
                        {
                            if (e.Key == Key.O)
                            {
                                LiveTV liveTV = new LiveTV(2);
                                notifyDot.Visibility = Visibility.Hidden;
                                liveTV.Show();
                                this.Close();
                            }
                        }
                        break;
                    default:
                        break;
                }
            }
            else
            {
                switch (e.Key) {
                    case Key.Back:

                        if (addingProfilePopup.Visibility==Visibility.Hidden) {
                            MainGrid.Effect = null;
                            ProfilePopup.Children.Clear();
                            ProfilePopup.Visibility = Visibility.Hidden;
                            Profiles_header.Visibility = Visibility.Hidden;
                            setButtonFocus(currentButtonSelectionIndex);
                            resetProfileButtonFocus(profileIndex);
                            profileIndex = 0;
                        }
                        else
                        {
                            ProfilePopup.Effect = null;
                            addingProfilePopup.Visibility = Visibility.Hidden;
                            keypad.Visibility = Visibility.Hidden;
                            BackOption.Visibility = Visibility.Hidden;
                        }
                        break;
                    case Key.Right:
                        if (addingProfilePopup.Visibility == Visibility.Hidden)
                        {
                            resetProfileButtonFocus(profileIndex);
                            profileIndex = (profileIndex + 1) % 2;
                            setProfileButtonFocus(profileIndex);    
                        }
                        break;
                    case Key.Left:
                        if (addingProfilePopup.Visibility == Visibility.Hidden)
                        {
                            resetProfileButtonFocus(profileIndex);
                            profileIndex = (profileIndex - 1);
                            if (profileIndex == -1) profileIndex = 1;
                            setProfileButtonFocus(profileIndex);
                        }
                        break;
                    case Key.O:
                        if (addingProfilePopup.Visibility == Visibility.Hidden)
                        {
                            ProfilePopup.Effect = new BlurEffect();
                            addingProfilePopup.Visibility = Visibility.Visible;
                            keypad.Visibility = Visibility.Visible;
                            BackOption.Visibility = Visibility.Visible;
                        }
                        break;
                    default:
                        break;
                }
            }
            
            
        }
        

        private void munu_button8_Click(object sender, RoutedEventArgs e)
        {
            Notification_tab notification_window = new Notification_tab();
            notification_window.Show();
            this.Hide();
            

        }

        private void menu_button4_click(object sender, RoutedEventArgs e)
        {
            Recordings recording_Window = new Recordings();
            recording_Window.Show();
            this.Close();
        }

        private void menu_button2_click(object sender, RoutedEventArgs e)
        {
            Photos_Videos photos_Videos_Window = new Photos_Videos();
            photos_Videos_Window.Show();
            this.Close();
        }

        private void menu_button5_click(object sender, RoutedEventArgs e)
        {
            Search search_Window = new Search();
            search_Window.Show();
            this.Close();
        }

        private void menu_button7_click(object sender, RoutedEventArgs e)
        {
            Settings settings_Window = new Settings();
            settings_Window.Show();
            this.Close();
        }

        private void menu_button3_click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("No screens made for third party");
            /*Music music_Window = new Music();
            music_Window.Show();
            this.Close();*/
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {//For notification
         //Things which happen after 1 timer interval

            Notification_popup0.Visibility = Visibility.Collapsed;
            Vol.Visibility = Visibility.Hidden;
            Vol1.Visibility = Visibility.Hidden;
            Vol2.Visibility = Visibility.Hidden;

            //Disable the timer
            dispatcherTimer.IsEnabled = false;
        }
        //bin xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
        /*Popup popup = new Popup();
                            //popup.Visibility = (System.Windows.Visibility)50;
                            
                            popup.Height = 20;
                            popup.Width = 50;
                            popup.IsOpen = true;
                            
                            
                            TextBlock popupText = new TextBlock();
                            popupText.Text = "Popup Text";
                            popupText.Background = Brushes.Gray;
                            popupText.Foreground = Brushes.Blue;
                            
                            popup.Child = popupText;
                            popup.PlacementTarget =  menuButtonList[currentButtonSelectionIndex];
                            //MainGrid.Children.Add(popup);

                            //*/
    }
}
