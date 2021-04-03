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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Recordings : Window
    {
        private static List<Button> RecordButtonsList = new List<Button>();
        private static List<Grid> RecordButtonsGrids = new List<Grid>();
        private int RecordIndex = 0;
        public Recordings()
        {
            InitializeComponent();
            RecordButtonsList.Add(record1);
            RecordButtonsList.Add(record2);
            RecordButtonsList.Add(record3);
            record1.Focus();
            
        }
        private void Record_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Down)
            {
                if (RecordIndex < RecordButtonsList.Count - 1)
                {
                    RecordIndex += 1;
                    Console.WriteLine("RecordIndex: " + RecordIndex);
                }
                else
                {
                    RecordIndex = 0;
                    Console.WriteLine("RecordIndex: " + RecordIndex);
                }
            }
            else if (e.Key == Key.Up)
            {
                if (RecordIndex != 0)
                {
                    RecordIndex -= 1;
                    Console.WriteLine("RecordIndex: " + RecordIndex);
                }
                else
                {
                    RecordIndex = RecordButtonsList.Count - 1;
                    Console.WriteLine("RecordIndex: " + RecordIndex);
                }
            }
        }
        private void Recording_GotFocus(object sender, RoutedEventArgs e)
        {
            Button thisButton = e.Source as Button;
            //Console.WriteLine(thisButton.Name.ToString());
            thisButton.Background = Brushes.Red;
            thisButton.Height = 80;
        }

        private void Recording_LostFocus(object sender, RoutedEventArgs e)
        {
            Button thisButton = e.Source as Button;
            //Console.WriteLine(thisButton.Name.ToString());
            thisButton.Background = Brushes.White;
            thisButton.Height = 60;

        }



    }
}
