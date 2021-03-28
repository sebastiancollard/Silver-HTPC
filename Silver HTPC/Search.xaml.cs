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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Search : Window
    {
        List<Grid> Results = new List<Grid>();
        const int WIDTH = 100;
        const int HEIGHT = 200;
        bool isResultsOnScreen = false;
        int index = 0;

        public Search()
        {
            InitializeComponent();

            MakeResults();

            searchBox.Focus();
        }
        private void MakeResults()
        {
            for (int i = 0; i < 7; ++i)
            {
                Grid result = new Grid();
                result.Width = WIDTH;
                result.Height = 255;
                result.Margin = new Thickness(0, 30, 0, 0);

                Button btn = new Button();
                //btn.Content = i.ToString();
                var brush = new ImageBrush();
                brush.ImageSource = new BitmapImage(new Uri("inception poster.jpg", UriKind.RelativeOrAbsolute));
                btn.Background = brush;
                btn.BorderBrush = new SolidColorBrush(Colors.Black);
                btn.Name = "Button" + i.ToString();
                btn.Width = WIDTH;
                btn.Height = HEIGHT;
                btn.VerticalAlignment = VerticalAlignment.Top;
                btn.Margin = new Thickness();
                btn.Style = (Style)FindResource("MyButtonStyle");
                btn.GotFocus += result_hover;
                btn.LostFocus += result_nhover;
                btn.Foreground = Brushes.Green;

                Image application = new Image();
                //application.Source = new BitmapImage(new Uri("netflix_PNG15.png", UriKind.RelativeOrAbsolute));
                application.Width = 50;
                application.Height = 50;
                application.Margin = new Thickness(0, 205, 0, 0);

                result.Children.Add(btn);
                result.Children.Add(application);
                Results.Add(result);
            }
            //Inception Netflix result
            ((Image)Results[0].Children[1]).Source = new BitmapImage(new Uri("netflix_PNG15.png", UriKind.RelativeOrAbsolute));


            //Inception Prime Video result
            ((Image)Results[1].Children[1]).Source = new BitmapImage(new Uri("prime video.png", UriKind.RelativeOrAbsolute));

            //Inception Apple TV result
            ((Image)Results[2].Children[1]).Source = new BitmapImage(new Uri("apple tv.png", UriKind.RelativeOrAbsolute));
            ((Image)Results[2].Children[1]).Width = 75;
            ((Image)Results[2].Children[1]).Height = 75;

            //Inception Disney+ result
            ((Image)Results[3].Children[1]).Source = new BitmapImage(new Uri("Disney+.png", UriKind.RelativeOrAbsolute));
            ((Image)Results[3].Children[1]).Width = 100;
            ((Image)Results[3].Children[1]).Height = 100;
            ((Image)Results[3].Children[1]).Margin = new Thickness(0, 195, 0, 0);

            //Inception Live TV result
            ((Image)Results[4].Children[1]).Source = new BitmapImage(new Uri("live tv.png", UriKind.RelativeOrAbsolute));
            ((Image)Results[4].Children[1]).Width = 75;
            ((Image)Results[4].Children[1]).Height = 75;
            ((Image)Results[4].Children[1]).Margin = new Thickness(0, 195, 0, 0);

            //Inception Soundtrack Spotify result
            ((Button)Results[5].Children[0]).Background = new ImageBrush { ImageSource = new BitmapImage(new Uri("inception_OST.jpg", UriKind.RelativeOrAbsolute)) };
            ((Button)Results[5].Children[0]).Height = 100;
            ((Button)Results[5].Children[0]).Margin = new Thickness(0, 50, 0, 0);
            ((Image)Results[5].Children[1]).Source = new BitmapImage(new Uri("spotify-download-logo.png", UriKind.RelativeOrAbsolute));

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var tb = sender as TextBox;

            if (!isResultsOnScreen && tb.Text.ToLower().Equals("inception") && filter.Text.Equals("All"))
            {
                stack.Children.Add(new Label { Width = 20 });
                foreach (var res in Results)
                {
                    stack.Children.Add(res);
                    stack.Children.Add(new Label { Width = 20 });
                }
                isResultsOnScreen = true;
            }
            else if (isResultsOnScreen && tb.Text.Equals(""))
            {
                stack.Children.Clear();
                isResultsOnScreen = false;
            }
        }

        private void result_hover(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button;
            btn.Content = "Inception";
            btn.BorderBrush = Brushes.Red;
            ((ImageBrush)btn.Background).Opacity = 0.1;
            if (btn == (Button)(Results[0].Children[0]))
            {
                scroll.ScrollToHorizontalOffset(0);
            }
            else if (btn == (Button)(Results[Results.Count-1].Children[0]))
            {
                scroll.ScrollToHorizontalOffset(100);
            }
        }
        
        private void result_nhover(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button;
            btn.Content = "";
            btn.BorderBrush = Brushes.Black;
            ((ImageBrush)btn.Background).Opacity = 1;
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Back)
            {
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            }
        }

        private void SearchBar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Keyboard.ClearFocus();
                ((Button)((Grid)Results[index]).Children[0]).Focus();
            }
        }
    }
}
