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
    /// Interaction logic for DeteWaiter.xaml
    /// </summary>
    public partial class DeleteWaiter : Window
    {

        DataSet ds;

        string value;


        OracleDataReader dataReader1;

        OracleDataAdapter dataAdapter1;

        OracleConnection oracleConnection1 = DBSingleton.getConnection();
        public DeleteWaiter()
        {
            InitializeComponent();

            if (oracleConnection1.State == System.Data.ConnectionState.Closed)
                oracleConnection1.Open();


            dataAdapter1 = new OracleDataAdapter();
            dataAdapter1.SelectCommand = new OracleCommand();
            ds = new DataSet();
            dataAdapter1.SelectCommand.Connection = oracleConnection1;

            dataAdapter1.SelectCommand.CommandText = "select * from waiter g where g.waiterid not in (select waiterid from tableorder)";
            dataAdapter1.Fill(ds);
            List<string> list = convertTableToList(ds);
            removewaitercombobox.ItemsSource = list;
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

        private void removeButton_Click(object sender, RoutedEventArgs e)
        {
            string[] branchDetails = removewaitercombobox.SelectedValue.ToString().Split(',');
            string waiterid = branchDetails[0];


            OracleCommand DeleteCommand = new OracleCommand();

            DeleteCommand.Connection = DBSingleton.getConnection();
            
            string deleteR = "delete from waiter where waiterid=" + waiterid;
            DeleteCommand.CommandText = deleteR;

            try
            {
                DeleteCommand.ExecuteNonQuery();
                MessageBox.Show("waiter was deleted succefuly!");
                this.Close();
            }

            catch
            {
                MessageBox.Show("ERROE: waiter was not deleted!");
            }

        }


    }
}
