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
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class Settings : Window
    {
        public Settings()
        {
            InitializeComponent();
        }

        // Trying to get the button to take you to the next screen
        // No idea if I'm even close to the right track here
        private void AdSet_button_Click(object sender, RoutedEventArgs e)
        {
            AdvancedSettings ASett_window = new AdvancedSettings();
            ASett_window.Show();
            this.Close();

        }
    }
}
