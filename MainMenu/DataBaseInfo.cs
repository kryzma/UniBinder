using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogIn
{
    static class DataBaseInfo
    {
        public static string DataSource = "studybuddy.database.windows.net";
        public static string UserID = "notadmin";
        public static string Password = "buddystudy123?";
        public static string InitialCatalog = "studybuddy";
        public static SqlConnection getSqlConnection()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = DataBaseInfo.DataSource;
            builder.UserID = DataBaseInfo.UserID;
            builder.Password = DataBaseInfo.Password;
            builder.InitialCatalog = DataBaseInfo.InitialCatalog;
            return new SqlConnection(builder.ConnectionString);

        }
    }

}
