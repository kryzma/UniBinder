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
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniBinderAPI.EntityFramework;



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
                    var matchedPeople = (from a in context.MatchedPeoples select a).ToList();
                    //var person = matchedPeople.First();



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
                        foreach (var per in PersonList)
                        {
                            per.Matches = (from a in matchedPeople
                                           where per.ID.Equals(a.FirstPersonID) || per.ID.Equals(a.SecondPersonID)
                                           select (Guid)a.SecondPersonID).ToList();
                        }
                    PersonList.Add(person);
                    }
                }

            var check = PersonList;
            var check2 = PersonList.Count();
                return PersonList;
            }


            public int PeopleNumber()
        {
            using (var context = new UniBinderEF())
            {
                return (from people in context.People select people).Count();
            }
        }

        public List<Guid?> MatchList(Guid userID)
        {
            var matches = new List<Guid?>();
            using (var context = new UniBinderEF())
            {
                var allMatches = context.MatchedPeoples.Where(match => match.FirstPersonID == userID).Select(match => match.SecondPersonID).ToList();
                matches = allMatches;
                return matches;
            }
        }

        public List<Guid?> PeopleWithSameSubjects(Guid personID)
        {
            List<Person> people = new List<Person>();
            var IDMatchedBySubjects = new List<Guid?>();
            //var IDMatchedBySubjects = new List<Guid>();

            using (var context = new UniBinderEF())
            {
                var matches = MatchList(personID);
                //List<string> subjects = new List<string>();

                var subjects = context.PersonSubjects.Where(personSubject => personSubject.PersonID == personID)
                                                     .Select(personSubject => personSubject.Name).ToList();



                foreach (var subjectName in subjects)
                {
                    var PeopleWithSameSubject = context.PersonSubjects.Where(personSubject => personSubject.Name == subjectName && personSubject.PersonID != personID)
                                                                      .Select(personSubject => personSubject.PersonID).ToList();
                    foreach (var item in PeopleWithSameSubject)
                    {
                        if (IDMatchedBySubjects.Contains(item) || matches.Contains(item)) continue;
                        IDMatchedBySubjects.Add(item);
                    }
                }

            }
            return IDMatchedBySubjects;
        }

        public List<string> SubjectList()
        {
            using (var context = new UniBinderEF())
            {
                return context.Subjects.Select(x => x.Name).ToList();
            }
        }

        public List<PersonSubject> PersonSubjects()
        {
            using (var context = new UniBinderEF())
            {
                var personSubjects = (from x in context.PersonSubjects select x).ToList();
                return personSubjects;
            }
        }


        public List<string> SubjectsPersonHas(Guid personID)
        {
            using (var context = new UniBinderEF())
            {
                var subjects = context.PersonSubjects.Where(subject => subject.PersonID == personID)
                                                     .Select(subject => subject.Name).ToList();
                return subjects;
            }
        }









    }


}

