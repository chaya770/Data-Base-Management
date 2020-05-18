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
    /// Interaction logic for UpdateDishInBranch.xaml
    /// </summary>
    public partial class UpdateDishInBranch : Window
    {
        DataSet ds;
        string value;

        OracleDataAdapter dataAdapter1;
        OracleConnection oracleConnection1 = DBSingleton.getConnection();
        public UpdateDishInBranch()
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
            updatedishinbranchcombobox.ItemsSource = list;
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

        private void updatedishinbranchcombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {


            string[] branchDetails = updatedishinbranchcombobox.SelectedValue.ToString().Split(',');
            string branchnum = branchDetails[0];
            string dishnum = branchDetails[1];

            dishnumberTextBox.Text = dishnum;

            branchnumberTextBox.Text = branchnum;

        }

        private void updatedishinbranch_Click(object sender, RoutedEventArgs e)
        {
            string[] branchDetails = updatedishinbranchcombobox.SelectedValue.ToString().Split(',');
            string branchnum = branchDetails[0];
            string dishnum = branchDetails[1];

            OracleCommand UpdateCommand = new OracleCommand();

            UpdateCommand.Connection = DBSingleton.getConnection();
            // UPDATE branch set brunchcity = 'givataym', brunchadress = 'hagiva 44', brunchphone = '043356577', brunchkashrut = 'mehadrin' where brunchnum = '5'
            string updateB = "UPDATE dishinbrunch set brunchnum ='" + branchnumberTextBox.Text.ToString() + "', dishnum = '" + dishnumberTextBox.Text.ToString() + "' where brunchnum = '" + branchnum + "' and dishnum='" + dishnum + "'";
            UpdateCommand.CommandText = updateB;

            try
            {
                UpdateCommand.ExecuteNonQuery();
                MessageBox.Show("dish in branch was update succefuly!");
            }
            catch { MessageBox.Show("ERROE: dish  in branch was not update!"); }

        }
    }
}
