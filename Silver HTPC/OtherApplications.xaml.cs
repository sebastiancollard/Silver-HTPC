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

namespace Silver_HTPC
{
    /// <summary>
    /// Interaction logic for OtherApplications.xaml
    /// </summary>
    public partial class OtherApplications : Window
    {
        public static string[,] content;
        public List<Button> buttonList=new List<Button>();
        private static int selectedIndex=0;
        private DispatcherTimer dispatcherTimer;
        public OtherApplications()
        {
            InitializeComponent();
            content = new string[,] { { "Live TV", "Image/tv_icon.png" }, { "Gallery", "Image/gallery_icon.png" }, { "Music", "Image/music_icon.png" }, { "Recordings", "Image/record_icon.png" }, { "Search", "Image/search_icon.jpg" }, { "Netflix", "Image/netflix_icon.png" }, { "Settings", "Image/settings_icon.png" }, { "Notification", "Image/notification_icon.png" }, { "Other Apps", "Image/apps_icon.png" }, { "John Doe", "Image/profile_icon.png" }, { "Live TV1", "Image/tv_icon.png" }, { "Gallery1", "Image/gallery_icon.png" }, { "Music1", "Image/music_icon.png" }, { "Recordings1", "Image/record_icon.png" }, { "Search1", "Image/search_icon.jpg" }, { "Netflix1", "Image/netflix_icon.png" }, { "Settings1", "Image/settings_icon.png" }, { "Notification1", "Image/notification_icon.png" }, { "Other Apps1", "Image/apps_icon.png" }, { "John Doe1", "Image/profile_icon.png" } };
            //bool populated = false;
            //For notification popup***********************************************
            dispatcherTimer = new DispatcherTimer();                            
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 5);
            //**********************************************************************

            int numOfRows = 7;// (int)(content.Length / 3) + 1;
            Grid grid = new Grid();
            grid.Name = "Other_grid";
            grid.Height = 97 * numOfRows;
            grid.Width = 800;
            for (int i=0; i<numOfRows; i++)
            {
                RowDefinition rowDef = new RowDefinition();
                rowDef.Name = "row" + i.ToString();
                grid.RowDefinitions.Add(rowDef);
            }
            ColumnDefinition colDef1 = new ColumnDefinition();
            ColumnDefinition colDef2 = new ColumnDefinition();
            ColumnDefinition colDef3 = new ColumnDefinition();
            grid.ColumnDefinitions.Add(colDef1);
            grid.ColumnDefinitions.Add(colDef2);
            grid.ColumnDefinitions.Add(colDef3);
            int currColumn = 0;
            int currRow = 0;
            
            for (int i =0; i < 20; i++)
            {
                Button btn = new Button();
                btn.Name = "otherBtn" + i.ToString();
                btn.Height = 80;
                btn.Width = 170;
                StackPanel stackPanelBtn = new StackPanel();
                Image image = new Image();
                image.Height = 45;
                image.Width = 45;
                Uri imageUri = new Uri(content[i, 1], UriKind.Relative);
                image.Source = new BitmapImage(imageUri);
                stackPanelBtn.Children.Add(image);
                Label lbl = new Label();
                lbl.Content = content[i, 0];
                lbl.FontSize = 20;
                stackPanelBtn.Children.Add(lbl);
                btn.Content = stackPanelBtn;
                buttonList.Add(btn);
                //btn.Focusable = true;
                Grid.SetColumn(btn, currColumn);
                Grid.SetRow(btn, currRow);
                grid.Children.Add(btn);

                
                if (currColumn == 2)
                {
                    currColumn = 0;
                    currRow++;
                }
                else
                {
                    currColumn++;
                }
            }
            Other_StackPanel.Children.Add(grid);
            //setButtonFocus(selectedIndex);
            //grid.Focus();
            foreach (Button btn in buttonList)
            {
                btn.GotFocus += select;
                btn.LostFocus += nselect;
            }

            ((Grid)Other_StackPanel.Children[0]).Children[0].Focus();
        }

        private void select(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("create one");
            var btn = sender as Button;
            //btn.Background = Brushes.Black;
            //if (e.Key == Key.Enter)
            //{
            //  if (btn.Equals(buttonList[1]))
            //{
            Console.WriteLine("reached");
            btn.Background = Brushes.Green;
            btn.BorderBrush = Brushes.Red;
            MainWindow mainWindow = new MainWindow();
            
            //}
            //}
            scroll.ScrollToVerticalOffset(btn.TranslatePoint(new Point(), Other_StackPanel).Y - 150);

        }

        private void nselect(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button;
            btn.Background = Brushes.LightGray;
            btn.BorderBrush = Brushes.Transparent;
        }



        //FOLLOWING CODE IS NOT BEING USED******************************************
        
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Back)
            {
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            }
            if (e.Key == Key.Z)
            { //hardcoded to show notification
                Notification_popup0.Visibility = Visibility.Visible;
                dispatcherTimer.Start();
            }
            if (Notification_popup0.Visibility == Visibility.Visible)
            {
                if (e.Key==Key.O){
                    LiveTV liveTV = new LiveTV(2);
                    liveTV.Show();
                    this.Close();
                }
            }
            
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {//For notification
            //Things which happen after 1 timer interval
            
            Notification_popup0.Visibility = Visibility.Collapsed;

            //Disable the timer
            dispatcherTimer.IsEnabled = false;
        }

    }
}
