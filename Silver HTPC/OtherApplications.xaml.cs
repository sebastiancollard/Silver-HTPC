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
    /// Interaction logic for OtherApplications.xaml
    /// </summary>
    public partial class OtherApplications : Window
    {
        public static string[,] content;
        public List<Button> buttonList=new List<Button>();
        private static int selectedIndex=0;
    public OtherApplications()
        {
            InitializeComponent();
            content = new string[,] { { "Live TV", "Image/tv_icon.png" }, { "Gallery", "Image/gallery_icon.png" }, { "Music", "Image/music_icon.png" }, { "Recordings", "Image/record_icon.png" }, { "Search", "Image/search_icon.jpg" }, { "Netflix", "Image/netflix_icon.png" }, { "Settings", "Image/settings_icon.png" }, { "Notification", "Image/notification_icon.png" }, { "Other Apps", "Image/apps_icon.png" }, { "John Doe", "Image/profile_icon.png" }, { "Live TV1", "Image/tv_icon.png" }, { "Gallery1", "Image/gallery_icon.png" }, { "Music1", "Image/music_icon.png" }, { "Recordings1", "Image/record_icon.png" }, { "Search1", "Image/search_icon.jpg" }, { "Netflix1", "Image/netflix_icon.png" }, { "Settings1", "Image/settings_icon.png" }, { "Notification1", "Image/notification_icon.png" }, { "Other Apps1", "Image/apps_icon.png" }, { "John Doe1", "Image/profile_icon.png" } };
            bool populated = false;

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
                btn.KeyDown += select;
           

        }

        private void select(object sender, KeyEventArgs e)
        {
            MessageBox.Show("create one");
            var btn = sender as Button;
            //btn.Background = Brushes.Black;
            //if (e.Key == Key.Enter)
            //{
            //  if (btn.Equals(buttonList[1]))
            //{
            Console.WriteLine("reached");
            btn.Background = Brushes.Green;
            btn.BorderBrush = Brushes.Red;
            //}
            //}

        }



        //FOLLOWING CODE IS NOT BEING USED******************************************
        public void setButtonFocus(int button_index)
        {
            //currentButtonSelectionIndex = button_index;
            Button button = buttonList[button_index];
            button.Background = Brushes.DarkBlue;
            //if (button_index != 9) //not profile button
            //{
            
            button.Foreground = Brushes.White;
            //button.Focus();
            //button.Height *= 1.2;

        }
        public void resetButtonFocus(int button_index)
        {
            Button button = buttonList[button_index];
            button.ClearValue(Button.BackgroundProperty);
            button.ClearValue(Button.ForegroundProperty);
            //if (button_index != 9)
            //{
            
            //}

            //button.Height /= 1.2;
        }
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            /*switch (e.Key)
            {
                case Key.Right:
                    if ((selectedIndex % 3) != 2)
                    {
                        resetButtonFocus(selectedIndex);
                        selectedIndex = (selectedIndex + 1) % buttonList.Count;
                        setButtonFocus(selectedIndex);
                    }

                    break;
                case Key.Left:
                    if ((selectedIndex % 3) != 0)
                    {
                        resetButtonFocus(selectedIndex);
                        selectedIndex = (selectedIndex - 1) % buttonList.Count;
                        setButtonFocus(selectedIndex);
                    }

                    break;
                case Key.Down:
                    //if (selectedIndex == buttonList.Count-1)
                    //{
                        //resetButtonFocus(selectedIndex);
                        //selectedIndex = 0;
                        //setButtonFocus(selectedIndex);
                    //}
                    //else if (selectedIndex < 6)
                    //{
                        resetButtonFocus(selectedIndex);
                        selectedIndex = (selectedIndex + 3) % buttonList.Count;
                        setButtonFocus(selectedIndex);
                    //}

                    break;
                case Key.Up:
                    if (selectedIndex >= 3 && selectedIndex != 9)
                    {
                        resetButtonFocus(selectedIndex);
                        selectedIndex = (selectedIndex - 3) % 9;
                        setButtonFocus(selectedIndex);
                    }
                    else
                    {
                        resetButtonFocus(selectedIndex);
                        selectedIndex = 9;
                        setButtonFocus(selectedIndex);
                    }
                    break;
                default:
                    break;
            }*/
            if (e.Key == Key.Back)
            {
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            }
            
        }
        private void OnGotFocusHandler(object sender, RoutedEventArgs e)
        {
            Button tb = sender as Button;
            tb.Background = Brushes.Red;
            //buttonList[selectedIndex].KeyDown += KeyDown;
            //buttonList[selectedIndex].GotFocus += GotFocus;
            //buttonList[selectedIndex].LostFocus += LostFocus;
        }
        // Raised when Button losses focus.
        // Changes the color of the Button back to white.
        private void OnLostFocusHandler(object sender, RoutedEventArgs e)
        {
            Button tb = sender as Button;
            tb.Background = Brushes.White;
        }
        
        /*private void munu_button11_Click(object sender, RoutedEventArgs e)
        {

        }

        private void OtherApplications_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Right)
            {
                if ((selectedIndex % 3) != 2)
                {
                    selectedIndex += 1;
                    buttonList[selectedIndex].Focus();
                }
            }
        }*/

       
    }
}
