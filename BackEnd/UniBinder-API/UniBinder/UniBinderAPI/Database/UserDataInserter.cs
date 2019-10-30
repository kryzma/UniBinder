using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniBinderAPI.Models;

namespace UniBinderAPI.Database
{
    class UserDataInserter : IUserDataInserter
    {
        public void SendUserData(Person person)
        {
            string personInfoSubmitionQuery = GivePersonInfoSubmitQuerry(person);
            DataBaseHelper.instance.SqlCommandExcecutor(personInfoSubmitionQuery);

            person.Subjects.ForEach((subject) =>
                DataBaseHelper.instance.SqlCommandExcecutor(GivePersonSubjectSubmitQuerry((person.ID), subject)));
        }



        private string GivePersonInfoSubmitQuerry(Person person)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("insert into Persons ");
            sb.Append("values('" + person.ID + "','" + person.Name + "','" + person.Email + "','" + person.Password + "',0,0,0,0,0,0);");
            
            return sb.ToString();
        }
        private string GivePersonSubjectSubmitQuerry(int ID,Subject subject)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("insert into subjects ");
            sb.Append("values ( " + ID + ",'" + subject.Name + "');");
            return sb.ToString();
        }

    }

}
