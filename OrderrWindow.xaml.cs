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
    /// Interaction logic for OrderrWindow.xaml
    /// </summary>
    public partial class OrderrWindow : Window
    {
        public OrderrWindow()
        {
            InitializeComponent();
        }


        private void selectbutton_Click(object sender, RoutedEventArgs e)
        {
            Orderr w = new Orderr();
            w.Show();
        }

        private void addbutton_Click(object sender, RoutedEventArgs e)
        {
            AddOrder w = new AddOrder();
            w.Show();
        }

        private void deletebutton_Click(object sender, RoutedEventArgs e)
        {
            RemoveOrder w = new RemoveOrder();
            w.Show();
        }

        private void updatebutton_Click(object sender, RoutedEventArgs e)
        {
            UpdateOrderr w = new UpdateOrderr();
            w.Show();
        }
    }
}
