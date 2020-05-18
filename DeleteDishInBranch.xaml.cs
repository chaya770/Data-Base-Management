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
    /// Interaction logic for DeleteDishInBranch.xaml
    /// </summary>
    public partial class DeleteDishInBranch : Window
    {
        DataSet ds;
        string value;

        OracleDataAdapter dataAdapter1;
        OracleConnection oracleConnection1 = DBSingleton.getConnection();
        public DeleteDishInBranch()
        {
            InitializeComponent();

            if (oracleConnection1.State == System.Data.ConnectionState.Closed)
                oracleConnection1.Open();


            dataAdapter1 = new OracleDataAdapter();
            dataAdapter1.SelectCommand = new OracleCommand();
            ds = new DataSet();
            dataAdapter1.SelectCommand.Connection = oracleConnection1;

            dataAdapter1.SelectCommand.CommandText = "select * from dishinbrunch";
            dataAdapter1.Fill(ds);
            List<string> list = convertTableToList(ds);
            removedishinbranchcombobox.ItemsSource = list;
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

        private void removeButton_Click(object sender, RoutedEventArgs e)
        {
            string[] Details = removedishinbranchcombobox.SelectedValue.ToString().Split(',');
            string branchnum = Details[0];
            string dishnum = Details[1];

            OracleCommand DeleteCommand = new OracleCommand();

            DeleteCommand.Connection = DBSingleton.getConnection();
            //delete from branch where brunchnum='301'
            string delete = "delete from dishinbrunch where brunchnum=" + branchnum + " and dishnum='" + dishnum + "'";
            DeleteCommand.CommandText = delete;

            try
            {
                DeleteCommand.ExecuteNonQuery();
                MessageBox.Show("dish in branch was deleted succefuly!");
                this.Close();
            }
            catch { MessageBox.Show("ERROE: dish in branch was not deleted!"); }

        }
    }
}
