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
using System.Windows.Media.Animation;


namespace Silver_HTPC
{
    /// <summary>
    /// Interaction logic for LiveTV.xaml
    /// </summary>
    public partial class LiveTV : Window
    {

        bool hidden = true;
        Grid sidemenu;
        Grid record;
        //Storyboard slideRight;
        //Storyboard slideLeft;
        //Rectangle r;
        

        public LiveTV(int x)
        {
            InitializeComponent();
            this.DataContext = this;
            Image nowPlaying = image1;
            BitmapImage bi = new BitmapImage();
            bi.BeginInit();
            if(x==1) bi.UriSource = new Uri("image/sherlock_live.png", UriKind.Relative);
            else bi.UriSource = new Uri("image/topgear_live.png", UriKind.Relative);
            bi.EndInit();
            nowPlaying.Source = bi;
            sidemenu = panel;
            record = record_button;
            //slideRight = (Storyboard)TryFindResource("SlideRight");
            //slideLeft = (Storyboard)TryFindResource("SlideLeft");



            //r = rect;













        }


        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter && !hidden)
            {
                //sidemenu.Margin = new Thickness(-400, 0, 400, 0);
                hidden = true;

                Storyboard sb = sidemenu.FindResource("SlideLeft") as Storyboard;
                if (sb != null) { BeginStoryboard(sb); }

            }
            else if(e.Key == Key.Enter && hidden)
            {

                //sidemenu.Margin = new Thickness(0, 0, 0, 0);
                hidden = false;
                Storyboard sb = sidemenu.FindResource("SlideRight") as Storyboard;
                if (sb != null) { BeginStoryboard(sb); }
            }
            else if (e.Key == Key.Right)
            {

                
            }
            else if (e.Key == Key.Left)
            {
             
            }
            else if(e.Key == Key.Back)
            {
                TV_Guide tvguide = new TV_Guide();
                tvguide.Show();
                this.Close();
            }
        }


    




    }


}
