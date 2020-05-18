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
    /// Interaction logic for DeleteOrder.xaml
    /// </summary>
    public partial class RemoveOrder : Window
    {

        DataTable dt;


        string value;


        OracleDataAdapter dataAdapter1;

        OracleDataReader dataReader1;

        OracleConnection oracleConnection1 = DBSingleton.getConnection();


        public RemoveOrder()
        {
            InitializeComponent();

            if (oracleConnection1 == null || oracleConnection1.State == ConnectionState.Closed)
            {
                oracleConnection1.Open();
            }


            dataAdapter1 = new OracleDataAdapter();

            
            dataAdapter1.SelectCommand = new OracleCommand();
            dataAdapter1.SelectCommand.Connection = oracleConnection1;
            dataAdapter1.SelectCommand.CommandText = "select * from orderr";


            dataReader1 = dataAdapter1.SelectCommand.ExecuteReader(); //Il va executer la query et la mettre ds dataReader
            while (dataReader1.Read())
            {
                int num = dataReader1.GetInt32(0);
                removeordercombobox.Items.Add(num);

            }
        }


        private void removeButton_Click(object sender, RoutedEventArgs e)
        {

            OracleCommand InsertCommand = new OracleCommand();
            InsertCommand.Connection = DBSingleton.getConnection();

            string insertC = "delete from orderr where ordernum = " + int.Parse(removeordercombobox.SelectedValue.ToString());
            InsertCommand.CommandText = insertC;

            try
            {
              
                MessageBox.Show("The Order was removed!");
                this.Close();
              
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

        }

        private void removeordercombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string str1 = "select * from orderr where ordernum = " + int.Parse(removeordercombobox.SelectedValue.ToString());

            //attach select command 
            dataAdapter1.SelectCommand = new OracleCommand();
            dataAdapter1.SelectCommand.Connection = oracleConnection1;
            dataAdapter1.SelectCommand.CommandText = str1;


            dataReader1 = dataAdapter1.SelectCommand.ExecuteReader(); //Il va executer la query et la mettre ds dataReader
            while (dataReader1.Read())
            {
                string name = dataReader1.GetString(1);
                customerName.Text = name;

              
                

            }

        }
    }
    }

