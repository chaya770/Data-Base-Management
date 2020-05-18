using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MiniProjectGui
{
    /// <summary>
    /// Interaction logic for WaiterWindow.xaml
    /// </summary>
    public partial class WaiterWindow : Window
    {
        public WaiterWindow()
        {
            InitializeComponent();
        }

        private void selectbutton_Click(object sender, RoutedEventArgs e)
        {
            Waiter sw = new Waiter();
            sw.Show();
        }

        private void updatebutton_Click(object sender, RoutedEventArgs e)
        {
            UpdateWaiter w = new UpdateWaiter();
            w.Show();
        }

        private void deletebutton_Click(object sender, RoutedEventArgs e)
        {
            DeleteWaiter w = new DeleteWaiter();
            w.Show();
        }

        private void addbutton_Click(object sender, RoutedEventArgs e)
        {
            AddWaiter w = new AddWaiter();
            w.Show();
        }
    }
}
