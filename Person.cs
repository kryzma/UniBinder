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
        

        static void Main(string[] args)
        {
            //string textFile = "../../data.json";
            DataReader dr = new DataReader();
            dr.UploadData();


        }
        
    }
}
