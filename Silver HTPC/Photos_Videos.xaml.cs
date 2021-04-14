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
using System.Windows.Threading;

namespace Silver_HTPC
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>

    public partial class Photos_Videos : Window
    {
        bool delete_Single_Clicked = false;
        private List<Button> ButtonsForImages = new List<Button>();
        private List<Image> ImagesForButtons = new List<Image>();
        private List<bool> isVideo = new List<bool>();
        private int ButtonIndex = 0;
        private int Start = 0;
        private bool viewingEnlargaredImages = false;
        private DispatcherTimer dispatcherTimerTime;
        public Photos_Videos()
        {

            dispatcherTimerTime = new DispatcherTimer();
            dispatcherTimerTime.Interval = new TimeSpan(0, 0, 5);
            DispatcherTimer timer = new DispatcherTimer(new TimeSpan(0, 0, 1), DispatcherPriority.Normal, delegate
            {
                this.guide_time.Content = DateTime.Now.ToString("hh:mm tt");
                this.guide_date.Content = DateTime.Now.ToString("MMMM dd, yyyy");
            }, this.Dispatcher); 

            InitializeComponent();
            //img_1.GotFocus += Image_GotFocus;
            ButtonsForImages.Add(But_1);
            ButtonsForImages.Add(But_2);
            ButtonsForImages.Add(But_3);
            ButtonsForImages.Add(But_4);
            ButtonsForImages.Add(But_5);
            ButtonsForImages.Add(But_6);
            ButtonsForImages.Add(But_7);
            ButtonsForImages.Add(But_8);

            ImagesForButtons.Add(img_1);
            ImagesForButtons.Add(img_2);
            ImagesForButtons.Add(img_3);
            ImagesForButtons.Add(img_4);
            ImagesForButtons.Add(img_5);
            ImagesForButtons.Add(img_6);
            ImagesForButtons.Add(img_7);
            ImagesForButtons.Add(img_8);

            isVideo.Add(false);
            isVideo.Add(false);
            isVideo.Add(true);
            isVideo.Add(false);
            isVideo.Add(true);
            isVideo.Add(false);
            isVideo.Add(false);
            isVideo.Add(false);

            But_1.Focus();
            
        }

        private void Image_GotFocus(object sender, RoutedEventArgs e)
        {
            Button thisButton = sender as Button;
            thisButton.Background = Brushes.Black;
            //thisButton.Background = (LinearGradientBrush)FindResource("ButtonHoverBackground");

        }

        private void Image_LostFocus(object sender, RoutedEventArgs e)
        {
            Button thisButton = sender as Button;
            thisButton.Style = (Style)FindResource("StandardButton");
            thisButton.Background = (LinearGradientBrush)FindResource("ButtonNormalBackground");

        }

        private void ImageButton_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Right && (ButtonIndex + 1) % 4 != 0)
            {
                ButtonIndex += 1;
            }
            else if (e.Key == Key.Right && (ButtonIndex + 1) % 4 == 0)
            {
                for (int i = 0; i < ButtonsForImages.Count; i++)
                {
                    ButtonsForImages[i].Focusable = false;
                }
                Sort_Button.Focus();
            }
            else if (e.Key == Key.Left && (ButtonIndex) % 4 != 0)
            {
                ButtonIndex -= 1;
            }
            else if (e.Key == Key.Down && (ButtonIndex + 4 < ButtonsForImages.Count))
            {
                ButtonIndex += 4;
            }
            else if (e.Key == Key.Down && (ButtonIndex + 4 > ButtonsForImages.Count))
            {
                ButtonIndex = ButtonIndex % 4;
            }
            else if (e.Key == Key.Up && (ButtonIndex-4)>=0)
            {
                ButtonIndex -= 4;
            }
            
            else if(e.Key==Key.Up && (ButtonIndex) < 4)
            {
                ButtonIndex += 4;
            }
            
            else if (e.Key == Key.Back && !viewingEnlargaredImages)
            {
                MainWindow home = new MainWindow();
                home.Show();
                this.Close();
            }
            else if (e.Key == Key.O)
            {
                EnlargePhotoScreen();
            }

            Console.WriteLine("ButtonIndex: " + ButtonIndex);
        }

        private void LargeImage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Back)
            {
                
                for (int i = 0; i < ButtonsForImages.Count; i++)
                {
                    ButtonsForImages[i].Focusable = true;
                }
                Sort_Button.Focusable = true;
                
                Delete_Multiple.Focusable = true;
                scrollViewer.Focusable = true;
                EnlargePhotoGrid.Visibility = Visibility.Hidden;
                ButtonsForImages[ButtonIndex].Focus();
                viewingEnlargaredImages = false;

            }
            else if (e.Key == Key.Right)
            {
                if (ButtonIndex < ButtonsForImages.Count-1)
                {
                    Console.WriteLine("ButtonIndexRight: " + ButtonIndex);
                    ButtonIndex += 1;
                    EnlargePhotoScreen();
                    
                }
            }
            else if (e.Key == Key.Left)
            {
                if (ButtonIndex != 0)
                {
                    ButtonIndex -= 1;
                    EnlargePhotoScreen();
                }
            }
            
        }

      

            void EnlargePhotoScreen()
        {
            viewingEnlargaredImages = true;
            for (int i = 0; i < ButtonsForImages.Count; i++)
            {
                ButtonsForImages[i].Focusable = false;
            }
            Sort_Button.Focusable = false;
            
            Delete_Multiple.Focusable = false;
            scrollViewer.Focusable = false;
            Add_Button.Focusable = false;
            EnlargePhotoGrid.Visibility = Visibility.Visible;
            Button buttonLargerImage = new Button();
            buttonLargerImage.KeyDown += LargeImage_KeyDown;
            //buttonLargerImage.KeyUp += LargeImage_KeyUp;
            buttonLargerImage.Background = Brushes.White;
            buttonLargerImage.Style = (Style)FindResource("ButtonStyle");
            //buttonLargerImage.KeyDown += LargeImage_KeyDown;
            Grid.SetRowSpan(buttonLargerImage, 3);
            Grid.SetColumnSpan(buttonLargerImage, 3);
            Image biggerImage = new Image();
            biggerImage.Source = new BitmapImage(new Uri(ImagesForButtons[ButtonIndex].Source.ToString(), UriKind.RelativeOrAbsolute));
            //biggerImage.KeyDown += LargeImage_KeyDown;
            Grid.SetRowSpan(biggerImage, 3);
            Grid.SetColumnSpan(biggerImage, 3);
            // CoverPhoto.Source = new BitmapImage(new Uri(CoverPhotosList[MusicIndex], UriKind.RelativeOrAbsolute));

            Image rightArrow = new Image();
            rightArrow.Source = new BitmapImage(new Uri("Image/rightArrow.png", UriKind.RelativeOrAbsolute));
            Grid.SetRow(rightArrow, 1);
            Grid.SetColumn(rightArrow, 2);
            // Grid.SetRowSpan(rightArrow, 3);
            // Grid.SetColumnSpan(rightArrow, 3);

            Image leftArrow = new Image();
            leftArrow.Source = new BitmapImage(new Uri("Image/leftArrow.png", UriKind.RelativeOrAbsolute));
            Grid.SetRow(leftArrow, 1);
            Grid.SetColumn(leftArrow, 0);


            EnlargePhotoGrid.Children.Clear();
            //EnlargePhotoGrid.Children.Add(rightArrow);
            EnlargePhotoGrid.Children.Add(buttonLargerImage);
            EnlargePhotoGrid.Background = Brushes.Black;
            EnlargePhotoGrid.Children.Add(biggerImage);
            EnlargePhotoGrid.Children.Add(rightArrow);
            EnlargePhotoGrid.Children.Add(leftArrow);

            if (isVideo[ButtonIndex])
            {
                Image playIcon = new Image();
                playIcon.Source = new BitmapImage(new Uri("Image/Play.jpg", UriKind.RelativeOrAbsolute));
                Grid.SetRowSpan(playIcon, 3);
                Grid.SetColumnSpan(playIcon, 3);
                EnlargePhotoGrid.Children.Add(playIcon);
            }
            buttonLargerImage.Focus();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            //Console.WriteLine(viewingEnlargaredImages);
            
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
        private void Delete_GotFocus(object sender, RoutedEventArgs e)
        {
            Button thisButton = sender as Button;
            //thisButton.Background = Brushes.Red;
            thisButton.Style = (Style)FindResource("HoverButton");
            thisButton.Background = (LinearGradientBrush)FindResource("DangerButtonHoverBackground");
            Console.WriteLine("Here");
            //thisButton.Height = 60;
        }

        private void Button_LostFocus(object sender, RoutedEventArgs e)
        {
            Button thisButton = sender as Button;
            //thisButton.Background = Brushes.White;
            thisButton.Style = (Style)FindResource("StandardButton");
            thisButton.Background = (LinearGradientBrush)FindResource("ButtonNormalBackground");
            //thisButton.Height = 44;
        }

        private void Button_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Back)
            {
                MainWindow home = new MainWindow();
                home.Show();
                this.Close();
            }
            else if (e.Key == Key.O)
            {
                MessageBox.Show("Sorry this feature has not been implemented! We aplogize for the inconvenience.", "Silver HTPC", MessageBoxButton.OK);
            }
            else if(e.Key == Key.Left)
            {
                for(int i =0; i<ButtonsForImages.Count; i++)
                {
                    ButtonsForImages[i].Focusable = true;
                }
                ButtonsForImages[ButtonIndex].Focus();
            }
        }


            /**
                private void Delete_Single_Click(object sender, RoutedEventArgs e)
            {
                delete_Single_Clicked = true;
            }

            private void img_1_Hovering(object sender, MouseEventArgs e)
            {
                if (delete_Single_Clicked)
                {
                    img_1.Opacity = 0.5;
                }
            }

            private void img_1_Leaving(object sender, MouseEventArgs e)
            {
                if (delete_Single_Clicked)
                {
                    img_1.Opacity = 1.0;
                }
            }
            **/


            // How do we want to implement functionality? Using keys? Using mouse for the prototype?
            // Having a hard time implementing button functionality.
            // Have images turn different colour when hovering?
            // How do we want "selecting specific things" to look like?
        }
}
