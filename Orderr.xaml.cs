﻿using System;
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
    /// Interaction logic for Orderr.xaml
    /// </summary>
    public partial class Orderr : Window
    {

        DataTable dt;

        string value;


        OracleDataAdapter dataAdapter1;

        OracleConnection oracleConnection1 = DBSingleton.getConnection();


       

        public Orderr()
        {
            InitializeComponent();

         

            try
            {


                //   if (oracleConnection1 == null || oracleConnection1.State == ConnectionState.Closed)
                //{
                //    oracleConnection1.Open();
                //}

                //create new instance for dataAdapter
                dataAdapter1 = new OracleDataAdapter();

                //attach select command 
                dataAdapter1.SelectCommand = new OracleCommand();
                dataAdapter1.SelectCommand.Connection = oracleConnection1;
                dataAdapter1.SelectCommand.CommandText = "select * from orderr";

                //initialize new data table 
                dt = new DataTable();
                dataAdapter1.Fill(dt);

                //show
                orderDataGrid.ItemsSource = dt.DefaultView ;
            }

            catch(Exception ex)
            {
                MessageBox.Show("Exception");
            }
        }

    

        private void Select_Click(object sender, RoutedEventArgs e)
        {

        }

    }
}
