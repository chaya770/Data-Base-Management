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
    /// Interaction logic for UpdateBranch.xaml
    /// </summary>
    public partial class UpdateBranch : Window
    {

        DataSet ds;


        string value;


        OracleDataAdapter dataAdapter1;

        OracleDataReader dataReader1;

        OracleConnection oracleConnection1 = DBSingleton.getConnection();

        public UpdateBranch()
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
            updatebranchcombobox.ItemsSource = list;
            this.kashrutComboBox.ItemsSource = Enum.GetValues(typeof(MyEnum.Kashrut));
        }

        private List<string> convertTableToList(DataSet ds)
        {
            List<string> list = new List<string>();
            foreach (DataRow dtrow in ds.Tables[0].Rows)
            {
                list.Add(dtrow.ItemArray[0].ToString() + "," + dtrow.ItemArray[1].ToString() + "," + dtrow.ItemArray[2].ToString() + "," + dtrow.ItemArray[3].ToString() + "," + dtrow.ItemArray[4].ToString());
            }
            return list;
        }


        private void updatebranchcombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string[] branchDetails = updatebranchcombobox.SelectedValue.ToString().Split(',');
            string branchnum = branchDetails[0];
            string brancity = branchDetails[1];
            string branchadress = branchDetails[2];
            string branchkashrut = branchDetails[4];
            string branchphone = branchDetails[3];
            adressBranchTextBox.Text = branchadress;
            cityTextBox.Text = brancity;
            telephoneBranchTextBox.Text = branchphone;
            kashrutComboBox.Text = branchkashrut;
        }


        private void updatebranch_Click(object sender, RoutedEventArgs e)
        {

            string[] branchDetails = updatebranchcombobox.SelectedValue.ToString().Split(',');
            string branchnum = branchDetails[0];


            OracleCommand UpdateCommand = new OracleCommand();

            UpdateCommand.Connection = DBSingleton.getConnection();
            // UPDATE branch set brunchcity = 'givataym', brunchadress = 'hagiva 44', brunchphone = '043356577', brunchkashrut = 'mehadrin' where brunchnum = '5'
            string updateB = "UPDATE branch set brunchcity ='" + cityTextBox.Text.ToString() + "', brunchadress = '" + adressBranchTextBox.Text.ToString() + "', brunchphone = '" + telephoneBranchTextBox.Text.ToString() + "', brunchkashrut = '" + kashrutComboBox.Text.ToString() + "' where brunchnum = '" + branchnum + "'";
            UpdateCommand.CommandText = updateB;

            try
            {
                UpdateCommand.ExecuteNonQuery();
                MessageBox.Show("branch was update succefuly!");
            }
            catch { MessageBox.Show("ERROE: branch was not update!"); }

        }
    }
}
