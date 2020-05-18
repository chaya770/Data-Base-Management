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
    /// Interaction logic for DishInOrderWindow.xaml
    /// </summary>
    public partial class DishInOrderWindow : Window
    {
        public DishInOrderWindow()
        {
            InitializeComponent();
        }


        private void selectbutton_Click(object sender, RoutedEventArgs e)
        {
            OrderDish w = new OrderDish();
            w.Show();
        }

        private void addbutton_Click(object sender, RoutedEventArgs e)
        {
            AddDishInOrder w = new AddDishInOrder();
            w.Show();
        }

        private void deletebutton_Click(object sender, RoutedEventArgs e)
        {
            RemoveOrderDish w = new RemoveOrderDish();
            w.Show();
        }

        private void updatebutton_Click(object sender, RoutedEventArgs e)
        {
            UpdateOrderDishh w = new UpdateOrderDishh();
            w.Show();
        }
    }
}
