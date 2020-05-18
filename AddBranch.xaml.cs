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
    /// Interaction logic for AddBranch.xaml
    /// </summary>
    public partial class AddBranch : Window
    {

        DataTable dt;

        string value;


        OracleDataAdapter dataAdapter1;

        OracleConnection oracleConnection1 = DBSingleton.getConnection();

        public AddBranch()
        {
            InitializeComponent();
            this.kashrutcombobox.ItemsSource = Enum.GetValues(typeof(MyEnum.Kashrut));
        }


        private void addbranch_Click(object sender, RoutedEventArgs e)
        {

            oracleConnection1.Open();
            OracleCommand InsertCommand = new OracleCommand();
            InsertCommand.Connection = DBSingleton.getConnection();

            string insertC = "insert into branch (brunchnum,brunchcity,bruncadrees,brunchphone,brunchkashrut) values ( " + branchnumtextbox.Text.ToString() + " ,'" + citytextbox.Text.ToString() + "','" + adresstextbox.Text.ToString() + "','" + telephonetextbox.Text.ToString() + "','" + kashrutcombobox.Text.ToString() + "')";
            InsertCommand.CommandText = insertC;


            try
            {
                InsertCommand.ExecuteNonQuery();
                MessageBox.Show("Branch added!");
                this.Close();


            }
            catch (Exception)
            {
                MessageBox.Show("Error!");
            }



        
        }
    }
}
