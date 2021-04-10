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
        }

        // Keyboard manouvering!
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                /**
                case Key.Right:
                    if (currentButtonSelectionIndex != 2 && currentButtonSelectionIndex != 5 && currentButtonSelectionIndex != 8 && currentButtonSelectionIndex != 9)
                    {
                        resetButtonFocus(currentButtonSelectionIndex);
                        currentButtonSelectionIndex = (currentButtonSelectionIndex + 1) % 9;
                        setButtonFocus(currentButtonSelectionIndex);
                    }

                    break;
                case Key.Left:
                    if (currentButtonSelectionIndex != 0 && currentButtonSelectionIndex != 3 && currentButtonSelectionIndex != 6 && currentButtonSelectionIndex != 9)
                    {
                        resetButtonFocus(currentButtonSelectionIndex);
                        currentButtonSelectionIndex = (currentButtonSelectionIndex - 1) % 9;
                        setButtonFocus(currentButtonSelectionIndex);
                    }

                    break;
                
                case Key.Down:
                    if (CurrentSelection == 3)
                    {
                        ResetButtonFocus(CurrentSelection);
                        CurrentSelection = 0;
                        SetButtonFocus(CurrentSelection);
                    }
                    else if (CurrentSelection < 3)
                    {
                        ResetButtonFocus(CurrentSelection);
                        CurrentSelection += 1;
                        SetButtonFocus(CurrentSelection);
                    }

                    break;
                /**
                case Key.Up:
                    if (currentButtonSelectionIndex >= 3 && currentButtonSelectionIndex != 9)
                    {
                        resetButtonFocus(currentButtonSelectionIndex);
                        currentButtonSelectionIndex = (currentButtonSelectionIndex - 3) % 9;
                        setButtonFocus(currentButtonSelectionIndex);
                    }
                    else
                    {
                        resetButtonFocus(currentButtonSelectionIndex);
                        currentButtonSelectionIndex = 9;
                        setButtonFocus(currentButtonSelectionIndex);
                    }
                    break;
                **/
                case Key.Back:
                    {
                        // Go back to main menu on backspace
                        MainWindow mainWindow = new MainWindow();
                        mainWindow.Show();
                        this.Close();
                    }
                    break;
                case Key.Enter:
                    //bool dontClose = false;
                    //resetButtonFocus(currentButtonSelectionIndex);
                    //switch (content[currentButtonSelectionIndex, 0])
                    //{
                    //    case "Live TV":
                    //        TV_Guide tv = new TV_Guide();
                    //        tv.Show();
                    //        break;
                    //}
                    break;
                default:
                    break;
            }
        }

        // TODO
        /**
        public void SetButtonFocus(int CurrentSelection)
        {
            //currentButtonSelectionIndex = button_index;
            Button button = menuButtonList[CurrentSelection];
            button.Background = Brushes.DarkBlue;
            //if (button_index != 9) //not profile button
            //{
            selectedLabel = new Label();
            selectedLabel.Name = "labelSelected";
            selectedLabel.FontSize = 25;
            selectedLabel.Foreground = Brushes.WhiteSmoke;
            selectedLabel.Content = content[CurrentSelection, 0];
            stackPanelList[CurrentSelection].Children.Add(selectedLabel);
            //}
            button.Foreground = Brushes.White;
            button.Height *= 1.2;
        }
        public void ResetButtonFocus(int button_index)
        {
            Button button = menuButtonList[button_index];
            button.ClearValue(Button.BackgroundProperty);
            button.ClearValue(Button.ForegroundProperty);
            //if (button_index != 9)
            //{
            stackPanelList[button_index].Children.Remove(selectedLabel);
            //}

            button.Height /= 1.2;
        }
        **/
    }
}
