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
                            person.SubjectList.Add(new Subject(subject.Name));
                        }
                    });
                });

                return PersonList;
            }
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