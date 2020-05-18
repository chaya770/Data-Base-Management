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
    /// Interaction logic for TableOrder.xaml
    /// </summary>
    public partial class TableOrder : Window
    {

        DataTable dt;

        string value;


        OracleDataAdapter dataAdapter1;

        OracleConnection oracleConnection1 = DBSingleton.getConnection();

        public TableOrder()
        {
            InitializeComponent();
            try
            {
                //create new instance for dataAdapter
                dataAdapter1 = new OracleDataAdapter();

                //attach select command 
                dataAdapter1.SelectCommand = new OracleCommand();
                dataAdapter1.SelectCommand.Connection = oracleConnection1;
                dataAdapter1.SelectCommand.CommandText = "select * from tableorder";

                //initialize new data table 
                dt = new DataTable();
                dataAdapter1.Fill(dt);

                //show
                tableorderDataGrid.ItemsSource = dt.DefaultView;
            }

            catch (Exception ex)
            {
                MessageBox.Show("Exception");
            }
        }
    }
}
