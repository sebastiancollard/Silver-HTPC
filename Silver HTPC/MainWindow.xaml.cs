using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
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
        private static Button[] menuButtonList;
        public MainWindow()
        {
            InitializeComponent();
            DispatcherTimer timer = new DispatcherTimer(new TimeSpan(0, 0, 1), DispatcherPriority.Normal, delegate
            {
                this.time_label.Content = DateTime.Now.ToString("hh:mm tt");
                this.date_label.Content = DateTime.Now.ToString("MMMM dd, yyyy");
            }, this.Dispatcher);
            menuButtonList = new Button[] { munu_button1, munu_button2, munu_button3, munu_button4, munu_button5,munu_button6,munu_button7,munu_button8,munu_button9,profile_button};
           
            setButtonFocus(0);
        }
        public void setButtonFocus(int button_index)
        {
            //currentButtonSelectionIndex = button_index;
            Button button = menuButtonList[button_index];
            button.Background = Brushes.DarkBlue;
            button.Foreground = Brushes.White;
        }
        public void resetButtonFocus(int button_index)
        {
            Button button = menuButtonList[button_index];
            button.ClearValue(Button.BackgroundProperty); ;
            button.ClearValue(Button.ForegroundProperty); ;
        }


        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Right:
                    if (currentButtonSelectionIndex!=2 && currentButtonSelectionIndex!= 5 && currentButtonSelectionIndex != 8 && currentButtonSelectionIndex != 9)
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
                    else if (currentButtonSelectionIndex<6)
                    {
                        resetButtonFocus(currentButtonSelectionIndex);
                        currentButtonSelectionIndex = (currentButtonSelectionIndex + 3) % 9;
                        setButtonFocus(currentButtonSelectionIndex);
                    }
                    
                    break;
                case Key.Up:
                    if (currentButtonSelectionIndex>=3 && currentButtonSelectionIndex!=9){
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
                default:
                    break;
            }
            /*if (e.Key == Key.Right)
            {
                resetButtonFocus(currentButtonSelectionIndex);
                currentButtonSelectionIndex = (currentButtonSelectionIndex + 1) % 9;
                setButtonFocus(currentButtonSelectionIndex);
            }*/
            
        }
        

        private void munu_button8_Click(object sender, RoutedEventArgs e)
        {
            Notification_tab notification_window = new Notification_tab();
            notification_window.Show();
            this.Close();
            

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
            Music music_Window = new Music();
            music_Window.Show();
            this.Close();
        }

        
    }
}
