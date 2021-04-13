﻿using System;
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
using System.Windows.Threading;

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
        private ScrollViewer sv;
        private Button setReminder;
        private Button cancel;
        private Button done;
        private Border setReminder_border;
        private Border cancel_border;
        private Border done_border;
        SolidColorBrush hover_border_color = new SolidColorBrush((Color) ColorConverter.ConvertFromString("#507EFF"));
        Thickness hover_border_thickness = new Thickness(2);
        SolidColorBrush std_border_color = new SolidColorBrush((Color)ColorConverter.ConvertFromString("Black"));
        Thickness std_border_thickness = new Thickness(1);


        TextBlock popup_message;
        bool currently_on_set_reminder;


        //max index of list_box_items
        private const int MAX_LBI_INDEX = 7;

        //max index of list_boxes (not to be confused with MAX_LBI_INDEX)
        private const int MAX_LB_INDEX = 2;

        // For clock
        private DispatcherTimer dispatcherTimer;


        public TV_Guide()
        {
            InitializeComponent();
            this.DataContext = this;

            // Thanks Aifaz
            // Display the date & time
            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Interval = new TimeSpan(0, 0, 5);
            DispatcherTimer timer = new DispatcherTimer(new TimeSpan(0, 0, 1), DispatcherPriority.Normal, delegate
            {
                this.guide_time.Content = DateTime.Now.ToString("hh:mm tt");
                this.guide_date.Content = DateTime.Now.ToString("MMMM dd, yyyy");
            }, this.Dispatcher);


            List_boxes = new ListBox[] { listbox1, listbox2,listbox3 };
            List_box_items = new ListBoxItem[,] {
            { listbox1item1, listbox1item2, listbox1item3, listbox1item4, listbox1item5, listbox1item6, listbox1item7, listbox1item8 },
            { listbox2item1, listbox2item2, listbox2item3, listbox2item4, listbox2item5, listbox2item6, listbox2item7, listbox2item8 },
            { listbox2item1, listbox2item2, listbox2item3, listbox2item4, listbox2item5, listbox2item6, listbox2item7, listbox2item8 }
            };

            sv = scrollviewer;

            List_boxes[0].SelectedIndex = 0;
            List_boxes[1].SelectedIndex = -1;
            List_boxes[2].SelectedIndex = -1;

            lb = List_boxes[0];

            
           

            setReminder = set_reminder_button;
            cancel = cancel_button;
            done = done_button;

            setReminder_border = set_reminder_button_border;
            cancel_border = cancel_button_border;
            done_border = done_button_border;

            setReminder.Background = (LinearGradientBrush)FindResource("ButtonNormalBackground"); ;
            cancel.Background = (LinearGradientBrush)FindResource("ButtonHoverBackground"); ;
            done.Background = (LinearGradientBrush)FindResource("ButtonHoverBackground"); ;

            done_border.Opacity = 0;
            done_border.BorderBrush = hover_border_color;
            done_border.BorderThickness = hover_border_thickness;

            setReminder_border.BorderBrush = std_border_color;
            setReminder_border.BorderThickness = std_border_thickness;

            Popup_IsOpen = false;

            popup_message = textblock;

   

            
            

        }



        private void Window_KeyDown(object sender, KeyEventArgs e)
        {

            switch (e.Key)
            {
                case Key.Right:
                    if (Popup_IsOpen)
                    {
                        setReminder.Background = (LinearGradientBrush)FindResource("ButtonNormalBackground"); 
                        setReminder_border.BorderBrush = std_border_color;
                        setReminder_border.BorderThickness = std_border_thickness;

                        cancel.Background = (LinearGradientBrush)FindResource("ButtonHoverBackground");
                        cancel_border.BorderBrush = hover_border_color;
                        cancel_border.BorderThickness = hover_border_thickness;

                        currently_on_set_reminder = false;
                        
                    }
                    else
                    {
                        if (lb.SelectedIndex < MAX_LBI_INDEX) lb.SelectedIndex += 1;
                        lb.ScrollIntoView(lb.SelectedItem);
                        

                    }

                    break;
                case Key.Left:
                    if (Popup_IsOpen)
                    {
                        setReminder.Background = (LinearGradientBrush)FindResource("ButtonHoverBackground");
                        setReminder_border.BorderBrush = hover_border_color;
                        setReminder_border.BorderThickness = hover_border_thickness;

                        cancel.Background = (LinearGradientBrush)FindResource("ButtonNormalBackground");
                        cancel_border.BorderBrush = std_border_color;
                        cancel_border.BorderThickness = std_border_thickness;

                        currently_on_set_reminder = true;
                        
                    }
                    else
                    {
                        if (lb.SelectedIndex > 0) lb.SelectedIndex -= 1;
                        lb.ScrollIntoView(lb.SelectedItem);
                    }
                    break;
                case Key.Down:
                    if (Popup_IsOpen)
                    {

                    }
                    else
                    {
                        lb.SelectedIndex = 0;
                        lb.ScrollIntoView(lb.SelectedItem);
                        lb.SelectedIndex = -1;

                        if (lb_index < MAX_LB_INDEX) lb_index += 1;
                        lb = List_boxes[lb_index];
                        lb.SelectedIndex = 0;
                        lb.ScrollIntoView(lb.SelectedItem);
                        lb.BringIntoView();
                    }
                    break;
                case Key.Up:
                    if (Popup_IsOpen)
                    {

                    }
                    else
                    {
                        lb.SelectedIndex = 0;
                        lb.ScrollIntoView(lb.SelectedItem);
                        lb.SelectedIndex = -1;

                        if (lb_index > 0) lb_index -= 1;
                        lb = List_boxes[lb_index];
                        lb.SelectedIndex = 0;
                        lb.ScrollIntoView(lb.SelectedItem);
                        lb.BringIntoView();
                    }


                    break;
                case Key.O:

                    if (!Popup_IsOpen) {

                        //Selected sherlock
                        if (lb == List_boxes[0] && lb.SelectedIndex == 0)
                        {
                            channel = 1;
                            LiveTV livetv = new LiveTV(channel);
                            livetv.Show();
                            this.Close();

                        }
                        else
                        {   
                            //Selected Topgear or one of first two shows in any category
                            if ((lb == List_boxes[0] && lb.SelectedIndex == 1) || lb.SelectedIndex < 2)
                            {
                                channel = 2;
                                LiveTV livetv = new LiveTV(channel);
                                livetv.Show();
                                this.Close();
                            }//else show is not on
                            else
                            {
                                Popup_IsOpen = true; 
                            }
                        }
                    }
        
                    
                    //Pop is open
                    else
                    {
                        //when set reminder was pressed
                        if (currently_on_set_reminder)
                        {                          
                            popup_message.Text = "Reminder has been set!";
                            done_border.Opacity = 100;
                            cancel_border.Opacity = 0;
                            setReminder_border.Opacity = 0;
                            currently_on_set_reminder = false;


                        }
                        else
                        {
                            //back to default
                            setReminder.Background = (LinearGradientBrush)FindResource("ButtonNormalBackground");
                            setReminder_border.BorderBrush = std_border_color;
                            setReminder_border.BorderThickness = std_border_thickness;
                            cancel.Background = (LinearGradientBrush)FindResource("ButtonHoverBackground");
                            cancel_border.BorderBrush = hover_border_color;
                            cancel_border.BorderThickness = hover_border_thickness;

                            

                            setReminder_border.Opacity = 100;
                            cancel_border.Opacity = 100;
                            done_border.Opacity = 0;
                            popup_message.Text = "Would you like to set a reminder for this show?";
                            Popup_IsOpen = false;


                        }
                        
                    }

                    break;

                case Key.Back:
                    MainWindow mainwindow = new MainWindow();
                    mainwindow.Show();
                    this.Close();
                    break;

                default:
                    break;
            }

        }


        public static readonly DependencyProperty Popup_IsOpenProperty = DependencyProperty.Register("Popup_IsOpen", typeof(bool), typeof(TV_Guide));
       

        public bool Popup_IsOpen
        {
            get { return (bool)GetValue(Popup_IsOpenProperty); }
            set { SetValue(Popup_IsOpenProperty, value); }
        }

    }


}
