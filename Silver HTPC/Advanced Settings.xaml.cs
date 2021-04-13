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
    /// Interaction logic for Advanced Settings.xaml
    /// </summary>
    public partial class AdvancedSettings : Window
    {
        public AdvancedSettings()
        {
            InitializeComponent();
            
            // Set default text for ComboBox
            _combobox_ColourBlind.Text = "Full spectrum"; //Not working, no idea why :(

            // Sets focus on the first item
            _tb_Magnifier.Focus();
        }

        /** Go back to Settings on backspace **/
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Back)
            {
                // Backspace = go back to previous screen (Settings)
                Settings settings = new Settings();
                settings.Show();
                this.Close();
            }
            else if (e.Key == Key.OemQuestion)
            {
                Settings settings = new Settings();
                settings.Show();
                this.Close();
            }
            else if (e.Key == Key.S) // "remote" clicks s = search
            {
                Search search = new Search();
                search.Show();
                this.Close();
            }
            // The "janky, but it works" method of keyboard navigation continues
            else if (e.Key == Key.Down)
            {
                if (_tb_Magnifier.IsFocused) {
                    _combobox_ColourBlind.Focus();
                } else if (_combobox_ColourBlind.IsFocused) {
                    _tb_Notifications.Focus();
                } else if (_tb_Notifications.IsFocused) {
                   _tb_Magnifier.Focus();
                }
            }
            else if (e.Key == Key.Up)
            {
                if (_tb_Magnifier.IsFocused) {
                    _tb_Notifications.Focus();
                } else if (_combobox_ColourBlind.IsFocused) {
                    _tb_Magnifier.Focus();
                } else if (_tb_Notifications.IsFocused) {
                    _combobox_ColourBlind.Focus();
                }
            }
            else if (e.Key == Key.O)
            {
                if (_tb_Magnifier.IsFocused)
                {
                    // Trigger _tb_Magnifier.IsChecked;
                }
                else if (_combobox_ColourBlind.IsFocused)
                {
                    _tb_Notifications.Focus();
                }
            }
        }
    }
}
