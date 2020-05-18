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
    /// Interaction logic for AddWaiter.xaml
    /// </summary>
    public partial class AddWaiter : Window
    {


        DataTable dt;

        string value;


        OracleDataReader dataReader1;

        OracleDataAdapter dataAdapter1;

        OracleConnection oracleConnection1 = DBSingleton.getConnection();
        public AddWaiter()
        {
            InitializeComponent();
        }


        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            if (oracleConnection1 == null || oracleConnection1.State == ConnectionState.Closed)
            {
                oracleConnection1.Open();
            }

            OracleCommand AddCommand = new OracleCommand();
            AddCommand.Connection = DBSingleton.getConnection();
            string insertC = "insert into waiter (waiterid,waitername,waiterphone) values ( " + idtextbox.Text.ToString() + " ,'" + nametextbox.Text.ToString() + "' , '" + phonetextbox.Text.ToString() + "')";
            AddCommand.CommandText = insertC;

            try
            {
                AddCommand.ExecuteNonQuery();
                MessageBox.Show("waiter added succesfuly!");
                this.Close();
            }

            catch
            {
                MessageBox.Show("ERROR: waiter was not added!");
            }

        }
    }
}
