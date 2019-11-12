using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniBinderAPI.Models;

namespace UniBinderAPI.Database
{

    class UserDataReader : IUserDataReader
    {
        List<Person> PersonList = new List<Person>();

        public List<Person> GetUserList()
        {
            if (PersonList.Count == 0)
            {
                return ReadUserData();
            }
            else
            {
                return PersonList;
            }
        }
        public List<Person> ReadUserData()
        {
            using (studybuddyEntities context = new studybuddyEntities())
            {

                var groupjoin = from a in context.person
                                orderby a.ID
                                join b in personSubject
                                on a.ID equals b.ID into subjectGroup
                                select new
                                {
                                    ID = a.ID,
                                    Name = a.Name,
                                    Password = a.password,
                                    Email = a.Email,
                                    Age = a.Age,
                                    HelpScore = a.HelpScore,
                                    Likes = a.Likes,
                                    Dislikes = a.Dislikes,
                                    PeopleHelped = a.PeopleHelped,
                                    Image = a.Image,
                                    SubjectList = subjectGroup,
                                };
                foreach (var user in groupJoin)
                {
                    Person person = new Person();
                    person.ID = a.ID;
                    person.Name = a.Name;
                    person.Password = a.password;
                    person.Email = a.Email;
                    person.Age = a.Age;
                    person.HelpScore = a.HelpScore;
                    person.Likes = a.Likes;
                    person.Dislikes = a.Dislikes;
                    person.PeopleHelped = a.PeopleHelped;
                    person.Image = a.Image;
                    foreach(var subject in user.SubjectList)
                    {
                        person.SubjectList.add(new Subject(subject.name));
                    }
                    PersonList.Add(person);
                }
            }
            return PersonList;
        }

        public bool CheckUniqueData(string username, string email)
        {
            using (studybuddyEntities context = new studybuddyEntities())
            {
                var result = (from a in context.Person
                              where username.ToLower() == a.Name.ToLower()
                              select a.Name);

                if (result != null) return false;

                result = (from a in context.Person
                              where email.ToLower() == a.Email.ToLower()
                              select a.Email);

                if (result != null) return false;
                return true;
            }
        }

        List<Person> IUserDataReader.ReadUserData()
        {
            throw new NotImplementedException();
        }
    }
}
