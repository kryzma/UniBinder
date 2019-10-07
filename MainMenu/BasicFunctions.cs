using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogIn
{
    static class BasicFunctions
    {
        public static int UserCount()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = DataBaseInfo.DataSource;
            builder.UserID = DataBaseInfo.UserID;
            builder.Password = DataBaseInfo.Password;
            builder.InitialCatalog = DataBaseInfo.InitialCatalog;
            SqlConnection connection = new SqlConnection(builder.ConnectionString);
            connection.Open();
            string personInfoQuerry = "select count (*) from Persons;";
            SqlCommand command = new SqlCommand(personInfoQuerry, connection);
            SqlDataReader reader = command.ExecuteReader();
            reader.Read();
            return reader.GetInt32(0);
        }
    }
}
