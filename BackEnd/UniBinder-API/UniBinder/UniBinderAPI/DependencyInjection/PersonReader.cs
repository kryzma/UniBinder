using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniBinderAPI.Database;
using UniBinderAPI.EntityFramework;

namespace UniBinderAPI.DependencyInjection
{
    public class PersonReader : IPersonReader
    {
        UserDataReader userDataReader = new UserDataReader();

        public List<Person> GetAllPeople()
        {
            return userDataReader.ReadUserData();
        }



    }
}