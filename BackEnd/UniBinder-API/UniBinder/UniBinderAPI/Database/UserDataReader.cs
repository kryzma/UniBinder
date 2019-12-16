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



                var groupJoin = users.GroupJoin(usersSubjects,
                    person =>
                    {
                        if (person is null)
                        {
                            throw new ArgumentNullException(nameof(person));
                        }

                        return person.ID;
                    },
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

        public Person GetPeopleByID(Guid guid)
        {
            //List<Person> people = new List<Person>();
            using (var context = new UniBinderEF())
            {
                var person = context.People.Where(x => x.ID == guid).FirstOrDefault();
                return person;
            }
        }

        public List<Guid> GetAllPeopleID()
        {
            using (var context = new UniBinderEF())
            {
                return context.People.Select(x => x.ID).ToList();
            }
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
            var IDMatchedBySubjects = new List<Guid?>();
            var matches = MatchList(personID);

            using (var context = new UniBinderEF())
            {
                var subjects = context.PersonSubjects.Where(personSubject => personSubject.PersonID == personID)
                                                     .Select(personSubject => personSubject.Name).ToList();

                var query = (from c in context.People
                             join b in context.PersonSubjects on new { ID = c.ID } equals new { ID = b.PersonID }
                             where
                               c.ID != new Guid(personID.ToString()) &&
                                 (from PersonSubjects in context.PersonSubjects
                                  where
                        PersonSubjects.PersonID == new Guid(personID.ToString())
                                  select new
                                  {
                                      PersonSubjects.Name
                                  }).Contains(new { Name = b.Name }) &&
                               !
                                 (from x in context.MatchedPeoples
                                  join z in context.People on new { FirstPersonID = (Guid)x.FirstPersonID } equals new { FirstPersonID = z.ID }
                                  where
                                        x.FirstPersonID == z.ID
                                  select new
                                  {
                                      x.SecondPersonID
                                  }).Contains(new { SecondPersonID = (Guid?)c.ID })
                             select new
                             {
                                 c.ID
                             }).Distinct().ToList();

                if (!subjects.Any()) return null;

                //foreach (var subjectName in subjects)
                //{
                //    var PeopleWithSameSubject = context.PersonSubjects.Where(personSubject => personSubject.Name == subjectName && personSubject.PersonID != personID)
                //                                                      .Select(personSubject => personSubject.PersonID).ToList();
                //    foreach (var item in PeopleWithSameSubject)
                //    {
                //        if (IDMatchedBySubjects.Contains(item) || matches.Contains(item)) continue;
                //        IDMatchedBySubjects.Add(item);
                //    }
                //}
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

