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
    /// Interaction logic for HomeOrderWindow.xaml
    /// </summary>
    public partial class HomeOrderWindow : Window
    {
        public HomeOrderWindow()
        {
            InitializeComponent();
        }

        private void selectButton_Click(object sender, RoutedEventArgs e)
        {
            HomeOrder w = new HomeOrder();
            w.Show();
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            AddHomeOrder w = new AddHomeOrder();
            w.Show();
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            DeleteHomeOrder w = new DeleteHomeOrder();
            w.Show();
        }

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            UpdateHomeOrder w = new UpdateHomeOrder();
            w.Show();
        }

    }
}
