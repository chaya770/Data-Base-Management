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
    /// Interaction logic for Functions.xaml
    /// </summary>
    public partial class Functions : Window
    {
        DataTable dt;
        string value;


        OracleDataAdapter dataAdapter1;

        OracleCommand callProcCommand;
        OracleCommand callFuncComm;

        OracleDataReader dataReader1;

        OracleConnection oracleConnection1 = DBSingleton.getConnection();

        List<String> listFunctions = new List<String>();
        public Functions()
        {
            InitializeComponent();

            oracleConnection1.Open();
            listFunctions.Add("Function 1");
            listFunctions.Add("Function 2");

            for (int i = 0; i < listFunctions.Count; i++)
            {
                comboBox.Items.Add(listFunctions[i]);
            }



        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(comboBox.SelectedIndex == 0)//Function 1
            {
                
            }

            else if(comboBox.SelectedIndex == 1) //Function 2
            {

            }
        }

        private void calcul_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                callFuncComm = new OracleCommand();
                callFuncComm.Connection = oracleConnection1;

                callFuncComm.CommandType = CommandType.StoredProcedure;
                callFuncComm.CommandText = "changePriceDish";

                callFuncComm.Parameters.Add("IDish", OracleType.Number).Value = int.Parse(numberDish.Text.ToString());
                callFuncComm.Parameters.Add("Amount", OracleType.Number).Value = int.Parse(amount.Text.ToString());

                callFuncComm.Parameters.Add("Result", OracleType.Number).Direction = ParameterDirection.ReturnValue;
                callFuncComm.ExecuteNonQuery();

                this.result.Text = callFuncComm.Parameters["Result"].Value.ToString();

            }


            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
       
        }
    }
}
