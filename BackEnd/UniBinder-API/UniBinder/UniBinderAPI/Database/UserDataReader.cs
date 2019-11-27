using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
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
                person => person.ID,
                sub => sub.PersonID,
                (person, subjectGroup) => new
                {
                    subjectsList = subjectGroup,
                    person.ID,
                    person.Username,
                    person.Password,
                    person.Name,
                    person.Surname,
                    person.Email,
                    person.Role,
                    person.Likes,
                    person.Dislikes,
                    person.ImageLink,
                });

                foreach (var p in groupJoin)
                {
                    var person = new Person
                    {
                        ID = p.ID,
                        Username = p.Username,
                        Password = p.Password,
                        Name = p.Name,
                        Surname = p.Surname,
                        Email = p.Email,
                        Role = p.Role,
                        Likes = p.Likes,
                        Dislikes = p.Dislikes,
                        ImageLink = p.ImageLink,
                        SubjectList = new List<Subject>()
                    };
                    foreach (var sub in p.subjectsList)
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

        public int PeopleNumber()
        {
            using (var context = new UniBinderEF())
            {
                return (from people in context.People select people).Count();
            }
        }


    }
}

