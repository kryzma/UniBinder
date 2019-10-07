using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;

namespace LogIn
{
    public class Person
    {

        public int ID { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public int HelpScore { get; set; }
        public int Likes { get; set; }
        public int Dislikes { get; set; }
        public int PeopleHelped { get; set; }
        public List<Subject> Subjects { get; set; }

        public Person(int ID, string Name, string Password, string Email)
        {
            this.ID = ID;
            this.Name = Name;
            this.Password = Password;
            this.Email = Email;
            this.Age = 0;
            this.HelpScore = 0;
            this.Likes = 0;
            this.Dislikes = 0;
            this.PeopleHelped = 0;
            this.Subjects = new List<Subject> { };
        }
        public Person(int ID, string Name, string Password, string Email,
            int Age,int HelpScore,int Likes,int Dislikes,int PeopleHelped, List<Subject> Subjects)
        {
            this.ID = ID;
            this.Name = Name;
            this.Password = Password;
            this.Email = Email;
            this.Age = Age;
            this.HelpScore = HelpScore;
            this.Likes = Likes;
            this.Dislikes = Dislikes;
            this.PeopleHelped = PeopleHelped;
            this.Subjects = Subjects;
        }

    }
}