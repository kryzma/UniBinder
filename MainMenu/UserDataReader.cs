using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogIn
{
    class UserDataReader : IUserDataReader
    {

        public List<Person> ReadUserData()
        {
            return giveUserList();
        }

        private List<Person> giveUserList()
        {
            List<Person> usersList = new List<Person>();
            SqlConnection connection = DataBaseInfo.getSqlConnection();
            connection.Open();
            string personInfoQuerry = givePersonInfoQuerry();
            SqlCommand command = new SqlCommand(personInfoQuerry, connection);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                int ID = reader.GetInt32(0);
                List<Subject> Subjects = givePersonSubjectsList(ID);
                usersList.Add(new Person(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3),
                    reader.GetInt32(4), reader.GetInt32(5), reader.GetInt32(6),
                    reader.GetInt32(7), reader.GetInt32(8), Subjects));
                ImageProcessor imageProcessor = new ImageProcessor();


                if (reader[9].Equals("0"))
                {
                    usersList[ID].image = imageProcessor.defaultImage;
                }
                else
                {
                    usersList[ID].image = imageProcessor.Base64ToImage(reader[9].ToString());
                }
            }
            connection.Close();
            return usersList;

        }
        private string givePersonInfoQuerry()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select * ");
            sb.Append("from Persons ;");
            return sb.ToString();
        }
        private List<Subject> givePersonSubjectsList(int ID)
        {
            List<Subject> subjects = new List<Subject>();
            SqlConnection connection = DataBaseInfo.getSqlConnection();
            connection.Open();
            string SubjectListQuerry = givePersonSubjectListQuerry(ID);
            SqlCommand command = new SqlCommand(SubjectListQuerry, connection);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                subjects.Add(new Subject(reader.GetString(0)));
                System.Console.WriteLine(reader.GetString(0));
            }
            return subjects;
        }
        private string givePersonSubjectListQuerry(int ID)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select Name ");
            sb.Append("from Subjects ");
            sb.Append("where ID = ");
            sb.Append(ID.ToString());
            return sb.ToString();
        }
        private string getUserImageQuerry(int ID)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select Image ");
            sb.Append("from Images ");
            sb.Append("where ID = ");
            sb.Append(ID.ToString());
            return sb.ToString();
        }


    }
}
