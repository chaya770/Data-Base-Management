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
    /// Interaction logic for UpdateHomeOrder.xaml
    /// </summary>
    public partial class UpdateHomeOrder : Window
    {

        DataSet ds;
        string value;

        OracleDataAdapter dataAdapter1;
        OracleConnection oracleConnection1 = DBSingleton.getConnection();
        public UpdateHomeOrder()
        {
            InitializeComponent();

            if (oracleConnection1.State == System.Data.ConnectionState.Closed)
                oracleConnection1.Open();


            dataAdapter1 = new OracleDataAdapter();
            dataAdapter1.SelectCommand = new OracleCommand();
            ds = new DataSet();
            dataAdapter1.SelectCommand.Connection = oracleConnection1;

            dataAdapter1.SelectCommand.CommandText = "select * from homeorder";
            dataAdapter1.Fill(ds);
            List<string> list = convertTableToList(ds);
            updatehomeordercombobox.ItemsSource = list;
        }

        private List<string> convertTableToList(DataSet ds)
        {
            List<string> list = new List<string>();
            foreach (DataRow dtrow in ds.Tables[0].Rows)
            {
                list.Add(dtrow.ItemArray[0].ToString() + "," + dtrow.ItemArray[1].ToString());
            }
            return list;
        }

        private void updatehomeordercombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string[] branchDetails = updatehomeordercombobox.SelectedValue.ToString().Split(',');
            string ordernum = branchDetails[0];
            string adress = branchDetails[1];
            adreessTextBox.Text = adress;
        }





        private void updatehomeorder_Click(object sender, RoutedEventArgs e)
        {
            string[] branchDetails = updatehomeordercombobox.SelectedValue.ToString().Split(',');
            string ordernum = branchDetails[0];
            string adress = branchDetails[1];

            OracleCommand UpdateCommand = new OracleCommand();

            UpdateCommand.Connection = DBSingleton.getConnection();

            string updateB = "UPDATE homeorder set addres ='" + adreessTextBox.Text.ToString() + "' where ordernum = '" + ordernum + "' and addres='" + adress + "'";
            UpdateCommand.CommandText = updateB;

            try
            {
                UpdateCommand.ExecuteNonQuery();
                MessageBox.Show("home order was update succefuly!");
            }
            catch { MessageBox.Show("ERROE: home order was not update!"); }

        }
    }
}
