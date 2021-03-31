using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Interaction logic for TV_Guide.xaml
    /// </summary>
    public partial class TV_Guide : Window
    {

        private ListBox[] List_boxes;
        private ListBoxItem[] List_box1_items;
        private ListBoxItem[] List_box2_items;
        private ListBox lb;
        private ListBoxItem lbi;



        public TV_Guide()
        {
            InitializeComponent();


            List_boxes = new ListBox[] { listbox1, listbox2 };
            List_box1_items = new ListBoxItem[] { listbox1item1, listbox1item2, listbox1item3, listbox1item4, listbox1item5, listbox1item6, listbox1item7, listbox1item8 };
            List_box2_items = new ListBoxItem[] { listbox2item1, listbox2item2, listbox2item3, listbox2item4, listbox2item5, listbox2item6, listbox2item7, listbox2item8 };

            lb = List_boxes[0];
            lb.SelectedIndex = 0;
            List_box1_items[0].Focus();








        }



        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Right:
                    lb.SelectedIndex += 1;
              
                    break;
                case Key.Left:
                    if(lb.SelectedIndex > 0) lb.SelectedIndex -= 1;
                    break;
                case Key.Down:
                    lb.SelectedIndex = -1;
                    lb = List_boxes[1];
                    lb.SelectedIndex = 0;
                    List_box2_items[0].Focus();
                    break;
                case Key.Up:
                    lb.SelectedIndex = -1;
                    lb = List_boxes[0];
                    lb.SelectedIndex = 0;
                    List_box1_items[0].Focus();

                    break;
                case Key.Enter:
                    

                    break;
                default:
                    break;
            }

        }
    }


}
