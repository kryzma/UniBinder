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
                var context = new StuddyBuddyEntities();

                context.People.Add(person);
                context.SaveChanges();
            }
        }

    

}
