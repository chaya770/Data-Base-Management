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
    /// Interaction logic for RemoveDish.xaml
    /// </summary>
    public partial class RemoveDish : Window
    {

        DataTable dt;
        

        string value;


        OracleDataAdapter dataAdapter1;

        OracleDataReader dataReader1;

        OracleConnection oracleConnection1 = DBSingleton.getConnection();


        public RemoveDish()
        {


            InitializeComponent();


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
                removedishcombobox.Items.Add(num);

            }
   

        }



    


        private void removedish_Click(object sender, RoutedEventArgs e)
        {
            
           
            OracleCommand InsertCommand = new OracleCommand();
            InsertCommand.Connection = DBSingleton.getConnection();

            string insertC = "delete from dish where dishnum = " + int.Parse(removedishcombobox.SelectedValue.ToString());
            InsertCommand.CommandText = insertC;

            try
            {
               
                MessageBox.Show("The Dish was Removed!");
                this.Close();
             
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void removedishcombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
            
            string str1 = "select * from dish where dishnum = " + int.Parse(removedishcombobox.SelectedValue.ToString());
          
            //attach select command 
            dataAdapter1.SelectCommand = new OracleCommand();
            dataAdapter1.SelectCommand.Connection = oracleConnection1;
            dataAdapter1.SelectCommand.CommandText = str1;


            dataReader1 = dataAdapter1.SelectCommand.ExecuteReader(); //Il va executer la query et la mettre ds dataReader
            while (dataReader1.Read())
            {
                string name = dataReader1.GetString(1);
                dishName.Text = name;

                string size = dataReader1.GetString(2);
                dishSize.Text = size;

                int price = dataReader1.GetInt32(3);
                dishPrice.Text = price.ToString();

                string category = dataReader1.GetString(4);
                dishCategory.Text = category;

            }

        }
    }
}
