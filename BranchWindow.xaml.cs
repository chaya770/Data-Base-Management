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
    /// Interaction logic for BranchWindow.xaml
    /// </summary>
    public partial class BranchWindow : Window
    {
        public BranchWindow()
        {
            InitializeComponent();
        }

        private void selectButton_Click(object sender, RoutedEventArgs e)
        {

            Branch sbWindow = new Branch();
            sbWindow.Show();
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            AddBranch addb = new AddBranch();
            addb.Show();
        }



        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            RemoveBranch rb = new RemoveBranch();
            rb.Show();
        }

        private void updateBranchButton_Click(object sender, RoutedEventArgs e)
        {
            UpdateBranch ub = new UpdateBranch();
            ub.Show();
        }
    }
}
