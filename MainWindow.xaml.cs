using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
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



namespace MiniProjectGui
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        //Datadapter est l intermediaire entre notre programme et Oracle: On l utilisera pr puiser des netounim
        //DataSet ou DataTable :object pour contenir les donnees d un tableau
        //DataSet est un array de DataTable : on lutilse lorsqu on puise des donnees de plusieurs tableaux
        //Pour une shelifa simple , on utilisera seulement DataTable
        public MainWindow()
        {
            InitializeComponent();
        }
        private void branchbutton_Click(object sender, RoutedEventArgs e)
        {
            BranchWindow bw = new BranchWindow();
            bw.Show();
        }

        private void waiterbutton_Click(object sender, RoutedEventArgs e)
        {
            WaiterWindow ww = new WaiterWindow();
            ww.Show();
        }



        private void homeorderbutton_Click(object sender, RoutedEventArgs e)
        {
            HomeOrderWindow how = new HomeOrderWindow();
            how.Show();
        }

        private void dishinbranchbutton_Click(object sender, RoutedEventArgs e)
        {
            DishInBrunchWindow diow = new DishInBrunchWindow();
            diow.Show();
        }

        private void orderbutton_Click(object sender, RoutedEventArgs e)
        {
            OrderrWindow w = new OrderrWindow();
            w.Show();
        }

        private void dishbutton_Click(object sender, RoutedEventArgs e)
        {
            DishWindow w = new DishWindow();
            w.Show();
        }

        private void tableorderbutton_Click(object sender, RoutedEventArgs e)
        {
            TableOrderWindow w = new TableOrderWindow();
            w.Show();
        }

        private void dishinorderbutton_Click(object sender, RoutedEventArgs e)
        {
            DishInOrderWindow w = new DishInOrderWindow();
            w.Show();
        }

        private void querysButton_Click(object sender, RoutedEventArgs e)
        {
            Querys w = new Querys();
            w.Show();
        }

        private void functionsButton_Click(object sender, RoutedEventArgs e)
        {
            Functions w = new Functions();
            w.Show();
        }
    }


}
