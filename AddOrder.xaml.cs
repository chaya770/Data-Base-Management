using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
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
    /// Interaction logic for AddOrder.xaml
    /// </summary>
    public partial class AddOrder : Window
    {


        DataTable dt;

        string value;


        OracleDataAdapter dataAdapter1;

        OracleConnection oracleConnection1 = DBSingleton.getConnection();


        public AddOrder()
        {
            
            InitializeComponent();


        }

        private void addButton_Click(object sender, RoutedEventArgs e) //boutton add orange
        {

            if (oracleConnection1 == null || oracleConnection1.State == ConnectionState.Closed)
            {
                oracleConnection1.Open();
            }



            OracleCommand InsertCommand = new OracleCommand();
            InsertCommand.Connection = DBSingleton.getConnection();

            string insertC = "insert into orderr (ordernum,customername,orderdate) values ( " + int.Parse(orderNum.Text) + " ,'" + nameclientTextBox.Text.ToString()+ " ','" + dateDatePicker.SelectedDate.ToString() + "')";
            InsertCommand.CommandText = insertC;


            try
            {
                MessageBox.Show("The Order was Added!");
                this.Close();
               

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


        


        



        private void ordered_DishDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                DataGrid dg = sender as DataGrid;
                if (dg.SelectedIndex > -1)
                {

                }
            }
            catch
            {

            }
        }


     
    }
}
