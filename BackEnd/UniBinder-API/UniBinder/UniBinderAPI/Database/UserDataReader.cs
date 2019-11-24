using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UniBinderAPI.EntityFramework;
using UniBinderAPI.Models;



namespace UniBinderAPI.Database
{

    class UserDataReader : IUserDataReader
    {
        List<Person> PersonList = new List<Person>();


        public List<Person> ReadUserData()
        {
            using (var context = new UniBinderEF())
            {
                var users = (from a in context.People select a).ToList();
                var usersSubjects = (from a in context.PersonSubjects select a).ToList();

                var groupJoin = users.GroupJoin(usersSubjects,
                per => per.ID,
                sub => sub.PersonID,
                (per, subjectGroup) => new
                {
                    subjectsList = subjectGroup,
                    per.ID,
                    per.Username,
                    per.Password,
                    per.Name,
                    per.Surname,
                    per.Email,
                    per.Role,
                    per.Likes,
                    per.Dislikes,
                    per.ImageLink,

                });

                foreach (var per in groupJoin)
                {
                    var person = new Person
                    {
                        ID = per.ID,
                        Username = per.Username,
                        Password = per.Password,
                        Name = per.Name,
                        Surname = per.Surname,
                        Email = per.Email,
                        Role = per.Role,
                        Likes = per.Likes,
                        Dislikes = per.Dislikes,
                        ImageLink = per.ImageLink,

                        SubjectList = new List<Subject>()
                    };
                    foreach (var sub in per.subjectsList)
                    {
                        var subject = new Subject
                        {
                            Name = sub.Name
                        };
                        person.SubjectList.Add(subject);
                    }
                    PersonList.Add(person);
                }
            }


            return PersonList;

        }

        public List<PersonSubject> PersonSubjects()
        {
            using (var context = new UniBinderEF())
            {
                var personSubjects = (from x in context.PersonSubjects select x).ToList();
                return personSubjects;
            }
        }

        public bool CheckUniqueData(string username, string email)
        {
            using (var context = new UniBinderEF())
            {
                var people = context.People.ToList();
                if (people.Exists(x => x.Username.ToLower() == username.ToLower() || email.ToLower() == x.Email.ToLower()) ) return false;
                else return true;
            }

        }
    }
}

