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
        public void SendUserData(Person person)
        {
            var context = new studybuddyEntities();

            context.Person.Add(person);
            context.SaveChanges();
        }
    }

}
