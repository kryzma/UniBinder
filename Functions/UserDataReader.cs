using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogIn
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
            var context = new studybuddyEntities();

            PersonList = (from a in context.Person
                          select a
                          ).ToList();

            var result = (from a in context.PersonSubject
                          select a
                          ).ToList();

            result.ForEach(subject =>
            {
                PersonList.ForEach(person =>
                {
                    if (subject.ID.Equals(person.ID))
                    {
                        person.subjectList.Add(new Subject(subject.Name));
                    }
                });
            });

            context.Dispose();
            return PersonList;
        }
    }
}
