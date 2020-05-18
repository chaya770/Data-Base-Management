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
    /// Interaction logic for TableOrderWindow.xaml
    /// </summary>
    public partial class TableOrderWindow : Window
    {
        public TableOrderWindow()
        {
            InitializeComponent();
        }

        private void selectButton_Click(object sender, RoutedEventArgs e)
        {
            TableOrder w = new TableOrder();
            w.Show();
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            AddTableOrder w = new AddTableOrder();
            w.Show();
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            RemoveTableOrder w = new RemoveTableOrder();
            w.Show();
        }

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            UpadateTableOrder w = new UpadateTableOrder();
            w.Show();
        }
    }
}
