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
    /// Interaction logic for Settings2.xaml
    /// </summary>
    public partial class Settings2 : Window
    {

        public Settings2()
        {
            InitializeComponent();

            // Set default text for ComboBox
            _combobox_Language.Text = "English";

            // Sets focus on the first item
            _slider_TextSize.Focus();
        }

        // When someone moves the slider, text (theoretically) changes everywhere
        private void TextSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            //Not actually functional, but looks good
            _textsizeText.FontSize = 20 + (_slider_TextSize.Value - 5);
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
                MainWindow2 mainWindow2 = new MainWindow2();
                mainWindow2.Show();
                this.Close();
            }
            else if (e.Key == Key.S) // "remote" clicks s = search
            {
                Search search = new Search();
                search.Show();
                this.Close();
            }
            else if (e.Key == Key.H) // go home
            {
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            }
            // The "janky, but it works" method of keyboard navigation.
            else if (e.Key == Key.Down)
            {
                if (_slider_TextSize.IsFocused) {
                    _combobox_Language.Focus();
                } else if (_combobox_Language.IsFocused) {
                    _togbut_ButtonGuide.Focus();
                } else if (_togbut_ButtonGuide.IsFocused) {
                    _button_AdvanceSettings.Focus();
                } else if (_button_AdvanceSettings.IsFocused) {
                    _slider_TextSize.Focus();
                }
            }
            else if (e.Key == Key.Up)
            {
                if (_slider_TextSize.IsFocused) {
                    _button_AdvanceSettings.Focus();
                } else if (_combobox_Language.IsFocused) {
                    _slider_TextSize.Focus();
                } else if (_togbut_ButtonGuide.IsFocused) {
                    _combobox_Language.Focus();
                } else if (_button_AdvanceSettings.IsFocused) {
                    _togbut_ButtonGuide.Focus();
                }
            }
            else if (e.Key == Key.O)
            {
                if (_slider_TextSize.IsFocused) {
                    _combobox_Language.Focus();
                } else if (_combobox_Language.IsFocused) {
                    _slider_TextSize.Focus();
                } else if (_togbut_ButtonGuide.IsFocused) {
                    // Trigger _togbut_ButtonGuide.IsChecked;
                } else if (_button_AdvanceSettings.IsFocused) {
                    AdSet_button_Click(sender, e);
                }
            }
            else if (e.Key == Key.Z) // Make button guide window pop up
            {
                if (_togbut_ButtonGuide.IsFocused)
                {
                    Settings settings = new Settings();
                    settings.Show();
                    this.Close();
                }
            }
        }

        // Raised when Button gains focus.
        // Changes the color of the Button to the one defined in app.xaml.
        private void OnButtonGotFocusHandler(object sender, RoutedEventArgs e)
        {
            Button button = e.Source as Button;
            button.Style = (Style)FindResource("HoverButton");
            button.Background = (Brush)Application.Current.FindResource("ButtonHoverBackground");
        }

        // Raised when Button loses focus.
        // Changes the color of the Button back to normal.
        private void OnButtonLostFocusHandler(object sender, RoutedEventArgs e)
        {
            Button button = e.Source as Button;
            button.Style = (Style)FindResource("StandardButton");
            button.Background = (Brush)Application.Current.FindResource("ButtonNormalBackground");
        }

        
    }
}
