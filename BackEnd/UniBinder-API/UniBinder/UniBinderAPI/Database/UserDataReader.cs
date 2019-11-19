using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniBinderAPI.EntityFramework;
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
            using (UniBinderEF context = new UniBinderEF())
            {
                PersonList = (from a in context.People
                              select a).ToList();

                PersonList = (from a in context.People
                              select a
                              ).ToList();

                var result = (from a in context.PersonSubjects
                              select a
                              ).ToList();

                //result.ForEach(subject =>
                //{
                //    PersonList.ForEach(person =>
                //    {

                //        if (subject.ID.Equals(person.ID))
                //        {
                //            person.SubjectList.Add(new Subject { Name = subject.Name });
                //        }
                //    });
                //});

                return PersonList;
            }
        }

            public bool CheckUniqueData(string username, string email)
            {
                using (UniBinderEF context = new UniBinderEF())
                {
                if (context.People.ToList().Exists(x => username.ToLower() == x.Name.ToLower() && email.ToLower() == x.Email.ToLower())) return false;

                else return true;
                }
            }
        }
    }

