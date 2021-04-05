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

        bool hidden = true;
        Grid sidemenu;
        Grid record;
        Grid reminder;


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
            reminder = reminder_button;


            RecordBorder = 100;
            
            





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
            else if (e.Key == Key.Right)
            {
                
                RecordBorder = 0;
                ReminderBorder = 100;
            
                
            }
            else if (e.Key == Key.Left)
            {
                RecordBorder = 100;
                ReminderBorder = 0;
             
            }
        }



        public static readonly DependencyProperty RecordBorderProperty = DependencyProperty.Register("RecordBorder", typeof(int), typeof(LiveTV));
        public static readonly DependencyProperty ReminderBorderProperty = DependencyProperty.Register("ReminderBorder", typeof(int), typeof(LiveTV));
       



        public int RecordBorder
            {
                get { return (int)GetValue(RecordBorderProperty); }
                set { SetValue(RecordBorderProperty, value); }
            }

        public int ReminderBorder
            {
                get { return (int)GetValue(ReminderBorderProperty); }
                set { SetValue(ReminderBorderProperty, value); }
            }

    




    }


}
