using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniBinderAPI.EntityFramework;
using UniBinderAPI.Models;

namespace UniBinderAPI.Database
{

        class UserDataInserter : IUserDataInserter
        {
            public void SendUserData(Person person)
            {
                using (UniBinderEF context = new UniBinderEF())
                {
                    context.People.Add(person);
                    context.SaveChanges();
                }   
            }
        }

    

}
