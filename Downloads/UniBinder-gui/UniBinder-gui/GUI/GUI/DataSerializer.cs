using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI
{
    class DataSerializer
    {
        public void Serialize(Person obj)
        {
            String TextFile = "../../data.json";
            string jsons = File.ReadAllText(TextFile);
            //List<Person> TempList = new List<Person>();
            var TempList = JsonConvert.DeserializeObject<List<Person>>(jsons);
            TempList.Add(obj);
            //var json = JsonConvert.SerializeObject(ReturnPersonList(obj));
            var convertedJson = JsonConvert.SerializeObject(TempList, Formatting.Indented);
            Console.WriteLine(convertedJson);
            System.IO.File.WriteAllText("../../data.json", convertedJson);
        }

        private List<Object> ReturnPersonList(Object obj)
        {
            List<Object> PersonList = new List<Object>();
            PersonList.Add(obj);
            return PersonList;
        }

        private void AddLatestObjectToJson()
        {

        }

    }
}
