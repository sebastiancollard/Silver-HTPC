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
    /// Interaction logic for LiveTV.xaml
    /// </summary>
    public partial class LiveTV : Window
    {

        bool hidden;
        StackPanel sidemenu;

        public LiveTV(int x)
        {
            InitializeComponent();
            Image nowPlaying = image1;
            BitmapImage bi = new BitmapImage();
            bi.BeginInit();
            if(x==1) bi.UriSource = new Uri("image/sherlock_live.png", UriKind.Relative);
            else bi.UriSource = new Uri("image/topgear_live.png", UriKind.Relative);
            bi.EndInit();
            nowPlaying.Source = bi;
            sidemenu = stackpanel;

        }


        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter && !hidden)
            {
                sidemenu.Margin = new Thickness(-400, 0, 400, 0);
                hidden = true;
         
            }
            else if(e.Key == Key.Enter && hidden)
            {
                sidemenu.Margin = new Thickness(0, 0, 0, 0);
                hidden = false;
            }
        }
    }
}
