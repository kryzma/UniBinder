using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace ConsoleApp1
{
    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int ImgId { get; set; }
        //[JsonProperty("list")]
        public List<Subject> Subjects { get; set; }
        static readonly string TextFile = "../../data.json";

        static void Main(string[] args)
        {
            //string textFile = "../../data.json";
            Person l = new Person();
            l.UploadData();


        }
        void UploadData()
        {
            List<Person> people = new List<Person>();
            string jsons = File.ReadAllText(TextFile);
            //string jsonS = @"[{""Name"":""John"",""Age"":25,""Subjects"":[{""Name"":""maths""}]},{""Name"":""j"",""Age"":40,""Subjects"":[{""Name"":""physics""}]}]"; //some testing data in case .json file would not work
            var PersonList = JsonConvert.DeserializeObject<List<Person>>(jsons);

            /*
            List contains deserialized objects from .json file.             
            */

            foreach (var person in PersonList) 
            {
                people.Add(person);
                Console.WriteLine(person.Name);
                Console.WriteLine(person.Age);
                Console.WriteLine(person.Subjects[0].SubjectName);
            }
        }
    }
}
