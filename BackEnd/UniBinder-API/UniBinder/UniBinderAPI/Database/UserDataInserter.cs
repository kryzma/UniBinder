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
        IRepository<Person> repository = new PersonRepository();
        IRepository<PersonSubject> subjectRepository = new PersonSubjectRepository();
        UserDataInserter userDataInserter = new UserDataInserter();

        public void SendUserData(Person person)
        {
            repository.Add(person);
        }

        private void AddSubjects(PersonSubject personSubject)
        {
            using (var context = new UniBinderEF())
            {
                if (!context.PersonSubjects.ToList().Exists(x => x.PersonID == personSubject.PersonID && x.Name == personSubject.Name))
                { 
                    context.PersonSubjects.Add(personSubject);
                    context.SaveChanges();
                }
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
            var alreadyChosenSubjects = _reader.Value.SubjectsPersonHas(person.ID);
            foreach (var subject in person.SubjectList)
            {
                if (alreadyChosenSubjects.Contains(subject.Name)) continue;

                subjectRepository.Add(new PersonSubject
                {
                    Name = subject.Name,
                    PersonID = person.ID
                });
            }
        }

        private int UniqueSubjectID(int ID)
        {
            
        }
    }
}
