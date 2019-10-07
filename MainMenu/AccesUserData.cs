using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogIn
{
    class AccesUserData
    {
        List<Person> userList;
        UserDataReader userDataReader = new UserDataReader();
        
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
