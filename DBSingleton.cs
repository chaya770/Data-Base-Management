using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Text;

namespace MiniProjectGui
{
    class DBSingleton
    {
        private static OracleConnection oracleConnection1 = null;
        public static OracleConnection getConnection()
        {
            if (oracleConnection1 == null || oracleConnection1.State == ConnectionState.Closed)
            {
                OracleConnectionStringBuilder myCStringB = new OracleConnectionStringBuilder();
                myCStringB.UserID = "system";
                myCStringB.Password = "Tigresse18";
                myCStringB.DataSource = "XE";
                oracleConnection1 = new OracleConnection(myCStringB.ConnectionString);
            }
            return oracleConnection1;
        }
    }
}
