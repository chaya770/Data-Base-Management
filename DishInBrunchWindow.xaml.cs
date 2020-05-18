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
    /// Interaction logic for DishInBrunchWindow.xaml
    /// </summary>
    public partial class DishInBrunchWindow : Window
    {
        public DishInBrunchWindow()
        {
            InitializeComponent();
        }

        private void selectbutton_Click(object sender, RoutedEventArgs e)
        {
           DishInBranch w = new DishInBranch();
            w.Show();
        }

        private void updatebutton_Click(object sender, RoutedEventArgs e)
        {
            UpdateDishInBranch w = new UpdateDishInBranch();
            w.Show();
        }

        private void deletebutton_Click(object sender, RoutedEventArgs e)
        {
            DeleteDishInBranch w = new DeleteDishInBranch();
            w.Show();
        }

        private void addbutton_Click(object sender, RoutedEventArgs e)
        {
            AddDishInBranch w = new AddDishInBranch();
            w.Show();
        }
    }
}
