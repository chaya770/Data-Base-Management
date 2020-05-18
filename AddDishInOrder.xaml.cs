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
    /// Interaction logic for AddDishInOrder.xaml
    /// </summary>
    public partial class AddDishInOrder : Window
    {

        DataTable dt;

        string value;


        OracleDataReader dataReader1;

        OracleDataAdapter dataAdapter1;

        OracleConnection oracleConnection1 = DBSingleton.getConnection();

        int num;

        public AddDishInOrder()
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




            //dishesComboBox

            //On remplit la combobox des dishes
            


            dataAdapter1 = new OracleDataAdapter();

            //attach select command 
            dataAdapter1.SelectCommand = new OracleCommand();
            dataAdapter1.SelectCommand.Connection = oracleConnection1;
            dataAdapter1.SelectCommand.CommandText = "select * from dish";


            dataReader1 = dataAdapter1.SelectCommand.ExecuteReader(); 
            while (dataReader1.Read())
            {
                string name = dataReader1.GetString(1);
                dishesComboBox.Items.Add(name);

                int num = dataReader1.GetInt32(0);


            }

        }




        //Button pour rajouter des dishes a une order
        private void addButton_Click(object sender, RoutedEventArgs e) //boutton add orange
        {

           
            OracleCommand InsertCommand = new OracleCommand();
            InsertCommand.Connection = DBSingleton.getConnection();

            string insertC = "insert into dishinorder (ordernum,dishnum) values ( " + int.Parse(orderNumComboBox.SelectedValue.ToString()) + " ," + int.Parse(num.ToString()) + ")";
            InsertCommand.CommandText = insertC;


            try
            {
                MessageBox.Show("The Dish was added to the Order!");
                this.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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




        private void ordered_DishDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            //attach select command 
            dataAdapter1.SelectCommand = new OracleCommand();
            dataAdapter1.SelectCommand.Connection = oracleConnection1;
            dataAdapter1.SelectCommand.CommandText = "select * from dishinorder where ordernum = " + int.Parse(orderNumComboBox.SelectedValue.ToString());

            //initialize new data table 
            dt = new DataTable();
            dataAdapter1.Fill(dt);

           
            try
            {
                
            }
            catch
            {

            }
        }


      




    }
}
