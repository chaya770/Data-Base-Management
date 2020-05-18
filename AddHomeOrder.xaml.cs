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
    /// Interaction logic for AddHomeOrder.xaml
    /// </summary>
    public partial class AddHomeOrder : Window
    {

        DataTable dt;
        string value;
        DataSet ds;

        OracleDataAdapter dataAdapter1;
       
        OracleConnection oracleConnection1 = DBSingleton.getConnection();

        public AddHomeOrder()
        {
            InitializeComponent();

            if (oracleConnection1.State == System.Data.ConnectionState.Closed)
                oracleConnection1.Open();


            dataAdapter1 = new OracleDataAdapter();
            dataAdapter1.SelectCommand = new OracleCommand();
            ds = new DataSet();
            dataAdapter1.SelectCommand.Connection = oracleConnection1;

            dataAdapter1.SelectCommand.CommandText = "select ordernum from orderr where ordernum not in(select ordernum from homeorder)";
            dataAdapter1.Fill(ds);
            List<string> list = convertTableToList(ds);
            ordernumberCombobox.ItemsSource = list;
        }

        private List<string> convertTableToList(DataSet ds)
        {
            List<string> list = new List<string>();
            foreach (DataRow dtrow in ds.Tables[0].Rows)
            {
                list.Add(dtrow.ItemArray[0].ToString());
            }
            return list;
        }
        private void addHomeOrderButton_Click(object sender, RoutedEventArgs e)
        {
           
            OracleCommand InsertCommand = new OracleCommand();
            InsertCommand.Connection = DBSingleton.getConnection();
           
            string C = "insert into homeorder (ordernum,addres) values (" + int.Parse(ordernumberCombobox.SelectedValue.ToString()) + ",'" + adresstextbox.Text.ToString() + "');";
            InsertCommand.CommandText = C;


            try
            {
                InsertCommand.ExecuteNonQuery();
                MessageBox.Show("home order was added succesfuly!");
                this.Close();
            }
            catch
            {
                MessageBox.Show("ERROR:home order was not added!");
            }

        }
    }
}
