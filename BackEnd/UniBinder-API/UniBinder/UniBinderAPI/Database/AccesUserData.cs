using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniBinderAPI.Models;

namespace UniBinderAPI.Database
{
    public class AccesUserData
    {
        List<Person> userList;
        public static AccesUserData instance = new AccesUserData();
        private UserDataReader userDataReader;

        private AccesUserData()
        {
            userDataReader = new UserDataReader();
        }
        
        private void UpdateUserList()
        {
            userList = userDataReader.ReadUserData();
        }

        public List<Person> GetUserList()
        {
            if(userList == null)
            {
                UpdateUserList();
            }
            return userList;
        }

    }
}
