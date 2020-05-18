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
    /// Interaction logic for UpdateWaiter.xaml
    /// </summary>
    public partial class UpdateWaiter : Window
    {

        DataSet ds;

        string value;


        OracleDataReader dataReader1;

        OracleDataAdapter dataAdapter1;

        OracleConnection oracleConnection1 = DBSingleton.getConnection();
        public UpdateWaiter()
        {
            InitializeComponent();

            if (oracleConnection1.State == System.Data.ConnectionState.Closed)
                oracleConnection1.Open();


            dataAdapter1 = new OracleDataAdapter();
            dataAdapter1.SelectCommand = new OracleCommand();
            ds = new DataSet();
            dataAdapter1.SelectCommand.Connection = oracleConnection1;

            dataAdapter1.SelectCommand.CommandText = "select * from waiter";
            dataAdapter1.Fill(ds);
            List<string> list = convertTableToList(ds);
            updatewaitercombobox.ItemsSource = list;
        }

        private List<string> convertTableToList(DataSet ds)
        {
            List<string> list = new List<string>();
            foreach (DataRow dtrow in ds.Tables[0].Rows)
            {
                list.Add(dtrow.ItemArray[0].ToString() + "," + dtrow.ItemArray[1].ToString() + "," + dtrow.ItemArray[2].ToString());
            }
            return list;
        }

        private void updatewaitercombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string[] branchDetails = updatewaitercombobox.SelectedValue.ToString().Split(',');
            string waiternum = branchDetails[0];
            string waitername = branchDetails[1];
            string waiterphone = branchDetails[2];

            waiternameTextBox.Text = waitername;
            waiterphoneTextBox.Text = waiterphone;

        }


        private void updatewaiter_Click(object sender, RoutedEventArgs e)
        {
            string[] Details = updatewaitercombobox.SelectedValue.ToString().Split(',');
            string waiternum = Details[0];


            OracleCommand UpdateCommand = new OracleCommand();

            UpdateCommand.Connection = DBSingleton.getConnection();

            string update = "UPDATE waiter set waitername ='" + waiternameTextBox.Text.ToString() + "', waiterphone = '" + waiterphoneTextBox.Text.ToString() + "' where waiterid = '" + waiternum + "'";
            UpdateCommand.CommandText = update;

            try
            {
                UpdateCommand.ExecuteNonQuery();
                MessageBox.Show("waiter was update succefuly!");
            }
            catch { MessageBox.Show("ERROE: waiter was not update!"); }

        }
    }
}
