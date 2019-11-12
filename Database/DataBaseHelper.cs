using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniBinderAPI.Database
{
    class DataBaseHelper
    {

        public static string dataSource = "studybuddy.database.windows.net";
        public static string userID = "notadmin";
        public static string password = "321?studybuddy";
        public static string initialCatalog = "studybuddy";


        public SqlConnection connection;

        public static DataBaseHelper instance = new DataBaseHelper();
        public DataBaseHelper()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = DataBaseHelper.dataSource;
            builder.UserID = DataBaseHelper.userID;
            builder.Password = DataBaseHelper.password;
            builder.InitialCatalog = DataBaseHelper.initialCatalog;
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
