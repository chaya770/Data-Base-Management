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
    /// Interaction logic for UpdateOrderDishh.xaml
    /// </summary>
    public partial class UpdateOrderDishh : Window
    {

        DataTable dt;

        string value;

        int numDish;
        int num;
        OracleDataReader dataReader1;

        OracleDataAdapter dataAdapter1;

        OracleConnection oracleConnection1 = DBSingleton.getConnection();

        public UpdateOrderDishh()
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
                updateordercombobox.Items.Add(num);

            }

            //On remplit la 3 eme combobox des dish en general

            dataAdapter1 = new OracleDataAdapter();

            //attach select command 
            dataAdapter1.SelectCommand = new OracleCommand();
            dataAdapter1.SelectCommand.Connection = oracleConnection1;
            dataAdapter1.SelectCommand.CommandText = "select * from dish";


            dataReader1 = dataAdapter1.SelectCommand.ExecuteReader(); //Il va executer la query et la mettre ds dataReader
            while (dataReader1.Read())
            {
                string name = dataReader1.GetString(1);
                int numero = dataReader1.GetInt32(0);
                comboBox.Items.Add(name);
                comboBox.Items.Add(numero);

            }

        }


        //Quand on clique sur le button : Update
        private void updateorder_Click(object sender, RoutedEventArgs e)
        {
            OracleCommand InsertCommand = new OracleCommand();
            InsertCommand.Connection = DBSingleton.getConnection();

            string insertC = "update  dishinorder " +
                "set dishnum = " + int.Parse(comboBox.SelectedValue.ToString())+
                " where ordernum = " + int.Parse(updateordercombobox.SelectedValue.ToString());

            InsertCommand.CommandText = insertC;

            try
            {
                MessageBox.Show("The dish was updated In the Order!");
                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void comboboxdish_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            textBox.Text = comboboxdish.SelectedValue.ToString(); //On mets ds la combobox le dish qu il a choisi

        }


        //Quand on a choisi un numOrder
        private void updateordercombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            //On remplit la combobox des dishes de cette order specifique

            dataAdapter1 = new OracleDataAdapter();

            //attach select command 
            dataAdapter1.SelectCommand = new OracleCommand();
            dataAdapter1.SelectCommand.Connection = oracleConnection1;
            dataAdapter1.SelectCommand.CommandText = "select * from dishinorder where ordernum = " + int.Parse(updateordercombobox.SelectedValue.ToString());


            dataReader1 = dataAdapter1.SelectCommand.ExecuteReader();
            while (dataReader1.Read())
            {
                numDish = dataReader1.GetInt32(1);
                comboboxdish.Items.Add(numDish);
            }
        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
