using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogIn
{
    class DataBaseHelper
    {
        public static string DataSource = "studybuddy.database.windows.net";
        public static string UserID = "admin";
        public static string Password = "studybuddy";
        public static string InitialCatalog = "studybuddy";

        public SqlConnection connection;

        public static DataBaseHelper instance = new DataBaseHelper();
        public DataBaseHelper()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = DataBaseHelper.DataSource;
            builder.UserID = DataBaseHelper.UserID;
            builder.Password = DataBaseHelper.Password;
            builder.InitialCatalog = DataBaseHelper.InitialCatalog;
            builder.MultipleActiveResultSets = true;
            connection = new SqlConnection(builder.ConnectionString);
            connection.Open();

        }
        public SqlDataReader GetSqlDataReader (String query)
        {
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader();
            return reader;
        }
        public void SqlCommandExcecutor (String query)
        {
            SqlCommand command = new SqlCommand(query, connection);
            command.ExecuteNonQuery();
        }

        ~DataBaseHelper()
        {
            connection.Close();
        }

    }

}
