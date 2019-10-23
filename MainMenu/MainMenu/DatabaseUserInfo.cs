using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogIn
{
    static class DatabaseUserInfo
    {
        public static int UserCount()
        {
            SqlDataReader reader = DataBaseHelper.instance.GetSqlDataReader("select count (*) from Persons;");
            reader.Read();
            return reader.GetInt32(0);
        }
        public static int GetUserIDFromName(string name)
        {
            SqlDataReader reader = DataBaseHelper.instance.GetSqlDataReader("select ID from Persons where name = '" + name + "'");
            reader.Read();
            return reader.GetInt32(0);
        }

        public static string  GetUserNameFromId(int ID)
        {
            SqlDataReader reader = DataBaseHelper.instance.GetSqlDataReader("select name from Persons where ID ='" + ID + "'");
            reader.Read();
            return reader.GetString(0);
        }
    }
}
