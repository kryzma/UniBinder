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
            using (UniBinderEF context = new UniBinderEF())
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
                            Person person = new Person();
                            person.ID = per.ID;
                            person.Username = per.Username;
                            person.Password = per.Password;
                            person.Name = per.Name;
                            person.Surname = per.Surname;
                            person.Email = per.Email;
                            person.Role = per.Role;
                            person.Likes = per.Likes;
                            person.Dislikes = per.Dislikes;
                            person.ImageLink = per.ImageLink;

                            person.SubjectList = new List<Subject>();
                            foreach (var sub in per.subjectsList)
                            {
                                Subject subject = new Subject();
                                subject.Name = sub.Name;
                                person.SubjectList.Add(subject);
                            }
                            PersonList.Add(person);
                        }
                    }
                

                return PersonList;

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

