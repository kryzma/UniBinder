using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogIn
{
    class GroupJoinManager
    {
        public void GroupJoin()
        {
            var subjects = new List<SubjectID>
            {
                new SubjectID { Id = 1, Name = "C#" },
                new SubjectID { Id = 1, Name = "Java" },
                new SubjectID { Id = 2, Name = "C" },
                new SubjectID { Id = 2, Name = "C++" },
                new SubjectID { Id = 2, Name = "Java" },
                new SubjectID { Id = 3, Name = "C++" }
            };

            var people = new List<PersonID>
            {
                new PersonID { Name = "Jonas", Id = 1 },
                new PersonID { Name = "Tadas", Id = 2 },
                new PersonID { Name = "Benas", Id = 3 }
            };

            var groupjoin = from person in people
                            orderby person.Id
                            join subject in subjects on person.Id
                            equals subject.Id into usersGroup
                            select new
                            {
                                User = person.Name,
                                Subjects = from user2 in usersGroup
                                           orderby user2.Name
                                           select user2
                            };

            foreach (var usersGroup in groupjoin)
            {
                Console.WriteLine(usersGroup.User);
                foreach (var subject in usersGroup.Subjects)
                {
                    Console.WriteLine("- {0}", subject.Name);
                    checked
                    {
                        short id2 = (short)subject.Id;
                    }
                    

                }

            }

            //var groupjoin = people.GroupJoin(subjects, person => person.Id, subject => subject.Id, (person, subjectCollection) => new { usersGroup = person.Name, Subjects = subjectCollection.Select(subject => subject.Name) });

            //foreach (var obj in groupjoin)
            //{
            //    Console.WriteLine(obj.usersGroup);
            //    foreach (string subject in obj.Subjects)
            //    {
            //        Console.WriteLine("- {0}", subject);
            //    }
            //}

        }
        public void DisplayGeneric()
        {
            GenericList list = new GenericList();

            list.DisplayValue<int>("Integer", 111);
            list.DisplayValue<char>("Character", 'A');
            list.DisplayValue<double>("Decimal", 13.37);
        }
    }
}
