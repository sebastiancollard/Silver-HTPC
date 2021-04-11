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
    /// Interaction logic for Notification_tab.xaml
    /// </summary>
    public class NotificationContent
    {
        public NotificationContent(string title, string time, string date, string src, string type, bool btnNeeded, bool running, string info)
        {
            this.Title = title;
            this.Time = time;
            this.Date = date;
            this.ImageSource = src;
            this.Type = type;
            this.NeedButton = btnNeeded;
            this.isRunning = running;
            this.info = info;
        }
        public string Title { get; set; }
        public string Time { get; set; }
        public string Date { get; set; }
        public string ImageSource { get; set; }
        public bool NeedButton { get; set; }
        public string Type { get; set; }
        public bool isRunning { get; set; }
        public string info { get; set; }
    }
    
    
    public partial class Notification_tab : Window
    {
        private static List<NotificationContent> notificationContents=new List<NotificationContent>();
        private static List<Button> notifyButtonList = new List<Button>();
        private int buttonInd = 0;
        public Notification_tab()
        {
            InitializeComponent();
            MainStack.Children.Clear();
            NotificationContent notify0 = new NotificationContent("Recording in progress: Calgary flames", "12:30pm", "14-Apr-2021", "Image/record_icon.png", "Recording", false, true, "Started at 12:30pm");
            NotificationContent notify01 = new NotificationContent("Downloading in progress: Something", "1:00pm", "14-Apr-2021", "Image/forward.png", "Downloading", false, true, "Progress: 65%");
            NotificationContent notify1 = new NotificationContent("Reminder: El classico","1:00pm","14-Apr-2021", "Image/live_tv.png","Reminder",true, false,null) ;
            NotificationContent notify2 = new NotificationContent("Recording scheduled: FRIENDS", "6:00pm", "14-Apr-2021", "Image/record_icon.png", "Recording", true, false,null);
            NotificationContent notify3 = new NotificationContent("Reminder: DDT News special", "10:00pm", "14-Apr-2021", "Image/live_tv.png", "Reminder", true, false, null);

            notificationContents.Add(notify0);
            //notificationContents.Add(notify01);
            notificationContents.Add(notify1);
            notificationContents.Add(notify2);
            notificationContents.Add(notify3);
            createButtons();
            displayButtons();
            foreach (Button btn in notifyButtonList)
            {
                btn.GotFocus += select;
                btn.LostFocus += nselect;
            }
            MainStack.Children[0].Focus();
            
        }

        private void select(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("create one");
            Button button = sender as Button;
            //btn.Background = Brushes.Black;
            //if (e.Key == Key.Enter)
            //{
            //  if (btn.Equals(buttonList[1]))
            //{
            Console.WriteLine("reached");
            button.Background = Brushes.Green;
            button.BorderBrush = Brushes.Red;
            //}
            //}
            
            button.Height += 25;
            scroll.ScrollToVerticalOffset(button.TranslatePoint(new Point(), MainStack).Y - 150);



        }

        private void nselect(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button;
            btn.Background = Brushes.LightGray;
            btn.BorderBrush = Brushes.Transparent;
            btn.Height -= 25;
        }

        private void resetButtons()
        {
            buttonInd = 0;
            MainStack.Children.Clear();
            notificationContents.RemoveAt(notificationContents.Count - 1);
            notifyButtonList.Clear();
            createButtons();
            displayButtons();
            foreach (Button btn in notifyButtonList)
            {
                btn.GotFocus += select;
                btn.LostFocus += nselect;
            }
            MainStack.Children[0].Focus();

        }

        private void displayButtons()
        {
            int length = notifyButtonList.Count;
            for (int i=0; i < length; i++)
            {
                MainStack.Children.Add(notifyButtonList[i]);
            }
        }

        private void createButtons()
        {
            int length = notificationContents.Count;
            
            for (int i = 0; i < length; i++)
            {

                Button btn = new Button();
                btn.Name = "notifyBtn" + i.ToString();
                btn.Height = 85;
                btn.HorizontalContentAlignment = HorizontalAlignment.Left;
                btn.Background = Brushes.White;
                StackPanel outerSP = new StackPanel();

                Grid outerGrid = new Grid();
                //outerGrid.Background = Brushes.Green;
                outerGrid.Height = 80;
                outerGrid.Width = 800;
                ColumnDefinition colDef1 = new ColumnDefinition();
                ColumnDefinition colDef2 = new ColumnDefinition();
                ColumnDefinition colDef3 = new ColumnDefinition();
                colDef1.Width= new GridLength(1, GridUnitType.Star);
                if (notificationContents[i].isRunning)
                {
                    colDef2.Width = new GridLength(3.5, GridUnitType.Star);
                    colDef3.Width = new GridLength(1.5, GridUnitType.Star);
                }
                else
                {
                    colDef2.Width= new GridLength(4, GridUnitType.Star);
                    colDef3.Width= new GridLength(1, GridUnitType.Star);
                }
                

                outerGrid.ColumnDefinitions.Add(colDef1);
                outerGrid.ColumnDefinitions.Add(colDef2);
                outerGrid.ColumnDefinitions.Add(colDef3);
                Image img = new Image();
                img.Height = 70;
                img.Width = 70;
                Uri imageUri = new Uri(notificationContents[i].ImageSource, UriKind.Relative);
                img.Source = new BitmapImage(imageUri);
                Grid.SetColumn(img, 0);
                Grid.SetRow(img, 0);
                outerGrid.Children.Add(img);
                TextBlock title = new TextBlock();
                title.Text = notificationContents[i].Title;
                title.TextWrapping = TextWrapping.WrapWithOverflow;
                title.FontSize = 23;
                title.VerticalAlignment = VerticalAlignment.Center;
                Grid.SetColumn(title, 1);
                Grid.SetRow(title, 0);
                outerGrid.Children.Add(title);
                StackPanel innerStack = new StackPanel();
                if (!notificationContents[i].isRunning){
                    innerStack.Height = 80;
                    Label time = new Label();
                    time.FontSize = 20;
                    time.Height = 40;
                    time.VerticalContentAlignment = VerticalAlignment.Center;
                    time.Content = notificationContents[i].Time;
                    Label date = new Label();
                    date.FontSize = 20;
                    date.Height = 40;
                    date.VerticalContentAlignment = VerticalAlignment.Center;
                    date.Content = notificationContents[i].Date;
                    innerStack.Children.Add(time);
                    innerStack.Children.Add(date);
                    Grid.SetColumn(innerStack, 2);
                    Grid.SetRow(innerStack, 0);
                    outerGrid.Children.Add(innerStack);
                }
                else
                {
                    TextBlock info = new TextBlock();
                    info.Height = 80;
                    info.FontSize = 20;
                    info.TextWrapping = TextWrapping.WrapWithOverflow;
                    info.VerticalAlignment = VerticalAlignment.Bottom;
                    
                    info.Text = notificationContents[i].info;
                    Grid.SetColumn(info, 2);
                    Grid.SetRow(info, 0);
                    outerGrid.Children.Add(info);
                }
                outerSP.Children.Add(outerGrid);
                if (notificationContents[i].NeedButton)
                {
                    Label buttonText = new Label();
                    StackPanel inLabel = new StackPanel();
                    inLabel.Orientation = Orientation.Horizontal;
                    inLabel.HorizontalAlignment = HorizontalAlignment.Center;
                    Image okButton_img = new Image();
                    Uri imgUri = new Uri("Image/ok_button.png", UriKind.Relative);
                    okButton_img.Source = new BitmapImage(imgUri);
                    okButton_img.Height = 20;
                    okButton_img.Width = 20;
                    
                    buttonText.Name = "buttonText" + i.ToString();
                    buttonText.Content = "Press Ok to continue";
                    //buttonText.Foreground=Brushes.
                    buttonText.FontSize = 15;
                    //buttonText.Height = 20;
                    //buttonText.Width = 800;
                    buttonText.FontWeight = FontWeights.Bold;
                    buttonText.HorizontalContentAlignment = HorizontalAlignment.Center;
                    //buttonText.VerticalAlignment = VerticalAlignment.Top;
                    //buttonText.Visibility = Visibility.Collapsed;
                    inLabel.Children.Add(okButton_img);
                    inLabel.Children.Add(buttonText);
                    outerSP.Children.Add(inLabel);

                }
                btn.Content = outerSP;
                if (notificationContents[i].isRunning)
                {
                    notifyButtonList.Insert(0, btn);
                }
                else
                {
                    notifyButtonList.Add(btn);
                }


            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Back)
            {
                MainWindow home = new MainWindow();
                home.Show();
                this.Close();
            }else if (e.Key == Key.Z)
            {
                resetButtons();
            }
            else if (e.Key == Key.Down)
            {
                buttonInd += 1%notificationContents.Count;
            }
            else if (e.Key == Key.Up)
            {
                if (buttonInd == 0)
                {
                    buttonInd = notificationContents.Count - 1;
                }
                else
                {
                    buttonInd -= 1 % notificationContents.Count;
                }
            }
        }
    }
}
/*
 <Button Height="85" HorizontalContentAlignment="Left" Background="#FFDDDDDD">
            <Grid Width="800" Height="70">
                <Grid.ColumnDefinitions>
                    <ColumnDefinition Width="1*" />
                    <ColumnDefinition Width="5*" />
                </Grid.ColumnDefinitions>
                <Image Source="Image\download_icon.png" Stretch="Fill" Height="70" Width="70" Grid.Column="0"/>
                <Grid Grid.Column="1">
                    <Grid.RowDefinitions>
                        <RowDefinition Height="2*" />
                        <RowDefinition Height="1*" />
                    </Grid.RowDefinitions>
                    <TextBlock Text="Downloading Crave TV" FontSize="23" HorizontalAlignment="Left" Grid.Row="0" VerticalAlignment="Center"/>
                    <TextBlock Text="20% [.................                                              ]" FontSize="20" HorizontalAlignment="Left" Grid.Row="1" VerticalAlignment="Center"/>
                </Grid>
                
            </Grid>
        </Button>
        <Button Height="85" HorizontalContentAlignment="Left">
            <Grid Width="800" Height="80">
                <Grid.ColumnDefinitions>
                    <ColumnDefinition Width="1*" />
                    <ColumnDefinition Width="4*" />
                    <ColumnDefinition Width="1*" />
                </Grid.ColumnDefinitions>
                <Image Source="Image\tv_icon.png" Stretch="Fill" Height="70" Width="70" Grid.Column="0"/>

                <TextBlock Text="Latest Notification" FontSize="23" HorizontalAlignment="Left" Grid.Column="1" VerticalAlignment="Center"/>
                <Grid Grid.Column="2">
                    <Grid.RowDefinitions>
                        <RowDefinition Height="1*" />
                        <RowDefinition Height="1*" />
                    </Grid.RowDefinitions>
                    <TextBlock Text="Time" FontSize="20" HorizontalAlignment="Left" Grid.Row="0" VerticalAlignment="Center" TextWrapping="Wrap"/>
                    <TextBlock Text="Date" FontSize="20" HorizontalAlignment="Left" Grid.Row="1" VerticalAlignment="Center"/>
                </Grid>
            </Grid>
         </Button>
        <Button Height="85" HorizontalContentAlignment="Left">
            <Grid Width="800" Height="80">
                <Grid.ColumnDefinitions>
                    <ColumnDefinition Width="1*" />
                    <ColumnDefinition Width="4*" />
                    <ColumnDefinition Width="1*" />
                </Grid.ColumnDefinitions>
                <Image Source="Image\record_icon.png" Stretch="Fill" Height="70" Width="70" Grid.Column="0"/>

                <TextBlock Text="Notification 2" FontSize="23" HorizontalAlignment="Left" Grid.Column="1" VerticalAlignment="Center"/>
                <Grid Grid.Column="2">
                    <Grid.RowDefinitions>
                        <RowDefinition Height="1*" />
                        <RowDefinition Height="1*" />
                    </Grid.RowDefinitions>
                    <TextBlock Text="Time" FontSize="20" HorizontalAlignment="Left" Grid.Row="0" VerticalAlignment="Center" TextWrapping="Wrap"/>
                    <TextBlock Text="Date" FontSize="20" HorizontalAlignment="Left" Grid.Row="1" VerticalAlignment="Center"/>
                </Grid>
            </Grid>
        </Button>
        <Button Height="85" HorizontalContentAlignment="Left">
            <Grid Width="800" Height="80">
                <Grid.ColumnDefinitions>
                    <ColumnDefinition Width="1*" />
                    <ColumnDefinition Width="4*" />
                    <ColumnDefinition Width="1*" />
                </Grid.ColumnDefinitions>
                <Image Source="Image\tv_icon.png" Stretch="Fill" Height="70" Width="70" Grid.Column="0"/>

                <TextBlock Text="Notification 3" FontSize="23" HorizontalAlignment="Left" Grid.Column="1" VerticalAlignment="Center"/>
                <Grid Grid.Column="2">
                    <Grid.RowDefinitions>
                        <RowDefinition Height="1*" />
                        <RowDefinition Height="1*" />
                    </Grid.RowDefinitions>
                    <TextBlock Text="Time" FontSize="20" HorizontalAlignment="Left" Grid.Row="0" VerticalAlignment="Center" TextWrapping="Wrap"/>
                    <TextBlock Text="Date" FontSize="20" HorizontalAlignment="Left" Grid.Row="1" VerticalAlignment="Center"/>
                </Grid>
            </Grid>
        </Button>
     */
