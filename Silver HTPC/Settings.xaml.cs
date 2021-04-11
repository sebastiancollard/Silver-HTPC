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

            // Set default text for ComboBox
            _combobox_Language.Text = "English";

            // Sets keyboard focus on the first Button in the sample.
            Keyboard.Focus(_slider_TextSize);
        }

        // When someone moves the slider, text (theoretically) changes everywhere
        private void TextSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            //TODO
            // Alter the App.xaml to make text bigger?
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
            else if (e.Key == Key.S) // "remote" clicks s = search
            {
                Search search = new Search();
                search.Show();
                this.Close();
            }
            else if (e.Key == Key.Down)
            {
                //Focus shifts to the next one down
                // Let's make different functions for each?
            }
        }

        private void TextBoxGotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            TextBox source = e.Source as TextBox;

            if (source != null)
            {
                // Change the TextBox color when it obtains focus.
                source.Background = Brushes.LightBlue;

                // Clear the TextBox.
                source.Clear();
            }
        }


    }
}
