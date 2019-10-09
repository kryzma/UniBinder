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
            SqlConnection connection = DataBaseInfo.getSqlConnection();
            connection.Open();
            string personInfoQuerry = "select count (*) from Persons;";
            SqlCommand command = new SqlCommand(personInfoQuerry, connection);
            SqlDataReader reader = command.ExecuteReader();
            reader.Read();
            return reader.GetInt32(0);
        }
        public static int UserID(string name)
        {
            SqlConnection connection = DataBaseInfo.getSqlConnection();
            connection.Open();
            string personInfoQuerry = "select ID from Persons where name = '" + name + "'" ;
            SqlCommand command = new SqlCommand(personInfoQuerry, connection);
            SqlDataReader reader = command.ExecuteReader();
            reader.Read();
            return reader.GetInt32(0);
        }
    }
}
