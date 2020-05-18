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
    /// Interaction logic for DishInBranch.xaml
    /// </summary>
    public partial class DishInBranch : Window
    {
        DataTable dt;

        string value;


        OracleDataAdapter dataAdapter1;

        OracleConnection oracleConnection1 = DBSingleton.getConnection();
        public DishInBranch()
        {
            InitializeComponent();

            try
            {
               
                dataAdapter1 = new OracleDataAdapter();
            
                dataAdapter1.SelectCommand = new OracleCommand();

                dataAdapter1.SelectCommand.Connection = oracleConnection1;

                dataAdapter1.SelectCommand.CommandText = "select * from dishinbrunch";

                
                dt = new DataTable();
                dataAdapter1.Fill(dt);

        
                showTableGrid.ItemsSource = dt.DefaultView;

            }
            catch
            { MessageBox.Show("Exception in select dish in branch window"); }
        }
    }
    }

