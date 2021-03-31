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

namespace Silver_HTPC
{
    /// <summary>
    /// Interaction logic for Search.xaml
    /// </summary>
    public partial class Search : Window
    {
        static List<Grid> Results = new List<Grid>();
        static List<string> searches = new List<string> { "inception", "spidermanfarfromehome", "spidermanintothespiderverse", "spidermanhomecoming", "theamazingspiderman2", "theamazingspiderman", "spiderman3", "spiderman2", "spiderman" };
        const int WIDTH = 100;
        const int HEIGHT = 200;
        bool isResultsOnScreen = false;
        bool found = false;
        const int offset = 340;

        public Search()
        {
            InitializeComponent();

            MakeResults();

            searchBox.Focus();
        }
        private void MakeResults()
        {
            for (int i = 0; i <= 34; ++i)
            {
                Grid result = new Grid();
                result.Width = WIDTH;
                result.Height = 255;
                result.Margin = new Thickness(0, 30, 0, 0);

                Button btn = new Button();
                //btn.Content = i.ToString();
                var brush = new ImageBrush();
                if (i < 6)
                    brush.ImageSource = new BitmapImage(new Uri("inception poster.jpg", UriKind.RelativeOrAbsolute));
                else if (i == 6)
                    brush.ImageSource = new BitmapImage(new Uri("inception_OST.jpg", UriKind.RelativeOrAbsolute));
                else if (i > 6 && i < 9)
                    brush.ImageSource = new BitmapImage(new Uri("spidermanfarfromhome.jpeg", UriKind.RelativeOrAbsolute));
                else if (i == 9)
                    brush.ImageSource = new BitmapImage(new Uri("spidermanfarfromhome_OST.jpg", UriKind.RelativeOrAbsolute));
                else if (i > 9 && i < 13)
                    brush.ImageSource = new BitmapImage(new Uri("spiderverse_1.jpg", UriKind.RelativeOrAbsolute));
                else if (i == 13)
                    brush.ImageSource = new BitmapImage(new Uri("spiderverse_OST.jpg", UriKind.RelativeOrAbsolute));
                else if (i > 13 && i < 17)
                    brush.ImageSource = new BitmapImage(new Uri("spidermanhomecoming.jpg", UriKind.RelativeOrAbsolute));
                else if (i == 17)
                    brush.ImageSource = new BitmapImage(new Uri("spidermanhomecoming_OST.jpg", UriKind.RelativeOrAbsolute));
                else if (i > 17 && i < 21)
                    brush.ImageSource = new BitmapImage(new Uri("theamazingspiderman2.jpg", UriKind.RelativeOrAbsolute));
                else if (i == 21)
                    brush.ImageSource = new BitmapImage(new Uri("theamazingspiderman2_OST.jpg", UriKind.RelativeOrAbsolute));
                else if (i > 21 && i < 24)
                    brush.ImageSource = new BitmapImage(new Uri("theamazingspiderman.jpg", UriKind.RelativeOrAbsolute));
                else if (i == 24)
                    brush.ImageSource = new BitmapImage(new Uri("theamazingspiderman_OST.jpg", UriKind.RelativeOrAbsolute));
                else if (i > 24 && i < 27)
                    brush.ImageSource = new BitmapImage(new Uri("spiderman3.jpg", UriKind.RelativeOrAbsolute));
                else if (i == 27)
                    brush.ImageSource = new BitmapImage(new Uri("spiderman3_OST.jpg", UriKind.RelativeOrAbsolute));
                else if (i > 27 && i < 30)
                    brush.ImageSource = new BitmapImage(new Uri("spiderman2.jpg", UriKind.RelativeOrAbsolute));
                else if (i == 30)
                    brush.ImageSource = new BitmapImage(new Uri("spiderman2_OST.jpg", UriKind.RelativeOrAbsolute));
                else if (i > 30 && i < 34)
                    brush.ImageSource = new BitmapImage(new Uri("spiderman.jpg", UriKind.RelativeOrAbsolute));
                else if (i == 34)
                    brush.ImageSource = new BitmapImage(new Uri("spiderman_OST.jpg", UriKind.RelativeOrAbsolute));

                btn.Content = new StackPanel();
                btn.KeyDown += Window_KeyDown;
                btn.Background = brush;
                btn.BorderBrush = new SolidColorBrush(Colors.Black);
                btn.Name = "Button" + i.ToString();
                btn.Width = WIDTH;
                btn.Height = HEIGHT;
                double aspect = ((ImageBrush)btn.Background).ImageSource.Width / ((ImageBrush)btn.Background).ImageSource.Height;
                btn.Width = btn.Height * aspect;
                result.Width = btn.Height * aspect;
                btn.HorizontalAlignment = HorizontalAlignment.Center;
                btn.VerticalAlignment = VerticalAlignment.Top;
                btn.Margin = new Thickness();
                btn.Style = (Style)FindResource("MyButtonStyle");
                btn.GotFocus += result_selected;
                btn.LostFocus += result_nselected;
                btn.Foreground = Brushes.Green;

                Label bg = new Label();
                bg.Background = Brushes.Black;
                bg.Width = WIDTH;
                bg.Height = HEIGHT;
                bg.VerticalAlignment = VerticalAlignment.Top;
                bg.Width = btn.Height * aspect;
                bg.Style = (Style)FindResource("MyLabelStyle");

                Image application = new Image();
                application.Width = 50;
                application.Height = 50;
                application.Margin = new Thickness(0, 205, 0, 0);

                if (i == 0 || i == 7 || i == 10 || i == 14 || i == 18 || i == 31) //Netflix
                    application.Source = new BitmapImage(new Uri("netflix_PNG15.png", UriKind.RelativeOrAbsolute));
                else if (i == 1 || i == 8 || i == 11 || i == 15 || i == 19 || i == 22 || i == 25 || i == 28 || i == 32) //Prime Video
                    application.Source = new BitmapImage(new Uri("prime video.png", UriKind.RelativeOrAbsolute));
                else if (i == 2)
                {   //Apple TV
                    application.Source = new BitmapImage(new Uri("apple tv.png", UriKind.RelativeOrAbsolute));
                    application.Width = 75;
                    application.Height = 75;
                }
                else if (i == 3)
                {   //Disney+
                    application.Source = new BitmapImage(new Uri("Disney+.png", UriKind.RelativeOrAbsolute));
                    application.Width = 100;
                    application.Height = 100;
                    application.Margin = new Thickness(0, 195, 0, 0);
                }
                else if (i == 4)
                {   //Live TV
                    application.Source = new BitmapImage(new Uri("live tv.png", UriKind.RelativeOrAbsolute));
                    application.Width = 75;
                    application.Height = 75;
                    application.Margin = new Thickness(0, 195, 0, 0);
                }
                else if (i == 5 || i == 8 || i == 12 || i == 16 || i == 20 || i == 23 || i == 26 || i == 29 || i == 33)
                {   //Youtube
                    application.Source = new BitmapImage(new Uri("youtube.png", UriKind.RelativeOrAbsolute));
                    application.Width = 100;
                    application.Height = 100;
                    application.Margin = new Thickness(0, 195, 0, 0);
                }
                else if (i == 6 || i == 9 || i == 13 || i == 17 || i == 21 || i == 24 || i == 27 || i == 30 || i == 34)
                {   //Spotify
                    bg.Height = 100;
                    bg.Margin = new Thickness(0, 50, 0, 0);
                    btn.Height = 100;
                    btn.Margin = new Thickness(0, 50, 0, 0);
                    application.Source = new BitmapImage(new Uri("spotify-download-logo.png", UriKind.RelativeOrAbsolute));
                }


                if (i != 6 && i != 9 && i != 13 && i != 17 && i != 21 && i != 24 && i != 27 && i != 30 && i != 34)
                {   //Non-Spotify
                    StackPanel content = new StackPanel();

                    TextBox title = new TextBox();
                    title.FontSize = 10;
                    title.TextAlignment = TextAlignment.Center;
                    title.TextWrapping = TextWrapping.Wrap;
                    title.FontFamily = new FontFamily("Segoe UI");
                    title.Foreground = Brushes.White;
                    title.Background = new SolidColorBrush();
                    title.Background.Opacity = 0;
                    title.HorizontalAlignment = HorizontalAlignment.Center;
                    LinearGradientBrush gradient = new LinearGradientBrush();
                    gradient.EndPoint = new Point(0.5, 1);
                    gradient.StartPoint = new Point(0.5, 0);
                    gradient.GradientStops.Add(new GradientStop { Offset = 0 });
                    gradient.GradientStops.Add(new GradientStop { Offset = 1, Color = Colors.White });
                    title.BorderBrush = gradient;
                    title.IsHitTestVisible = false;
                    title.IsReadOnly = true;
                    title.Focusable = false;

                    TextBox info = new TextBox();
                    info.FontSize = 10;
                    info.TextAlignment = TextAlignment.Center;
                    info.Foreground = Brushes.White;
                    info.FontFamily = new FontFamily("Segoe UI");
                    info.Background = new SolidColorBrush();
                    info.Background.Opacity = 0;
                    info.BorderBrush = new SolidColorBrush { Opacity = 0 };
                    info.HorizontalAlignment = HorizontalAlignment.Center;
                    info.IsHitTestVisible = false;
                    info.IsReadOnly = true;
                    info.Focusable = false;


                    TextBox description = new TextBox();
                    description.TextWrapping = TextWrapping.Wrap;
                    description.Foreground = Brushes.White;
                    description.FontSize = 10;
                    description.FontFamily = new FontFamily("Segoe UI");
                    description.FontSize = 9;
                    description.Background = new SolidColorBrush();
                    description.Background.Opacity = 0;
                    description.HorizontalAlignment = HorizontalAlignment.Center;
                    LinearGradientBrush gradient2 = new LinearGradientBrush();
                    gradient2.EndPoint = new Point(0.5, 1);
                    gradient2.StartPoint = new Point(0.5, 0);
                    gradient2.GradientStops.Add(new GradientStop { Offset = 1 });
                    gradient2.GradientStops.Add(new GradientStop { Offset = 0, Color = Colors.White });
                    description.BorderBrush = gradient2;
                    description.IsReadOnly = true;
                    description.Focusable = false;

                    if (i < 6)
                    {
                        title.Text = "Inception";
                        info.Text = "2010\n 148 min";
                        description.Text = "A thief who steals corporate secrets through the use of dream-sharing technology is given the inverse task of planting an idea into the mind of a C.E.O.";
                    }
                    else if (i > 6 && i < 9)
                    {
                        title.Text = "Spider-Man: Far From Home";
                        info.Text = "2019\n 129 min";
                        description.Text = "Following the events of Avengers: Endgame (2019), Spider-Man must step up to take on new threats in a world that has changed forever.";
                    }
                    else if (i > 9 && i < 13)
                    {
                        title.Text = "Spider-Man: Into The Spider-Verse";
                        info.Text = "2018\n 117 min";
                        description.Text = "Teen Miles Morales becomes the Spider-Man of his universe, and must join with five spider-powered individuals from other dimensions to stop a threat for all realities.";
                    }
                    else if (i > 13 && i < 17)
                    {
                        title.Text = "Spider-Man: Homecoming";
                        info.Text = "2017\n 133 min";
                        description.Text = "Peter Parker balances his life as an ordinary high school student in Queens with his superhero alter-ego Spider-Man, and finds himself on the trail of a new menace prowling the skies of New York City.";
                    }
                    else if (i > 17 && i < 21)
                    {
                        title.Text = "The Amazing Spider-Man 2";
                        info.Text = "2014\n 144 min";
                        description.Text = "When New York is put under siege by Oscorp, it is up to Spider-Man to save the city he swore to protect as well as his loved ones.";
                    }
                    else if (i > 21 && i < 24)
                    {
                        title.Text = "The Amazing Spider-Man";
                        info.Text = "2012\n 136 min";
                        description.Text = "After Peter Parker is bitten by a genetically altered spider, he gains newfound, spider-like powers and ventures out to save the city from the machinations of a mysterious reptilian foe.";
                    }
                    else if (i > 24 && i < 27)
                    {
                        title.Text = "Spider-Man 3";
                        info.Text = "2007\n 139 min";
                        description.Text = "A strange black entity from another world bonds with Peter Parker and causes inner turmoil as he contends with new villains, temptations, and revenge.";
                    }
                    else if (i > 27 && i < 30)
                    {
                        title.Text = "Spider-Man 2";
                        info.Text = "2004\n 127 min";
                        description.Text = "Peter Parker is beset with troubles in his failing personal life as he battles a brilliant scientist named Doctor Otto Octavius.";
                    }
                    else if (i > 30 && i < 34)
                    {
                        title.Text = "Spider-Man";
                        info.Text = "2002\n 121 min";
                        description.Text = "When bitten by a genetically modified spider, a nerdy, shy, and awkward high school student gains spider-like abilities that he eventually must use to fight evil as a superhero after tragedy befalls his family.";
                    }

                    content.Children.Add(title);
                    content.Children.Add(info);
                    content.Children.Add(description);
                    content.Opacity = 0;

                    btn.Content = content;
                }
                else 
                {   //Spotify
                    StackPanel spotify_content = new StackPanel();
                    btn.Width = btn.Height * aspect;
                    bg.Width = btn.Height * aspect;
                    result.Width = btn.Height * aspect;
                    TextBox spotify_title = new TextBox();

                    spotify_title.FontSize = 10;
                    spotify_title.TextWrapping = TextWrapping.Wrap;
                    spotify_title.TextAlignment = TextAlignment.Center;
                    spotify_title.FontFamily = new FontFamily("Segoe UI");
                    spotify_title.Foreground = Brushes.White;
                    spotify_title.Background = new SolidColorBrush();
                    spotify_title.Background.Opacity = 0;
                    spotify_title.HorizontalAlignment = HorizontalAlignment.Center;
                    LinearGradientBrush spotify_gradient = new LinearGradientBrush();
                    spotify_gradient.EndPoint = new Point(0.5, 1);
                    spotify_gradient.StartPoint = new Point(0.5, 0);
                    spotify_gradient.GradientStops.Add(new GradientStop { Offset = 0 });
                    spotify_gradient.GradientStops.Add(new GradientStop { Offset = 1, Color = Colors.White });
                    spotify_title.BorderBrush = spotify_gradient;
                    spotify_title.IsHitTestVisible = false;
                    spotify_title.IsReadOnly = true;
                    spotify_title.Focusable = false;

                    TextBox spotify_artist = new TextBox();

                    spotify_artist.FontSize = 9;
                    spotify_artist.TextAlignment = TextAlignment.Center;
                    spotify_artist.Foreground = Brushes.White;
                    spotify_artist.FontFamily = new FontFamily("Segoe UI");
                    spotify_artist.Background = new SolidColorBrush();
                    spotify_artist.Background.Opacity = 0;
                    spotify_artist.BorderBrush = new SolidColorBrush { Opacity = 0 };
                    spotify_artist.HorizontalAlignment = HorizontalAlignment.Center;
                    spotify_artist.IsHitTestVisible = false;
                    spotify_artist.IsReadOnly = true;
                    spotify_artist.Focusable = false;

                    TextBox spotify_info = new TextBox();
                    spotify_info.TextWrapping = TextWrapping.Wrap;
                    spotify_info.Foreground = Brushes.White;
                    spotify_info.FontFamily = new FontFamily("Segoe UI");

                    spotify_info.FontSize = 9;
                    spotify_info.Background = new SolidColorBrush();
                    spotify_info.Background.Opacity = 0;
                    spotify_info.HorizontalAlignment = HorizontalAlignment.Center;
                    spotify_info.BorderBrush = new SolidColorBrush { Opacity = 0 };
                    spotify_info.IsReadOnly = true;
                    spotify_info.Focusable = false;

                    if (i == 6)
                    {
                        spotify_title.Text = "Inception (Music From ...";
                        spotify_artist.Text = "Hans Zimmer";
                        spotify_info.Text = "Album, 2010, 49 min";
                    }
                    else if (i == 9)
                    {
                        spotify_title.Text = "Spider-Man: Far From Home";
                        spotify_artist.Text = "Michael Giacchino";
                        spotify_info.Text = "Album, 2019, 79 min";
                    }
                    else if (i == 13) { 
                        spotify_title.Text = "Spider-Man: Into The Spider-Verse";
                        spotify_artist.Text = "Various Artists";
                        spotify_info.Text = "Album, 2018, 41 min";
                    }
                    else if (i == 17) {
                        spotify_title.Text = "Spider-Man: Homecoming";
                        spotify_artist.Text = "Michael Giacchino";
                        spotify_info.Text = "Album, 2017, 66 min";
                    }
                    else if (i == 21) {
                        spotify_title.Text = "The Amazing Spider-Man 2";
                        spotify_artist.Text = "Various Artists";
                        spotify_info.Text = "Album, 2014, 115 min";
                    }
                    else if (i == 24) {
                        spotify_title.Text = "The Amazing Spider-Man";
                        spotify_artist.Text = "James Horner";
                        spotify_info.Text = "Album, 2012, 77 min";
                    }
                    else if (i == 27)
                    {
                        spotify_title.Text = "Spider-Man 3";
                        spotify_artist.Text = "Various Artists";
                        spotify_info.Text = "Album, 2007, 52 min";
                    }
                    else if (i == 30)
                    {
                        spotify_title.Text = "Spider-Man 2";
                        spotify_artist.Text = "Danny Elfman";
                        spotify_info.Text = "Album, 2004, 48 min";
                    }
                    else if (i == 34)
                    {
                        spotify_title.Text = "Spider-Man";
                        spotify_artist.Text = "Various Artists";
                        spotify_info.Text = "Album, 2002, 65 min";
                    }

                    spotify_content.Children.Add(spotify_title);
                    spotify_content.Children.Add(new Separator { Opacity = 0, Height = 5 });
                    spotify_content.Children.Add(spotify_artist);
                    spotify_content.Children.Add(new Separator { Opacity = 0, Height = 5 });
                    spotify_content.Children.Add(spotify_info);
                    spotify_content.Opacity = 0;
                    btn.Content = spotify_content;
                }

                result.Children.Add(bg);
                result.Children.Add(btn);
                result.Children.Add(application);
                Results.Add(result);
            }

            //Inception Netflix result
            Results[0].Name = "inception";

            //Inception Prime Video result
            Results[1].Name = "inception";

            //Inception Apple TV result
            Results[2].Name = "inception";

            //Inception Disney+ result
            Results[3].Name = "inception";

            //Inception Live TV result
            Results[4].Name = "inception";

            //Inception Youtube result
            Results[5].Name = "inception";

            //Inception Soundtrack Spotify result
            Results[6].Name = "inception";

            //Spider-Man: Far From Home Prime Video result
            Results[7].Name = "spiderman_far_from_home";

            //Spider-Man: Far Frome Home Youtube result
            Results[8].Name = "spiderman_far_from_home";

            //Spider-Man: Far From Home Spotify result
            Results[9].Name = "spiderman_far_from_home";

            //Spider-Verse Netflix result
            Results[10].Name = "spiderman_into_the_spiderverse";

            //Spider-Verse Prime Video result
            Results[11].Name = "spiderman_into_the_spiderverse";

            //Spider-Verse Youtube result
            Results[12].Name = "spiderman_into_the_spiderverse";

            //Spider-Verse Spotify result
            Results[13].Name = "spiderman_into_the_spiderverse";

            //Spider-Man: Homecoming Netflix result
            Results[14].Name = "spiderman_homecoming";

            //Spider-Man: Homecoming Prime Video result
            Results[15].Name = "spiderman_homecoming";

            //Spider-Man: Homecoming Youtube result
            Results[16].Name = "spiderman_homecoming";

            //Spider-Man: Homecoming Spotify result
            Results[17].Name = "spiderman_homecoming";

            //The Amazing Spider-Man 2 Netflix result
            Results[18].Name = "the_amazing_spiderman_2";

            //The Amazing Spider-Man 2 Prime Video result
            Results[19].Name = "the_amazing_spiderman_2";

            //The Amazing Spider-Man 2 Youtube result
            Results[20].Name = "the_amazing_spiderman_2";

            //The Amazing Spider-Man 2 Spotify result
            Results[21].Name = "the_amazing_spiderman_2";

            //The Amazing Spider-Man Prime Video result
            Results[22].Name = "the_amazing_spiderman";
            
            //The Amazing Spider-Man Youtube result
            Results[23].Name = "the_amazing_spiderman";
            
            //The Amazing Spider-Man Spotify result
            Results[24].Name = "the_amazing_spiderman";

            Results[25].Name = "spiderman_3";
            Results[26].Name = "spiderman_3";
            Results[27].Name = "spiderman_3";
            Results[28].Name = "spiderman_2";
            Results[29].Name = "spiderman_2";
            Results[30].Name = "spiderman_2";
            Results[31].Name = "spiderman";
            Results[32].Name = "spiderman";
            Results[33].Name = "spiderman";
            Results[34].Name = "spiderman";


        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var tb = sender as TextBox;
            found = false;
            string parsed_search = RemoveSpecialCharacters(tb.Text.ToLower().Replace(" ", String.Empty));

            stack.Children.Clear();
            stack.Children.Add(new Label { Width = 20 });
            foreach (var res in Results)
            {
                if (RemoveSpecialCharacters(res.Name.ToLower()).Contains(parsed_search))
                {
                    found = true;
                    stack.Children.Add(res);
                    stack.Children.Add(new Label { Width = 20 });
                }
            }
            isResultsOnScreen = true;

            if (!found || (isResultsOnScreen && tb.Text.Equals("")))
            {
                stack.Children.Clear();
                isResultsOnScreen = false;
            }
        }

