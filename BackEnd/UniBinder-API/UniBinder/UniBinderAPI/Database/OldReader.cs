using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniBinderAPI.Database
{
    public class OldReader
    {
        public static int UserCount()
        {
            SqlDataReader reader = DataBaseHelper.instance.GetSqlDataReader("select count (*) from Persons;");
            reader.Read();
            return reader.GetInt32(0);
        }
    }
}