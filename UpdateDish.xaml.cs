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
    /// Interaction logic for UpdateDish.xaml
    /// </summary>
    public partial class UpdateDish : Window
    {
        DataTable dt;
        string value;


        OracleDataAdapter dataAdapter1;

        OracleDataReader dataReader1;

        OracleConnection oracleConnection1 = DBSingleton.getConnection();


        public UpdateDish()
        {
            InitializeComponent();

            //We initialize the combobox

            if (oracleConnection1 == null || oracleConnection1.State == ConnectionState.Closed)
            {
                oracleConnection1.Open();
            }


            dataAdapter1 = new OracleDataAdapter();

            //attach select command 
            dataAdapter1.SelectCommand = new OracleCommand();
            dataAdapter1.SelectCommand.Connection = oracleConnection1;
            dataAdapter1.SelectCommand.CommandText = "select * from dish";


            dataReader1 = dataAdapter1.SelectCommand.ExecuteReader(); //Il va executer la query et la mettre ds dataReader
            while (dataReader1.Read())
            {
                int num = dataReader1.GetInt32(0);
                updatedishcombobox.Items.Add(num);

            }

            this.sizecomboBox.ItemsSource = Enum.GetValues(typeof(MiniProjectGui.MyEnum.Size)); //Combobox for size
            this.categorycomboBox.ItemsSource = Enum.GetValues(typeof(MiniProjectGui.MyEnum.Category)); //Combobox for category

        }



        private void updatedish_Click(object sender, RoutedEventArgs e)
        {

            OracleCommand InsertCommand = new OracleCommand();
            InsertCommand.Connection = DBSingleton.getConnection();

            string insertC = "update  dish " +
                "set dishname = " + dishName.Text.ToString()+"," +
                 "dishsize =" + sizecomboBox.SelectedValue.ToString() + "," +
                 "price = "+ int.Parse( dishPrice.Text.ToString()) + "," +
                 "category = "+   categorycomboBox.SelectedValue.ToString()
                +" where dishnum = " + int.Parse(updatedishcombobox.SelectedValue.ToString());
            InsertCommand.CommandText = insertC;


            try
            {
                MessageBox.Show("The dish was updated!");
                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

       

        private void updatedishcombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Le clent rentre les fields lui meme car c est un update

        }


   
    }
}
