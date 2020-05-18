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
    /// Interaction logic for UpdateOrderr.xaml
    /// </summary>
    public partial class UpdateOrderr : Window
    {

        DataTable dt;
        string value;


        OracleDataAdapter dataAdapter1;

        OracleDataReader dataReader1;

        OracleConnection oracleConnection1 = DBSingleton.getConnection();

        


        public UpdateOrderr()
        {
            InitializeComponent();



            if (oracleConnection1 == null || oracleConnection1.State == ConnectionState.Closed)
            {
                oracleConnection1.Open();
            }


            dataAdapter1 = new OracleDataAdapter();

            //attach select command 
            dataAdapter1.SelectCommand = new OracleCommand();
            dataAdapter1.SelectCommand.Connection = oracleConnection1;
            dataAdapter1.SelectCommand.CommandText = "select * from orderr";


            dataReader1 = dataAdapter1.SelectCommand.ExecuteReader(); //Il va executer la query et la mettre ds dataReader
            while (dataReader1.Read())
            {
                int num = dataReader1.GetInt32(0);//Le ordernum
                updateordercombobox.Items.Add(num);

            }
        }

        
        private void dDatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {

        }



        private void updateorder_Click(object sender, RoutedEventArgs e)
        {
            OracleCommand InsertCommand = new OracleCommand();
            InsertCommand.Connection = DBSingleton.getConnection();

            string insertC = "update  orderr " +
                "set customername = " + customerName.Text.ToString() + "," +
                 "orderdate =" + dDatePicker.SelectedDate.ToString()    + 
                 
                 " where ordernum = " + int.Parse(updateordercombobox.SelectedValue.ToString());
            InsertCommand.CommandText = insertC;

            try
            {
           
                MessageBox.Show("The Order was updated !");
                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void updateordercombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //C est le client qui rentre lui meme les fields car c est un update 
        }
    }
}
