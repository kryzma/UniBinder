using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniBinderAPI.EntityFramework;
using UniBinderAPI.Models;

namespace UniBinderAPI.Database
{

    class UserDataInserter : IUserDataInserter
    {
        Lazy<UserDataReader> _reader = new Lazy<UserDataReader>();

        public void SendUserData(Person person)
        {
            using (var context = new UniBinderEF())
            {
                context.People.Add(person);
                context.SaveChanges();
            }   
        }

        public void AddSubjects(PersonSubject personSubject)
        {
            using(var context = new UniBinderEF())
            {
                context.PersonSubjects.Add(personSubject);
                context.SaveChanges();
            }
        }

        public bool UpdatePersonInfo(Person p)
        {
            using (var context = new UniBinderEF())
            {
                var person = context.People.SingleOrDefault(x => x.ID == p.ID);
                if (person != null)
                {
                    person.ImageLink = p.ImageLink;
                    person.Name = p.Name;
                    person.Surname = p.Surname;
                    person.Username = p.Username;
                    person.Age = p.Age;
                    person.SubjectList = p.SubjectList;
                    LinkSubjectsToPerson(person);
                    context.SaveChanges();
                    return true;
                }
                return false;
            }
        }

        public void LinkSubjectsToPerson(Person person)
        {
            foreach (var item in person.SubjectList)
            {
                AddSubjects(new PersonSubject
                {
                    PersonID = person.ID,
                    Name = item.Name,
                    ID = UniqueSubjectID(item.ID)
                });
            }
        }

        private int UniqueSubjectID(int ID)
        {
            var personSubjects = _reader.Value.PersonSubjects();
            while (personSubjects.Exists(x => x.ID == ID))
            {
                ID++;
            }
            return ID;
        }
    }
}
