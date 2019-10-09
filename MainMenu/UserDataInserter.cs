using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogIn
{
    class UserDataInserter : IUserDataInserter
    {
        public void sendUserData(Person person)
        {
            string personInfoSubmitionQuerry = givePersonInfoSubmitQuerry(person);
            callQuerry(personInfoSubmitionQuerry);

            foreach(var subject in person.Subjects)
            {
                string personSubjectSubmitQuerry = givePersonSubjectSubmitQuerry(person.ID,subject);
                callQuerry(personSubjectSubmitQuerry);
            }
        }
        private string givePersonInfoSubmitQuerry(Person person)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("insert into Persons ");
            sb.Append("values('" + person.ID + "','" + person.Name + "','" + person.Email + "','" + person.Password + "',0,0,0,0,0,0);");
            System.Windows.Forms.MessageBox.Show(sb.ToString());
            return sb.ToString();
        }
        private string givePersonSubjectSubmitQuerry(int ID,Subject subject)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("insert into subjects ");
            sb.Append("values ( " + ID + ",'" + subject.Name + "');");
            return sb.ToString();
        }
        private void callQuerry(string querry)
        {
            SqlConnection connection = DataBaseInfo.getSqlConnection();
            connection.Open();
            SqlCommand command = new SqlCommand(querry, connection);
            command.ExecuteNonQuery();
            connection.Close();
        }
    }

}
