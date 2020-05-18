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
    /// Interaction logic for AddDishInBranch.xaml
    /// </summary>
    public partial class AddDishInBranch : Window
    {

        DataTable dt;
        string value;
        DataSet ds;

        OracleDataAdapter dataAdapter1;

        OracleConnection oracleConnection1 = DBSingleton.getConnection();

        public AddDishInBranch()
        {
            InitializeComponent();

            if (oracleConnection1.State == System.Data.ConnectionState.Closed)
            {
                oracleConnection1.Open();
            }
               


            dataAdapter1 = new OracleDataAdapter();
            dataAdapter1.SelectCommand = new OracleCommand();
            ds = new DataSet();
            dataAdapter1.SelectCommand.Connection = oracleConnection1;

            dataAdapter1.SelectCommand.CommandText = "select dishnum from dish";
            dataAdapter1.Fill(ds);
            List<string> list = convertTableToList(ds);
            dishnumberCombobox.ItemsSource = list;
            dataAdapter1.SelectCommand.CommandText = "select brunchnum from branch";
            dataAdapter1.Fill(ds);
            list = convertTableToList(ds);
            branchnumberCombobox.ItemsSource = list;
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

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            //oracleConnection1.Open();
            OracleCommand AddCommand = new OracleCommand();
            AddCommand.Connection = DBSingleton.getConnection();
            string insertC = "insert into dishinbrunch (brunchnum,dishnum) values ( " + branchnumberCombobox.Text.ToString() + " ,'" + dishnumberCombobox.Text.ToString() + "')";
            AddCommand.CommandText = insertC;
            try
            {
                AddCommand.ExecuteNonQuery();
                MessageBox.Show("dish in branch added succesfuly!");
                this.Close();
            }
            catch { MessageBox.Show("ERROR: dish in branch was not added!"); }
        }
    }
}
