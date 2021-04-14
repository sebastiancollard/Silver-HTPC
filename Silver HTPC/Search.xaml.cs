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
using System.Windows.Media.Effects;
using System.Windows.Threading;

namespace Silver_HTPC
{
    /// <summary>
    /// Interaction logic for Search.xaml
    /// </summary>
    public partial class Search : Window
    {
        List<Grid> Results = new List<Grid>();
        const int WIDTH = 100;
        const int HEIGHT = 200;
        static bool isResultsOnScreen = false;
        private static string text = "";
        static bool found = false;
        static bool update = true;
        const int offset = 340;
        bool o = true;
        private DispatcherTimer dispatcherTimerTime;

        public Search()
        {
            InitializeComponent();

            MakeResults();

            ((Grid)keypad.Children[1]).Children[0].Focus();
            counter.Visibility = Visibility.Hidden;
            scroll.Width -= 270;
            scroll.Margin = new Thickness(270, 0, 0, 0);
            searchBox.Text = text;

            foreach (ComboBoxItem i in filter.Items) i.KeyDown += comboboxItem_KeyDown;

        }
        private void MakeResults()
        {
            dispatcherTimerTime = new DispatcherTimer();
            dispatcherTimerTime.Interval = new TimeSpan(0, 0, 5);
            DispatcherTimer timer = new DispatcherTimer(new TimeSpan(0, 0, 1), DispatcherPriority.Normal, delegate
            {
                this.guide_time.Content = DateTime.Now.ToString("hh:mm tt");
                this.guide_date.Content = DateTime.Now.ToString("MMMM dd, yyyy");
            }, this.Dispatcher);

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
                    brush.ImageSource = new BitmapImage(new Uri(@"pack://application:,,,/Image/inception poster.jpg", UriKind.RelativeOrAbsolute));
                else if (i == 6)
                    brush.ImageSource = new BitmapImage(new Uri(@"pack://application:,,,/Image/inception_OST.jpg", UriKind.RelativeOrAbsolute));
                else if (i > 6 && i < 9)
                    brush.ImageSource = new BitmapImage(new Uri(@"pack://application:,,,/Image/spidermanfarfromhome.jpeg", UriKind.RelativeOrAbsolute));
                else if (i == 9)
                    brush.ImageSource = new BitmapImage(new Uri(@"pack://application:,,,/Image/spidermanfarfromhome_OST.jpg", UriKind.RelativeOrAbsolute));
                else if (i > 9 && i < 13)
                    brush.ImageSource = new BitmapImage(new Uri(@"pack://application:,,,/Image/spiderverse_1.jpg", UriKind.RelativeOrAbsolute));
                else if (i == 13)
                    brush.ImageSource = new BitmapImage(new Uri(@"pack://application:,,,/Image/spiderverse_OST.jpg", UriKind.RelativeOrAbsolute));
                else if (i > 13 && i < 17)
                    brush.ImageSource = new BitmapImage(new Uri(@"pack://application:,,,/Image/spidermanhomecoming.jpg", UriKind.RelativeOrAbsolute));
                else if (i == 17)
                    brush.ImageSource = new BitmapImage(new Uri(@"pack://application:,,,/Image/spidermanhomecoming_OST.jpg", UriKind.RelativeOrAbsolute));
                else if (i > 17 && i < 21)
                    brush.ImageSource = new BitmapImage(new Uri(@"pack://application:,,,/Image/theamazingspiderman2.jpg", UriKind.RelativeOrAbsolute));
                else if (i == 21)
                    brush.ImageSource = new BitmapImage(new Uri(@"pack://application:,,,/Image/theamazingspiderman2_OST.jpg", UriKind.RelativeOrAbsolute));
                else if (i > 21 && i < 24)
                    brush.ImageSource = new BitmapImage(new Uri(@"pack://application:,,,/Image/theamazingspiderman.jpg", UriKind.RelativeOrAbsolute));
                else if (i == 24)
                    brush.ImageSource = new BitmapImage(new Uri(@"pack://application:,,,/Image/theamazingspiderman_OST.jpg", UriKind.RelativeOrAbsolute));
                else if (i > 24 && i < 27)
                    brush.ImageSource = new BitmapImage(new Uri(@"pack://application:,,,/Image/spiderman3.jpg", UriKind.RelativeOrAbsolute));
                else if (i == 27)
                    brush.ImageSource = new BitmapImage(new Uri(@"pack://application:,,,/Image/spiderman3_OST.jpg", UriKind.RelativeOrAbsolute));
                else if (i > 27 && i < 30)
                    brush.ImageSource = new BitmapImage(new Uri(@"pack://application:,,,/Image/spiderman2.jpg", UriKind.RelativeOrAbsolute));
                else if (i == 30)
                    brush.ImageSource = new BitmapImage(new Uri(@"pack://application:,,,/Image/spiderman2_OST.jpg", UriKind.RelativeOrAbsolute));
                else if (i > 30 && i < 34)
                    brush.ImageSource = new BitmapImage(new Uri(@"pack://application:,,,/Image/spiderman.jpg", UriKind.RelativeOrAbsolute));
                else if (i == 34)
                    brush.ImageSource = new BitmapImage(new Uri(@"pack://application:,,,/Image/spiderman_OST.jpg", UriKind.RelativeOrAbsolute));

                btn.Content = new StackPanel();
                btn.KeyDown += Button_KeyDown;
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

                if (i == 0 || i == 7 || i == 10 || i == 14 || i == 18 || i == 31)
                {//Netflix
                    application.Source = new BitmapImage(new Uri(@"pack://application:,,,/Image/netflix_PNG15.png", UriKind.RelativeOrAbsolute));
                    application.Name = "netflix";
                }
                else if (i == 1 || i == 8 || i == 11 || i == 15 || i == 19 || i == 22 || i == 25 || i == 28 || i == 32)
                {//Prime Video
                    application.Source = new BitmapImage(new Uri(@"pack://application:,,,/Image/prime video.png", UriKind.RelativeOrAbsolute));
                    application.Name = "primevideo";
                }
                else if (i == 2)
                {   //Apple TV
                    application.Source = new BitmapImage(new Uri(@"pack://application:,,,/Image/apple tv.png", UriKind.RelativeOrAbsolute));
                    application.Width = 75;
                    application.Height = 75;
                    application.Name = "appletv";
                }
                else if (i == 3)
                {   //Disney+
                    application.Source = new BitmapImage(new Uri(@"pack://application:,,,/Image/Disney+.png", UriKind.RelativeOrAbsolute));
                    application.Width = 100;
                    application.Height = 100;
                    application.Margin = new Thickness(0, 195, 0, 0);
                    application.Name = "disneyplus";
                }
                else if (i == 4)
                {   //Live TV
                    application.Source = new BitmapImage(new Uri(@"pack://application:,,,/Image/live tv.png", UriKind.RelativeOrAbsolute));
                    application.Width = 75;
                    application.Height = 75;
                    application.Margin = new Thickness(0, 195, 0, 0);
                    application.Name = "livetv";
                }
                else if (i == 5 || i == 8 || i == 12 || i == 16 || i == 20 || i == 23 || i == 26 || i == 29 || i == 33)
                {   //Youtube
                    application.Source = new BitmapImage(new Uri(@"pack://application:,,,/Image/youtube.png", UriKind.RelativeOrAbsolute));
                    application.Width = 100;
                    application.Height = 100;
                    application.Margin = new Thickness(0, 195, 0, 0);
                    application.Name = "youtube";
                }
                else if (i == 6 || i == 9 || i == 13 || i == 17 || i == 21 || i == 24 || i == 27 || i == 30 || i == 34)
                {   //Spotify
                    bg.Height = 100;
                    bg.Margin = new Thickness(0, 50, 0, 0);
                    btn.Height = 100;
                    btn.Margin = new Thickness(0, 50, 0, 0);
                    application.Source = new BitmapImage(new Uri(@"pack://application:,,,/Image/spotify-download-logo.png", UriKind.RelativeOrAbsolute));
                    application.Name = "spotify";
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
            ((Button)(Results[0].Children[1])).Name = "movie";

            //Inception Prime Video result
            Results[1].Name = "inception";
            ((Button)(Results[1].Children[1])).Name = "movie";

            //Inception Apple TV result
            Results[2].Name = "inception";
            ((Button)(Results[2].Children[1])).Name = "movie";

            //Inception Disney+ result
            Results[3].Name = "inception";
            ((Button)(Results[3].Children[1])).Name = "movie";

            //Inception Live TV result
            Results[4].Name = "inception";
            ((Button)(Results[4].Children[1])).Name = "livetv";

            //Inception Youtube result
            Results[5].Name = "inception";
            ((Button)(Results[5].Children[1])).Name = "movie";

            //Inception Soundtrack Spotify result
            Results[6].Name = "inception";
            ((Button)(Results[6].Children[1])).Name = "music";

            //Spider-Man: Far From Home Prime Video result
            Results[7].Name = "spiderman_far_from_home";
            ((Button)(Results[7].Children[1])).Name = "movie";

            //Spider-Man: Far Frome Home Youtube result
            Results[8].Name = "spiderman_far_from_home";
            ((Button)(Results[8].Children[1])).Name = "movie";

            //Spider-Man: Far From Home Spotify result
            Results[9].Name = "spiderman_far_from_home";
            ((Button)(Results[6].Children[1])).Name = "music";

            //Spider-Verse Netflix result
            Results[10].Name = "spiderman_into_the_spiderverse";
            ((Button)(Results[10].Children[1])).Name = "movie";

            //Spider-Verse Prime Video result
            Results[11].Name = "spiderman_into_the_spiderverse";
            ((Button)(Results[11].Children[1])).Name = "movie";

            //Spider-Verse Youtube result
            Results[12].Name = "spiderman_into_the_spiderverse";
            ((Button)(Results[12].Children[1])).Name = "movie";

            //Spider-Verse Spotify result
            Results[13].Name = "spiderman_into_the_spiderverse";
            ((Button)(Results[13].Children[1])).Name = "music";

            //Spider-Man: Homecoming Netflix result
            Results[14].Name = "spiderman_homecoming";
            ((Button)(Results[14].Children[1])).Name = "movie";

            //Spider-Man: Homecoming Prime Video result
            Results[15].Name = "spiderman_homecoming";
            ((Button)(Results[15].Children[1])).Name = "movie";

            //Spider-Man: Homecoming Youtube result
            Results[16].Name = "spiderman_homecoming";
            ((Button)(Results[16].Children[1])).Name = "movie";

            //Spider-Man: Homecoming Spotify result
            Results[17].Name = "spiderman_homecoming";
            ((Button)(Results[17].Children[1])).Name = "music";

            //The Amazing Spider-Man 2 Netflix result
            Results[18].Name = "the_amazing_spiderman_2";
            ((Button)(Results[18].Children[1])).Name = "movie";

            //The Amazing Spider-Man 2 Prime Video result
            Results[19].Name = "the_amazing_spiderman_2";
            ((Button)(Results[19].Children[1])).Name = "movie";

            //The Amazing Spider-Man 2 Youtube result
            Results[20].Name = "the_amazing_spiderman_2";
            ((Button)(Results[20].Children[1])).Name = "movie";

            //The Amazing Spider-Man 2 Spotify result
            Results[21].Name = "the_amazing_spiderman_2";
            ((Button)(Results[21].Children[1])).Name = "music";

            //The Amazing Spider-Man Prime Video result
            Results[22].Name = "the_amazing_spiderman";
            ((Button)(Results[22].Children[1])).Name = "movie";

            //The Amazing Spider-Man Youtube result
            Results[23].Name = "the_amazing_spiderman";
            ((Button)(Results[23].Children[1])).Name = "movie";

            //The Amazing Spider-Man Spotify result
            Results[24].Name = "the_amazing_spiderman";
            ((Button)(Results[24].Children[1])).Name = "music";

            Results[25].Name = "spiderman_3";
            ((Button)(Results[25].Children[1])).Name = "movie";
            Results[26].Name = "spiderman_3";
            ((Button)(Results[26].Children[1])).Name = "movie";
            Results[27].Name = "spiderman_3";
            ((Button)(Results[27].Children[1])).Name = "music";

            Results[28].Name = "spiderman_2";
            ((Button)(Results[28].Children[1])).Name = "movie";
            Results[29].Name = "spiderman_2";
            ((Button)(Results[29].Children[1])).Name = "movie";
            Results[30].Name = "spiderman_2";
            ((Button)(Results[30].Children[1])).Name = "music";

            Results[31].Name = "spiderman";
            ((Button)(Results[31].Children[1])).Name = "movie";
            Results[32].Name = "spiderman";
            ((Button)(Results[32].Children[1])).Name = "movie";
            Results[33].Name = "spiderman";
            ((Button)(Results[33].Children[1])).Name = "movie";
            Results[34].Name = "spiderman";
            ((Button)(Results[34].Children[1])).Name = "music";


        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var tb = sender as TextBox;
            found = false;
            string parsed_search = RemoveSpecialCharacters(tb.Text.ToLower().Replace(" ", String.Empty));

            stack.Children.Clear();
            stack.Children.Add(new Label { Width = 20 });
            string filterVal = RemoveSpecialCharacters(((ComboBoxItem)filter.SelectedItem).Content.ToString().ToLower());

            if (filterVal.Equals("all"))
            {
                foreach (Grid res in Results)
                {
                    if (RemoveSpecialCharacters(res.Name.ToLower()).Contains(RemoveSpecialCharacters(searchBox.Text)) && !RemoveSpecialCharacters(searchBox.Text).Equals(""))
                    {
                        found = true;
                        stack.Children.Add(res);
                        stack.Children.Add(new Label { Width = 20 });
                    }
                }
            }
            else
            {
                foreach (Grid res in Results)
                {
                    if (filterVal.Contains(((Button)res.Children[1]).Name) && RemoveSpecialCharacters(res.Name.ToLower()).Contains(RemoveSpecialCharacters(searchBox.Text)) && !RemoveSpecialCharacters(searchBox.Text).Equals(""))
                    {
                        found = true;
                        stack.Children.Add(res);
                        stack.Children.Add(new Label { Width = 20 });
                    }
                }
            }

            isResultsOnScreen = true;

            if (!found || (isResultsOnScreen && tb.Text.Equals("")))
            {
                stack.Children.Clear();
                isResultsOnScreen = false;
            }

            counter.Text = (stack.Children.Count / 2).ToString() + " results";
        }

        private void result_selected(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button;
            btn.BorderBrush = Brushes.Red;
            ((StackPanel)btn.Content).Opacity = 1;
            ((ImageBrush)btn.Background).Opacity = 0.1;
            ((Grid)btn.Parent).Width += 20;
            ((Grid)btn.Parent).Height += 20;
            scroll.ScrollToHorizontalOffset(btn.TranslatePoint(new Point(), stack).X - offset);

            //double d = scroll.HorizontalOffset;
            //double d1 = btn.TranslatePoint(new Point(), stack).X - offset;

            counter.Text = (stack.Children.IndexOf((Grid)btn.Parent)/2+1).ToString() + " of " + stack.Children.Count / 2;

            /**if (keypad.Visibility != Visibility.Hidden)
            {
                filter.Visibility = Visibility.Visible;
                keypad.Visibility = Visibility.Hidden;
                scroll.Width += 270;
                scroll.Margin = new Thickness();
            }*/
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
                text = "";
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            }
            else if (e.Key == Key.H)
            {
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            }
            if (e.Key == Key.OemQuestion)
            {
                Settings settingsWindow = new Settings();
                settingsWindow.Show();
                this.Close();
            }
            else if (e.Key == Key.S)
            {

                if (keypad.Visibility == Visibility.Hidden)
                {
                    counter.Visibility = Visibility.Hidden;
                    keypad.Visibility = Visibility.Visible;
                    scroll.Width -= 270;
                    scroll.Margin = new Thickness(270, 0, 0, 0);
                    update = false;
                    ((Grid)keypad.Children[1]).Children[0].Focus();
                }
                else if (keypad.Visibility == Visibility.Visible && update)
                {
                    counter.Visibility = Visibility.Visible;
                    keypad.Visibility = Visibility.Hidden;
                    scroll.Width += 270;
                    scroll.Margin = new Thickness();
                    if (stack.Children.Count > 0)
                        ((Grid)stack.Children[1]).Children[1].Focus();
                }
                else update = true;
            }
            else if (e.Key == Key.OemQuestion)
            {
                Settings settings = new Settings();
                settings.Show();
                this.Close();
            }
            else if (e.Key == Key.G)
            {
                TV_Guide guide = new TV_Guide();
                guide.Show();
                this.Close();
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

        private void filter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var combobox = sender as ComboBox;
            found = false;
            var filterVal = RemoveSpecialCharacters(((ComboBoxItem)combobox.SelectedItem).Content.ToString().ToLower());

            stack.Children.Clear();
            stack.Children.Add(new Label { Width = 20 });

            if (filterVal.Equals("all"))
            {
                foreach (Grid res in Results)
                {
                    if (searchBox != null && RemoveSpecialCharacters(res.Name.ToLower()).Contains(RemoveSpecialCharacters(searchBox.Text)))
                    {
                        found = true;
                        stack.Children.Add(res);
                        stack.Children.Add(new Label { Width = 20 });
                    }
                }
            }
            else
            {
                foreach (Grid res in Results)
                {
                    if (filterVal.Contains(((Button)res.Children[1]).Name) && RemoveSpecialCharacters(res.Name.ToLower()).Contains(RemoveSpecialCharacters(searchBox.Text)))
                    {
                        found = true;
                        stack.Children.Add(res);
                        stack.Children.Add(new Label { Width = 20 });
                    }
                }
            }

            if (stack.Children.Count > 1)
                ((Grid)stack.Children[1]).Children[1].Focus();

            isResultsOnScreen = true;

            if (!found)
            {
                stack.Children.Clear();
                isResultsOnScreen = false;
            }
        }

        private void KeyPad_KeyDown(object sender, KeyEventArgs e)
        {
            var btn = sender as Button;
            
            if (e.Key == Key.O && btn != null)
            {
                btn.Style = (Style)FindResource("SelectButton");
                //btn.Background = (LinearGradientBrush)FindResource("ButtonSelectedBackground");
                //btn.Foreground = Brushes.White;
                text += btn.Content;
                searchBox.Text += btn.Content;
            }
            else if (e.Key == Key.Right &&
                (btn == ((Grid)keypad.Children[1]).Children[5] ||
                btn == ((Grid)keypad.Children[1]).Children[11] ||
                btn == ((Grid)keypad.Children[1]).Children[17] ||
                btn == ((Grid)keypad.Children[1]).Children[23]) && stack.Children.Count > 0)
            {
                counter.Visibility = Visibility.Visible;
                keypad.Visibility = Visibility.Hidden;
                scroll.Width += 270;
                scroll.Margin = new Thickness();
            }
        }

        private void KeyPad_KeyDown2(object sender, KeyEventArgs e)
        {
            var btn = sender as Button;
            if (e.Key == Key.O && btn != null)
            {
                btn.Style = (Style)FindResource("SelectButton");
                //btn.Background = (LinearGradientBrush)FindResource("ButtonSelectedBackground");
                //btn.Foreground = Brushes.White;

                if (btn.Content.Equals("Clear"))
                {
                    searchBox.Text = "";
                    text = "";
                }
                else if (btn.Content.Equals("Space"))
                {
                    searchBox.Text += " ";
                    text += " ";
                }
                else if (btn.Content.Equals("Backspace"))
                {
                    if (searchBox.Text.Length > 0)
                    {
                        searchBox.Text = searchBox.Text.Substring(0, searchBox.Text.Length - 1);
                        text = text.Substring(0, text.Length - 1);
                    }
                }
            } 
            else if (e.Key == Key.Right && btn == ((Grid)keypad.Children[0]).Children[2])
            {
                counter.Visibility = Visibility.Visible;
                keypad.Visibility = Visibility.Hidden;
                scroll.Width += 270;
                scroll.Margin = new Thickness();
            }
            
        }

        private void filter_KeyDown(object sender, KeyEventArgs e)
        {

            var combobox = sender as ComboBox;
            if (e.Key == Key.O && !filter.IsDropDownOpen && o)
            {
                filter.IsDropDownOpen = true;
            }
            else if (e.Key == Key.Down && stack.Children.Count > 1)
                ((Grid)stack.Children[1]).Children[1].Focus();
            o = true;

        }

        private void comboboxItem_KeyDown(object sender, KeyEventArgs e)
        {

            var comboboxItem = sender as ComboBoxItem;

            if (e.Key == Key.O)
            {
                filter.SelectedItem = comboboxItem;
                filter.IsDropDownOpen = false;
                o = false;
                if (stack.Children.Count > 1)
                    ((Grid)stack.Children[1]).Children[1].Focus();
                else
                {
                    filter.Focus();
                }
            }
        }

        private void Button_KeyDown(object sender, KeyEventArgs e)
        {
            var btn = sender as Button;
            if (e.Key == Key.Up)
            {
                filter.Focus();
                //filter.IsDropDownOpen = true;
            }
            else if (e.Key == Key.O && Results[Results.IndexOf((Grid)btn.Parent)].Name.Equals("spiderman_into_the_spiderverse") && ((Image)((Grid)Results[Results.IndexOf((Grid)btn.Parent)]).Children[2]).Name.Equals("primevideo"))
            {
                PrimeResult p = new PrimeResult();
                p.Show();
                this.Close();
            }
        }

        private void keyPad_GotFocus(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button;
            btn.Style = (Style)FindResource("HoverButton");
            //btn.Background = (LinearGradientBrush)FindResource("ButtonHoverBackground");
        }

        private void keyPad_LostFocus(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button;
            btn.Style = (Style)FindResource("StandardButton");
            //btn.Background = (LinearGradientBrush)FindResource("ButtonNormalBackground");
        }

        private void KeyPad_KeyUp(object sender, KeyEventArgs e)
        {
            var btn = sender as Button;

            btn.Style = (Style)FindResource("HoverButton");
            //btn.Background = (LinearGradientBrush)FindResource("ButtonHoverBackground");
            //btn.Foreground = Brushes.Black;
        }
    }
}
