﻿using System;
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

namespace Silver_HTPC
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>

    public partial class Photos_Videos : Window
    {
        bool delete_Single_Clicked = false;
        private static List<Button> ButtonsForImages = new List<Button>();
        private static List<Image> ImagesForButtons = new List<Image>();
        private static List<bool> isVideo = new List<bool>();
        private int ButtonIndex = 0;
        private int Start = 0;
        public Photos_Videos()
        {
            InitializeComponent();
            //img_1.GotFocus += Image_GotFocus;
            ButtonsForImages.Add(But_1);
            ButtonsForImages.Add(But_2);
            ButtonsForImages.Add(But_3);
            ButtonsForImages.Add(But_4);
            ButtonsForImages.Add(But_5);

            ImagesForButtons.Add(img_1);
            ImagesForButtons.Add(img_2);
            ImagesForButtons.Add(img_3);
            ImagesForButtons.Add(img_4);
            ImagesForButtons.Add(img_5);

            isVideo.Add(false);
            isVideo.Add(false);
            isVideo.Add(true);
            isVideo.Add(false);
            isVideo.Add(true);

            But_1.Focus();
            
        }

        private void Image_GotFocus(object sender, RoutedEventArgs e)
        {
            Button thisButton = sender as Button;
            thisButton.Background = Brushes.Black;

        }

        private void Image_LostFocus(object sender, RoutedEventArgs e)
        {
            Button thisButton = sender as Button;
            thisButton.Background = Brushes.Gray;

        }

        private void ImageButton_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key== Key.Right && (ButtonIndex +1)%4!=0)
            {
                ButtonIndex += 1;
            }
            else if (e.Key == Key.Left && (ButtonIndex)%4!=0)
            {
                ButtonIndex -= 1;
            }
            else if(e.Key == Key.Down && (ButtonIndex+4 < ButtonsForImages.Count))
            {
                ButtonIndex += 4;
            }
            else if (e.Key == Key.Up && (ButtonIndex-4)>=0)
            {
                ButtonIndex -= 4;
            }
            
            Console.WriteLine("ButtonIndex: " + ButtonIndex);
        }

        private void ImageButton_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter && Start!=0)
            {
                for(int i=0; i<ButtonsForImages.Count; i++)
                {
                    ButtonsForImages[i].Focusable = false;
                }
                //Sort_Button.Focusable = false;
                //Delete_Single.Focusable = false;
                //Delete_Multiple.Focusable = false;
                //scrollViewer.Focusable = false;
                EnlargePhotoGrid.Visibility = Visibility.Visible;
                Button buttonLargerImage = new Button();
                buttonLargerImage.KeyDown += LargeImage_KeyDown;
                buttonLargerImage.Background = Brushes.Black;
                buttonLargerImage.Style = (Style)FindResource("ButtonStyle");
                buttonLargerImage.KeyDown += LargeImage_KeyDown;
                Image biggerImage = new Image();
                biggerImage.Source = new BitmapImage(new Uri(ImagesForButtons[ButtonIndex].Source.ToString(), UriKind.RelativeOrAbsolute));
                biggerImage.KeyDown += LargeImage_KeyDown;
                // CoverPhoto.Source = new BitmapImage(new Uri(CoverPhotosList[MusicIndex], UriKind.RelativeOrAbsolute));
                
                EnlargePhotoGrid.Children.Clear();
                EnlargePhotoGrid.Children.Add(buttonLargerImage);
                EnlargePhotoGrid.Background = Brushes.Black;
                EnlargePhotoGrid.Children.Add(biggerImage);
                
                if (isVideo[ButtonIndex])
                {
                    Image playIcon = new Image();
                    playIcon.Source = new BitmapImage(new Uri("Image/Play.jpg", UriKind.RelativeOrAbsolute));
                    EnlargePhotoGrid.Children.Add(playIcon);
                }
                buttonLargerImage.Focus();
                
            }
            Start += 1;
        }
        private void LargeImage_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Back)
            {
                for (int i = 0; i < ButtonsForImages.Count; i++)
                {
                    ButtonsForImages[i].Focusable = true;
                }
                EnlargePhotoGrid.Visibility = Visibility.Hidden;
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
