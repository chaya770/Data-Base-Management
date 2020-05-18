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
    /// Interaction logic for RemoveOrderDish.xaml
    /// </summary>
    public partial class RemoveOrderDish : Window
    {
        DataTable dt;

        string value;

        int numDish;
        int num;
        OracleDataReader dataReader1;

        OracleDataAdapter dataAdapter1;

        OracleConnection oracleConnection1 = DBSingleton.getConnection();

        


        public RemoveOrderDish()
        {
            InitializeComponent();

            //On remplit la combobox de please select a num Order
            if (oracleConnection1 == null || oracleConnection1.State == ConnectionState.Closed)
            {
                oracleConnection1.Open();
            }


            dataAdapter1 = new OracleDataAdapter();

            //attach select command 
            dataAdapter1.SelectCommand = new OracleCommand();
            dataAdapter1.SelectCommand.Connection = oracleConnection1;
            dataAdapter1.SelectCommand.CommandText = "select * from orderr";


            dataReader1 = dataAdapter1.SelectCommand.ExecuteReader(); //Il va executer la query et la mettre ds dataReader
            while (dataReader1.Read())
            {
                num = dataReader1.GetInt32(0);
                orderNumComboBox.Items.Add(num);

            }



        }


        //Juste pour que ca soit visible
        private void Button_Click(object sender, RoutedEventArgs e) //Boutton pour ajouter des dishes a la orderr
        {
            try
            {

                expanderr.Visibility = Visibility.Visible;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }


        private void removeButton_Click(object sender, RoutedEventArgs e)
        {

            OracleCommand InsertCommand = new OracleCommand();
            InsertCommand.Connection = DBSingleton.getConnection();

            string insertC = "delete from dishinorder where ordernum =" + int.Parse(orderNumComboBox.SelectedValue.ToString()) + "& dishnum =" + int.Parse(numDish.ToString()) + ")";
            InsertCommand.CommandText = insertC;


            try
            {
                MessageBox.Show("The Dish was removed to the Order!");
                this.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void orderNumComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            //On remplit la combobox des dishes



            dataAdapter1 = new OracleDataAdapter();

            //attach select command 
            dataAdapter1.SelectCommand = new OracleCommand();
            dataAdapter1.SelectCommand.Connection = oracleConnection1;
            dataAdapter1.SelectCommand.CommandText = "select * from dishinorder where ordernum = " + int.Parse(orderNumComboBox.SelectedValue.ToString());


            dataReader1 = dataAdapter1.SelectCommand.ExecuteReader();
            while (dataReader1.Read())
            {
                numDish = dataReader1.GetInt32(1);
                dishesComboBox.Items.Add(numDish);
            }
        }
    }
}
