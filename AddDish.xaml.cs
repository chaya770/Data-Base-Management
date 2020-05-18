using System;
using System.Collections.Generic;
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
using System.Data;
using System.Data.OracleClient;


namespace MiniProjectGui
{
    /// <summary>
    /// Interaction logic for AddDish.xaml
    /// </summary>
    public partial class AddDish : Window
    {

        DataTable dt;

        string value;


        OracleDataAdapter dataAdapter1;

        OracleConnection oracleConnection1 = DBSingleton.getConnection();




        public AddDish()
        {
            InitializeComponent();


            this.SizeCombobox.ItemsSource = Enum.GetValues(typeof(MiniProjectGui.MyEnum.Size)); //Combobox for size
            this.CategoryCombobox.ItemsSource = Enum.GetValues(typeof(MiniProjectGui.MyEnum.Category)); //Combobox for category
        }

        private void addDishButton_Click(object sender, RoutedEventArgs e)
        {


            if (oracleConnection1 == null || oracleConnection1.State == ConnectionState.Closed)
            {
                oracleConnection1.Open();
            }


            OracleCommand InsertCommand = new OracleCommand();
            InsertCommand.Connection = DBSingleton.getConnection();
          
            string insertC = "insert into dish (dishnum,dishname,dishsize,price,category) values ( " + int.Parse(dishNum.Text) + " ,'" + dishName.Text.ToString() + " ','" + SizeCombobox.SelectedValue.ToString() + " '," + int.Parse(pricetextbox.Text) + " ,'" + CategoryCombobox.SelectedValue.ToString() +  "')";
            InsertCommand.CommandText = insertC;


            try
            {
                InsertCommand.ExecuteNonQuery();
                MessageBox.Show("dish added!");
                this.Close();
               

            }
            catch (Exception)
            {
                MessageBox.Show("Error!");
            }

        }



    

    }
}
