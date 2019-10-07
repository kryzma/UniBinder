using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogIn
{
    interface IUserDataInserter
    {
        void sendUserData(Person person);
    }
}
