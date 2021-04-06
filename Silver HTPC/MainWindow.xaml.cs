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
        private static int profileIndex = 0;
        private static Button[] menuButtonList;
        private static StackPanel[] stackPanelList;
        private static string[,] content;
        private static Label selectedLabel;
        private static string[] profiles;
        private static List<Button> profileBtns = new List<Button>();
        public MainWindow()
        {
            InitializeComponent();
            DispatcherTimer timer = new DispatcherTimer(new TimeSpan(0, 0, 1), DispatcherPriority.Normal, delegate
            {
                this.time_label.Content = DateTime.Now.ToString("hh:mm tt");
                this.date_label.Content = DateTime.Now.ToString("MMMM dd, yyyy");
            }, this.Dispatcher);

            //list of buttons, stack panels and content
            //content=> possible mitigation -> reading from a file (log file)
            menuButtonList = new Button[] { munu_button1, munu_button2, munu_button3, munu_button4, munu_button5,munu_button6,munu_button7,munu_button8,munu_button9,profile_button};
            profiles = new String[] { "John Doe", "Super Tiger", "Mr Beast","Add Profile"};
            //profiles.Append<string>("Add profile");
            

            /*foreach (Button btn in menuButtonList)
                btn.KeyDown += select;*/

            stackPanelList = new StackPanel[] { stackPan_Button1, stackPan_Button2, stackPan_Button3, stackPan_Button4, stackPan_Button5, stackPan_Button6, stackPan_Button7, stackPan_Button8, stackPan_Button9, stackPan_Profile };
            content = new string[,] { { "Live TV", "Image/tv_icon.png" }, { "Gallery", "Image/gallery_icon.png" }, { "Music", "Image/music_icon.png" }, { "Recordings", "Image/record_icon.png" }, { "Search", "Image/search_icon.jpg" }, { "Netflix", "Image/netflix_icon.png" }, { "Settings", "Image/settings_icon.png" }, { "Notification", "Image/notification_icon.png" }, { "Other Apps", "Image/apps_icon.png" } , {"John Doe","Image/profile_icon.png" } };
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
                    image.Height = 55;
                    image.Width = 55;
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
            button.Background = Brushes.DarkBlue;
            //if (button_index != 9) //not profile button
            //{
                selectedLabel = new Label();
                selectedLabel.Name = "labelSelected";
                selectedLabel.FontSize = 25;
                selectedLabel.Foreground = Brushes.WhiteSmoke;
                selectedLabel.Content = content[button_index, 0];
                stackPanelList[button_index].Children.Add(selectedLabel);
            //}
            button.Foreground = Brushes.White;
            button.Height *= 1.2;
        }
        public void resetButtonFocus(int button_index)
        {
            Button button = menuButtonList[button_index];
            button.ClearValue(Button.BackgroundProperty); 
            button.ClearValue(Button.ForegroundProperty);
            //if (button_index != 9)
            //{
                stackPanelList[button_index].Children.Remove(selectedLabel);
            //}
            
            button.Height /= 1.2;
        }

        public void setProfileButtonFocus(int button_index)
        {
            //currentButtonSelectionIndex = button_index;
            Button button = profileBtns[button_index];
            button.Background = Brushes.DarkBlue;
            //if (button_index != 9) //not profile button
            //{
            button.Foreground = Brushes.WhiteSmoke;
            
            
            //}
            button.Foreground = Brushes.White;
            button.Height *= 1.2;
        }
        public void resetProfileButtonFocus(int button_index)
        {
            Button button = profileBtns[button_index];
            button.ClearValue(Button.BackgroundProperty);
            button.ClearValue(Button.ForegroundProperty);
            
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
                    case Key.Enter:
                        /*{ "Live TV", "Image/tv_icon.png" }, { "Gallery", "Image/gallery_icon.png" }, { "Music", "Image/music_icon.png" }, { "Recordings", "Image/record_icon.png" }, { "Search", "Image/search_icon.jpg" }, { "Netflix", "Image/netflix_icon.png" }, { "Settings", "Image/settings_icon.png" }, { "Notification", "Image/notification_icon.png" }, { "Other Apps", "Image/apps_icon.png" } , {"John Doe","Image/profile_icon.png" }*/
                        bool dontClose = false;
                        resetButtonFocus(currentButtonSelectionIndex);
                        switch (content[currentButtonSelectionIndex, 0])
                        {
                            case "Live TV":
                                TV_Guide tv = new TV_Guide();
                                tv.Show();
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
                                Settings settings = new Settings();
                                settings.Show();
                                break;
                            case "Notification":
                                Notification_tab notif = new Notification_tab();
                                notif.Show();
                                break;
                            case "Other Apps":
                                OtherApplications otherApp = new OtherApplications();
                                otherApp.Show();
                                break;
                            default://profile
                                MainGrid.Effect = new BlurEffect();
                                dontClose = true;
                                ProfilePopup.Visibility = Visibility.Visible;
                                Profiles_header.Visibility = Visibility.Visible;
                                for (int i = 0; i < profiles.Count<string>(); i++)
                                {
                                    Button profile = new Button();
                                    profile.Name = "profile" + i.ToString();
                                    profile.Content = profiles[i];
                                    profile.Height = 80;
                                    profile.Width = 170;
                                    profile.FontSize = 20;
                                    ProfilePopup.Children.Add(profile);
                                    profileBtns.Add(profile);
                                }
                                //ProfilePopup.Children.Add

                                setProfileButtonFocus(profileIndex);
                                break;
                        }
                        if (!dontClose) this.Close();
                        break;
                    default:
                        break;
                }
            }
            else
            {
                switch (e.Key) {
                    case Key.Back:
                
                        MainGrid.Effect = null;
                        ProfilePopup.Children.Clear();
                        ProfilePopup.Visibility = Visibility.Hidden;
                        Profiles_header.Visibility = Visibility.Hidden;
                        setButtonFocus(currentButtonSelectionIndex);
                        resetProfileButtonFocus(profileIndex);
                        profileIndex = 0;
                        break;
                    case Key.Right:
                
                        resetProfileButtonFocus(profileIndex);
                        profileIndex = (profileIndex + 1) % 4;
                        setProfileButtonFocus(profileIndex);
                        break;

                    case Key.Left:
                
                        resetProfileButtonFocus(profileIndex);
                        profileIndex = (profileIndex - 1);
                        if (profileIndex == -1) profileIndex = 3;
                        setProfileButtonFocus(profileIndex);
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
