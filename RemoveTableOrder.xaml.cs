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
    /// Interaction logic for RemoveTableOrder.xaml
    /// </summary>
    public partial class RemoveTableOrder : Window
    {

        DataTable dt;

        string value;


        OracleDataReader dataReader1;

        OracleDataAdapter dataAdapter1;

        OracleConnection oracleConnection1 = DBSingleton.getConnection();

        int num;

        public RemoveTableOrder()
        {
            InitializeComponent();

            //On remplit la combobox de please select a num Order
            if (oracleConnection1 == null || oracleConnection1.State == ConnectionState.Closed)
            {
                oracleConnection1.Open();
            }


            dataAdapter1 = new OracleDataAdapter();

            //attach select command 
            dataAdapter1.SelectCommand = new OracleCommand();
            dataAdapter1.SelectCommand.Connection = oracleConnection1;
            dataAdapter1.SelectCommand.CommandText = "select ordernum from tableorder"; //Les numeros des orders qui mangent au restaurant


            dataReader1 = dataAdapter1.SelectCommand.ExecuteReader(); //Il va executer la query et la mettre ds dataReader
            while (dataReader1.Read())
            {
                num = dataReader1.GetInt32(0);
                ordercombobox.Items.Add(num);
            }




        }


        private void tablecombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ordercombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            //On remplit la combobox de tables

            dataAdapter1 = new OracleDataAdapter();

            //attach select command 
            dataAdapter1.SelectCommand = new OracleCommand();
            dataAdapter1.SelectCommand.Connection = oracleConnection1;
            dataAdapter1.SelectCommand.CommandText = "select tablenumber from tableorder where ordernum =" + int.Parse(ordercombobox.SelectedValue.ToString());


            dataReader1 = dataAdapter1.SelectCommand.ExecuteReader(); //Il va executer la query et la mettre ds dataReader
            while (dataReader1.Read())
            {
                num = dataReader1.GetInt32(0);
                tablecombobox.Items.Add(num);

            }

            //On remplit la combobox de waiters

            dataAdapter1 = new OracleDataAdapter();

            //attach select command 
            dataAdapter1.SelectCommand = new OracleCommand();
            dataAdapter1.SelectCommand.Connection = oracleConnection1;
            dataAdapter1.SelectCommand.CommandText = "select waiterid from tableorder  where ordernum =" + int.Parse(ordercombobox.SelectedValue.ToString());


            dataReader1 = dataAdapter1.SelectCommand.ExecuteReader(); //Il va executer la query et la mettre ds dataReader
            while (dataReader1.Read())
            {
                string nume = dataReader1.GetString(0);
                waitercombobox.Items.Add(nume);
               

            }
        }

        private void remove_Click(object sender, RoutedEventArgs e)
        {
            OracleCommand InsertCommand = new OracleCommand();
            InsertCommand.Connection = DBSingleton.getConnection();

            string insertC = "delete from tableorder where ordernum = " + int.Parse(ordercombobox.SelectedValue.ToString()) + " and tablenumber =" + int.Parse(tablecombobox.SelectedValue.ToString()) + " and waiterid = " + waitercombobox.SelectedValue.ToString() ;
            InsertCommand.CommandText = insertC;


            try
            {
                MessageBox.Show("The Table and the Waiter was removed from the Order!");
                this.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
