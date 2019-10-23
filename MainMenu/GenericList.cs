using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogIn
{
    class GenericList
    {
        public void DisplayValue<T> (string message, T value)
        {
            Console.WriteLine("{0} : {1}", message, value);
        }
    }
}
