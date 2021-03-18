using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Silver_HTPC
{
    /// <summary>
    /// Interaction logic for test.xaml
    /// </summary>
    public partial class test : Window
    {
        public test()
        {
            InitializeComponent();
            DispatcherTimer timer = new DispatcherTimer(new TimeSpan(0, 0, 1), DispatcherPriority.Normal, delegate
            {
                this.time_label.Content = DateTime.Now.ToString("hh:mm tt");
                this.date_label.Content = DateTime.Now.ToString("MMMM dd, yyyy");
            }, this.Dispatcher);
        }

        private void munu_button8_Click(object sender, RoutedEventArgs e)
        {
            Notification_tab notification_window = new Notification_tab();
            notification_window.Show();
            this.Close();

        }
    }
}
