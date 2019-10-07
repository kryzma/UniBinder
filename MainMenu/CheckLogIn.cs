using System;
using System.Collections.Generic;
using System.IO;


namespace LogIn
{
    public class CheckLogIn
    {
        public Boolean CheckLogInValidity(string nickname, string password)
        {
            AccesUserData accesUserData = new AccesUserData();
            List<LogIn.Person> users = accesUserData.GetUserList();
            foreach (var x in users)
            {
                if (nickname.Equals(x.Name) && password.Equals(x.Password))
                {
                    return true;
                }
            }
            // Couldn't find your account
            return false;
        }
    }
}

