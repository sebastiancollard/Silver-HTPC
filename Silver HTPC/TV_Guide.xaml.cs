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
        private int lb_index;
        private ListBoxItem[,] List_box_items;
        private ListBox lb;
        private int channel;

        //max index of list_box_items
        private const int MAX_LBI_INDEX = 7;

        //max index of list_boxes (not to be confused with MAX_LBI_INDEX)
        private const int MAX_LB_INDEX = 3;




        public TV_Guide()
        {
            InitializeComponent();


            List_boxes = new ListBox[] { listbox1, listbox2,listbox3 };
            List_box_items = new ListBoxItem[,] {
            { listbox1item1, listbox1item2, listbox1item3, listbox1item4, listbox1item5, listbox1item6, listbox1item7, listbox1item8 },
            { listbox2item1, listbox2item2, listbox2item3, listbox2item4, listbox2item5, listbox2item6, listbox2item7, listbox2item8 },
            { listbox2item1, listbox2item2, listbox2item3, listbox2item4, listbox2item5, listbox2item6, listbox2item7, listbox2item8 }
            };

            List_boxes[0].SelectedIndex = 0;
            List_boxes[1].SelectedIndex = 0;
            List_boxes[2].SelectedIndex = 0;

            lb = List_boxes[0];
            lb.Focus();

            
            












        }



        private void Window_KeyDown(object sender, KeyEventArgs e)
        {

            switch (e.Key)
            {
                case Key.Right:
                    if(lb.SelectedIndex < MAX_LBI_INDEX - 1) lb.SelectedIndex += 1;
              
                    break;
                case Key.Left:
                    if(lb.SelectedIndex > 0) lb.SelectedIndex -= 1;

                    break;
                case Key.Down:
                    lb.SelectedIndex = 0;
                    lb.ScrollIntoView(lb.SelectedItem);
                    if (lb_index < MAX_LB_INDEX - 1) lb_index += 1;
                    lb = List_boxes[lb_index];
                    lb.SelectedIndex = 0;
                    lb.Focus();
                    
                    break;
                case Key.Up:
                    lb.SelectedIndex = 0;
                    if (lb_index > 0) lb_index -= 1;
                    lb = List_boxes[lb_index];
                    lb.SelectedIndex = 0;
                    lb.Focus();
                    

                    break;
                case Key.Enter:
                    if (lb == List_boxes[0] && lb.SelectedIndex == 0) channel = 1;
                    else channel = 2;
                    LiveTV livetv = new LiveTV(channel);
                    livetv.Show();

                    break;
                default:
                    break;
            }

        }
    }


}
