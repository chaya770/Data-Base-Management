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
    /// Interaction logic for UpadateTableOrder.xaml
    /// </summary>
    public partial class UpadateTableOrder : Window
    {

        DataTable dt;

        string value;


        OracleDataReader dataReader1;

        OracleDataAdapter dataAdapter1;

        OracleConnection oracleConnection1 = DBSingleton.getConnection();

        int num;


        public UpadateTableOrder()
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
            textBox.Text = tablecombobox.SelectedValue.ToString();

            dataAdapter1 = new OracleDataAdapter();

            //attach select command 
            dataAdapter1.SelectCommand = new OracleCommand();
            dataAdapter1.SelectCommand.Connection = oracleConnection1;
            dataAdapter1.SelectCommand.CommandText = "select * from tablee";


            dataReader1 = dataAdapter1.SelectCommand.ExecuteReader(); //Il va executer la query et la mettre ds dataReader
            while (dataReader1.Read())
            {
                num = dataReader1.GetInt32(0);
                comboBox1.Items.Add(num);

            }

        }

        //Quand on appuie sur le button update
        private void updateorder_Click(object sender, RoutedEventArgs e)
        {
            OracleCommand InsertCommand = new OracleCommand();
            InsertCommand.Connection = DBSingleton.getConnection();

            string insertC = "update tableorder " +
                "set tablenumber = " + int.Parse(comboBox1.SelectedValue.ToString()) + "," +
                " waiterid = " + int.Parse(comboBox2.SelectedValue.ToString())
                + "where ordernum = " + int.Parse(ordercombobox.SelectedValue.ToString());

            InsertCommand.CommandText = insertC;

            try
            {
                MessageBox.Show("The Table and the Waiter were  updated In the Order!");
                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        //Quand on a selectionne la order qu on veut modifier
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

        private void waitercombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            textBox2.Text = waitercombobox.SelectedValue.ToString();

            dataAdapter1 = new OracleDataAdapter();

            //attach select command 
            dataAdapter1.SelectCommand = new OracleCommand();
            dataAdapter1.SelectCommand.Connection = oracleConnection1;
            dataAdapter1.SelectCommand.CommandText = "select * from waiter";


            dataReader1 = dataAdapter1.SelectCommand.ExecuteReader(); //Il va executer la query et la mettre ds dataReader
            while (dataReader1.Read())
            {
                string nume = dataReader1.GetString(0);
                comboBox2.Items.Add(nume);
                string name = dataReader1.GetString(1);
                comboBox2.Items.Add(name);

            }
        }
    }
}
