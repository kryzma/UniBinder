using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace LogIn
{
    public class CheckLogIn
    {
        public Boolean CheckLogInValidity(string nickname, string password)
        {
            List<LogIn.Person> users = AccesUserData.instance.GetUserList();
            return users.Any((user)=> nickname.Equals(user.Name) && password.Equals(user.Password));
            // Without LINQ
            //return users.Exists((user) => nickname.Equals(user.Name) && password.Equals(user.Password));
        }
    }
}

