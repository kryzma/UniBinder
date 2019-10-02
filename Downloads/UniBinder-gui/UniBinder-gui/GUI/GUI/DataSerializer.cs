using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI
{
    class DataSerializer
    {
        public void Serialize(Object obj)
        {
            

            var json = JsonConvert.SerializeObject(ReturnList(obj));

            Console.WriteLine(json);
        }

        private List<Object> ReturnList(Object obj)
            {
            List<Object> PersonList = new List<Object>();
            PersonList.Add(obj);
            return PersonList;
            }


    }
}
