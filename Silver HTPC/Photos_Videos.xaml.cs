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
    /// Interaction logic for Page1.xaml
    /// </summary>

    public partial class Photos_Videos : Page
    {
        bool delete_Single_Clicked = false;
        public Photos_Videos()
        {
            InitializeComponent();
        }


        private void Delete_Single_Click(object sender, RoutedEventArgs e)
        {
            delete_Single_Clicked = true;
        }

        private void img_1_Hovering(object sender, MouseEventArgs e)
        {
            if (delete_Single_Clicked)
            {
                img_1.Opacity = 0.5;
            }
        }

        private void img_1_Leaving(object sender, MouseEventArgs e)
        {
            if (delete_Single_Clicked)
            {
                img_1.Opacity = 1.0;
            }
        }
        // How do we want to implement functionality? Using keys? Using mouse for the prototype?
        // Having a hard time implementing button functionality.
        // Have images turn different colour when hovering?
        // How do we want "selecting specific things" to look like?
    }
}
