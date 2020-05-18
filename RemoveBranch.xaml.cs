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
    /// Interaction logic for RemoveBranch.xaml
    /// </summary>
    public partial class RemoveBranch : Window
    {

        DataSet ds;


        string value;


        OracleDataAdapter dataAdapter1;

        OracleDataReader dataReader1;

        OracleConnection oracleConnection1 = DBSingleton.getConnection();

        public RemoveBranch()
        {
            InitializeComponent();

            if (oracleConnection1.State == System.Data.ConnectionState.Closed)
                oracleConnection1.Open();


            dataAdapter1 = new OracleDataAdapter();
            dataAdapter1.SelectCommand = new OracleCommand();
            ds = new DataSet();
            dataAdapter1.SelectCommand.Connection = oracleConnection1;

            dataAdapter1.SelectCommand.CommandText = "select * from branch";
            dataAdapter1.Fill(ds);
            List<string> list = convertTableToList(ds);
            removebranchcombobox.ItemsSource = list;
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

        private void removebranch_Click(object sender, RoutedEventArgs e)
        {
            string[] branchDetails = removebranchcombobox.SelectedValue.ToString().Split(',');
            string branchnum = branchDetails[0];


            OracleCommand DeleteCommand = new OracleCommand();

            DeleteCommand.Connection = DBSingleton.getConnection();
            //delete from branch where brunchnum='301'
            string deleteR = "delete from branch where brunchnum=" + branchnum;
            DeleteCommand.CommandText = deleteR;

            try
            {
                DeleteCommand.ExecuteNonQuery();
                MessageBox.Show("branch was deleted succefuly!");
                this.Close();


            }
            catch { MessageBox.Show("ERROE: branch was not deleted!"); }

        }
    }
}
