using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogIn
{

    public static class ExtensionSQLCheck
    {
        public static void Query(this StringBuilder sb, int ID)
        {
            sb.Append("select Name ");
            sb.Append("from Subjects ");
            sb.Append("where ID = ");
            sb.Append(ID.ToString());
        }
    }

    public class UserDataReader : IUserDataReader
    {

        public List<Person> ReadUserData()
        {
            return GiveUserList();
        }

        private List<Person> GiveUserList()
        {
            List<Person> usersList = new List<Person>();
            SqlDataReader reader = DataBaseHelper.instance.GetSqlDataReader(Properties.Resources.UserDataQuery);

            while (reader.Read())
            {
                int ID = reader.GetInt32(0);
                var Subjects = GetPersonSubjectsList(ID);
                usersList.Add(new Person(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3),
                    reader.GetInt32(4), reader.GetInt32(5), reader.GetInt32(6),
                    reader.GetInt32(7), reader.GetInt32(8), Subjects));
                //ImageProcessor imageProcessor = new ImageProcessor();

                //if (!reader[9].Equals("0"))
                //{
                //    usersList[ID].image = imageProcessor.Base64ToImage(reader[9].ToString());
                //}
                //else
                //{
                //    usersList[ID].image = Properties.Resources.DefaultImage;
                //}
            }
            return usersList;

        }

        private List<Subject> GetPersonSubjectsList(int ID)
        {
            List<Subject> subjects = new List<Subject>();
            SqlDataReader reader = DataBaseHelper.instance.GetSqlDataReader(GivePersonSubjectListQuerry(ID));

            while (reader.Read())
            {
                subjects.Add(new Subject(reader.GetString(0)));
            }
            return subjects;
        }
        private string GivePersonSubjectListQuerry(int ID)
        {
            StringBuilder sb = new StringBuilder();
            sb.Query(ID);
            return sb.ToString();
        }
       
    }
}
