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
    /// Interaction logic for Querys.xaml
    /// </summary>
    /// 

    public partial class Querys : Window
    {
        DataTable dt;
        string value;


        OracleDataAdapter dataAdapter1;

        OracleDataReader dataReader1;

        OracleConnection oracleConnection1 = DBSingleton.getConnection();

        List<String> listQuery = new List<String>();

        public Querys()
        {
            InitializeComponent();

            listQuery.Add("Return the Price and the Number of Dishes of an order");
            listQuery.Add("Returns all the details of the orders of a given date");

           for(int i = 0;i<listQuery.Count;i++)
            {
                comboBox.Items.Add(listQuery[i]);
            }

            //On remplit la combobox de please select a num Order
            oracleConnection1.Open();


            dataAdapter1 = new OracleDataAdapter();

            //attach select command 
            dataAdapter1.SelectCommand = new OracleCommand();
            dataAdapter1.SelectCommand.Connection = oracleConnection1;
            dataAdapter1.SelectCommand.CommandText = "select * from orderr";


            dataReader1 = dataAdapter1.SelectCommand.ExecuteReader(); //Il va executer la query et la mettre ds dataReader
            while (dataReader1.Read())
            {
                int num = dataReader1.GetInt32(0);
                orderCombobox.Items.Add(num);

            }



        }


        //Une fois qu on a choisi une query de la combobox
        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            

            if (comboBox.SelectedIndex == 0)
            {
                

                //create new instance for dataAdapter
                dataAdapter1 = new OracleDataAdapter();

                //attach select command 
                dataAdapter1.SelectCommand = new OracleCommand();
                dataAdapter1.SelectCommand.Connection = oracleConnection1;
                dataAdapter1.SelectCommand.CommandText = "select DI.ORDERNUM,sum(D.PRICE),count(DI.DISHNUM) from orderr O join dishinorder DI on O.ORDERNUM = DI.ORDERNUM join dish D on D.DISHNUM = DI.DISHNUM where DI.ORDERNUM = " +
                 int.Parse(orderCombobox.SelectedValue.ToString()) +  " group by DI.ORDERNUM order by DI.ORDERNUM";

                //initialize new data table 
                dt = new DataTable();
                dataAdapter1.Fill(dt);

                //show
                dataGrid.ItemsSource = dt.DefaultView;
            }

            else if(comboBox.SelectedIndex == 1)
            {


                //create new instance for dataAdapter
                dataAdapter1 = new OracleDataAdapter();

                //attach select command 
                dataAdapter1.SelectCommand = new OracleCommand();
                dataAdapter1.SelectCommand.Connection = oracleConnection1;
                dataAdapter1.SelectCommand.CommandText = "select DI.ORDERNUM,O.CUSTOMERNAME,O.ORDERDATE,D.DISHNUM,D.DISHNAME,D.DISHSIZE,D.PRICE,D.CATEGORY from orderr O join dishinorder DI on O.ORDERNUM = DI.ORDERNUM join dish D on D.DISHNUM = DI.DISHNUM where O.ORDERDATE = '" +
                orderDate.Text.ToString() + "' " + "order by DI.ORDERNUM";

                //initialize new data table 
                dt = new DataTable();
                dataAdapter1.Fill(dt);

                //show
                dataGrid.ItemsSource = dt.DefaultView;




            }

        }
    }
}
