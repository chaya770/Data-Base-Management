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
    /// Interaction logic for DishWindow.xaml
    /// </summary>
    public partial class DishWindow : Window
    {
        public DishWindow()
        {
            InitializeComponent();
        }


        private void selectbutton_Click(object sender, RoutedEventArgs e)
        {
            Dish w = new Dish();
            w.Show();
        }

        private void addbutton_Click(object sender, RoutedEventArgs e)
        {
            AddDish w = new AddDish();
            w.Show();
        }

        private void deletebutton_Click(object sender, RoutedEventArgs e)
        {
            RemoveDish w = new RemoveDish();
            w.Show();
        }

        private void updatebutton_Click(object sender, RoutedEventArgs e)
        {
            UpdateDish w = new UpdateDish();
            w.Show();
        }
    }
}