        private void result_selected(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button;
            btn.BorderBrush = Brushes.Red;
            ((StackPanel)btn.Content).Opacity = 1;
            ((ImageBrush)btn.Background).Opacity = 0.1;
            ((Grid)btn.Parent).Width += 20;
            ((Grid)btn.Parent).Height += 20;
            //if (btn.TranslatePoint(new Point(), this).X > this.Width)
            scroll.ScrollToHorizontalOffset(btn.TranslatePoint(new Point(), stack).X - offset);
            //if (btn == (Button)(Results[0].Children[1]))
            //{
            //    scroll.ScrollToHorizontalOffset(0);
            //}
            //else if (btn == ((Grid)stack.Children[stack.Children.Count-1]).Children[0])
            //{
            //    scroll.ScrollToHorizontalOffset(100);
            //}
        }

        private void result_nselected(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button;
            btn.BorderBrush = Brushes.Black;
            ((Grid)btn.Parent).Width -= 20;
            ((Grid)btn.Parent).Height -= 20;
            ((StackPanel)btn.Content).Opacity = 0;
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
                if (stack.Children.Count > 0)
                {
                    ((Button)((Grid)stack.Children[1]).Children[1]).Focus();
                }
                else
                    dummy.Focus();
            }
        }

        private static string RemoveSpecialCharacters(string str)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char c in str)
            {
                if ((c >= '0' && c <= '9') || (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z'))
                {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }
    }
}
