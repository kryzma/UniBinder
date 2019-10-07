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
            SqlConnectionStringBuilder builder = connectionToDatabaseFormating();
            string personInfoSubmitionQuerry = givePersonInfoSubmitQuerry(person);
            callQuerry(builder,personInfoSubmitionQuerry);

            foreach(var subject in person.Subjects)
            {
                string personSubjectSubmitQuerry = givePersonSubjectSubmitQuerry(person.ID,subject);
                callQuerry(builder, personSubjectSubmitQuerry);
            }
        }
        private SqlConnectionStringBuilder connectionToDatabaseFormating()
        {
            var builder = new SqlConnectionStringBuilder();
            builder.DataSource = DataBaseInfo.DataSource;
            builder.UserID = DataBaseInfo.UserID;
            builder.Password = DataBaseInfo.Password;
            builder.InitialCatalog = DataBaseInfo.InitialCatalog;
            return builder;
        }
        private string givePersonInfoSubmitQuerry(Person person)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("insert into Persons ");
            sb.Append("values('" + person.ID + "','" + person.Name + "','" + person.Email + "','" + person.Password + "',0,0,0,0,0);");
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
        private void callQuerry(SqlConnectionStringBuilder builder,string querry)
        {
            SqlConnection connection = new SqlConnection(builder.ConnectionString);
            connection.Open();
            SqlCommand command = new SqlCommand(querry, connection);
            command.ExecuteNonQuery();
        }
    }

}
