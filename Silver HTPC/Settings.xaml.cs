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

        private static int CurrentSelection=0; // Default cursor to slider
        public Settings()
        {
            InitializeComponent();
            _combobox_Language.Text = "English"; // Set default text

            //SetButtonFocus(CurrentSelection); // Make cursor visible
        }

        // When someone moves the slider, text (theoretically) changes everywhere
        private void TextSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            // (From the example on https://www.wpf-tutorial.com/misc-controls/the-slider-control/)
            //Color color = Color.FromRgb((byte)slColorR.Value, (byte)slColorG.Value, (byte)slColorB.Value);
            //this.Background = new SolidColorBrush(color);
        }

        // Get the bottom button to take you to the next screen
        private void AdSet_button_Click(object sender, RoutedEventArgs e)
        {
            AdvancedSettings ASett_window = new AdvancedSettings();
            ASett_window.Show();
            this.Close();
        }

        // Keyboard manouvering!
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Back)
            {
                // Backspace = go back to previous screen (Main menu?)
                // TODO: hard code this for the demo to fake "saved state"
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            }
            if (e.Key == Key.Down)
            {
                //Focus shifts to the next one down
                CurrentSelection += 1;
            }
        }
        
    }
}
