using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace GUI
{
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int ImgId { get; set; }
        public int HelpScore { get; set; }
        public int Likes { get; set; }
        public int Dislikes { get; set; }
        public int PeopleHelped { get; set; }
        //[JsonProperty("list")]
        public List<Subject> Subjects { get; set; }
        
    }
}
