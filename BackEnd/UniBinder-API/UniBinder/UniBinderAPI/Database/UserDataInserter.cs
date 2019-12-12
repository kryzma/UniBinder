using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

    class UserDataInserter : IUserDataInserter
    {
        Lazy<UserDataReader> _reader = new Lazy<UserDataReader>();
        IRepository<Person> repository = new PersonRepository();
        IRepository<PersonSubject> subjectRepository = new PersonSubjectRepository();
        //UserDataInserter userDataInserter = new UserDataInserter();

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
                    
                    LinkSubjectsToPersonWithDel(person);
                    context.SaveChanges();
                    return true;
                }
                return false;
            }
        }

        public void LinkSubjectsToPersonWithDel(Person person) //deletes every subject then adds new ones
        {
            var userSubjects = subjectRepository.List.Where(x => person.ID == x.PersonID).ToList();
            foreach (var subject in userSubjects)
            {
                subjectRepository.Delete(subject);
            }

            foreach (var item in person.SubjectList)
            {
                subjectRepository.Add(new PersonSubject
                {
                    Name = item.Name,
                    PersonID = person.ID,
                    ID = Guid.NewGuid()
                });
            }

        }

        public void LinkSubjectsToPerson(Person person) // adds if there's more subjects in updated than preupdated user 
        {
            var alreadyChosenSubjects = _reader.Value.SubjectsPersonHas(person.ID);
            foreach (var subject in person.SubjectList)
            {
                if (alreadyChosenSubjects.Contains(subject.Name)) continue;

                subjectRepository.Add(new PersonSubject
                {
                    Name = subject.Name,
                    PersonID = person.ID,
                    ID = Guid.NewGuid()
                });
            }
        }

        //private int UniqueSubjectID(int ID)
        //{
        //    var personSubjects = _reader.Value.PersonSubjects();
        //    while (personSubjects.Exists(x => x.ID == ID))
        //    {
        //        ID++;
        //    }
        //    return ID;
        //} // for normal query - no dataset


        public void LinkSubjectsToPersonDataTable(Person person)
        {
            var connectionString = ConfigurationManager.AppSettings["ConnectionString"]; 
            SqlConnection connection = new SqlConnection(connectionString);
            using (connection)
            {
                connection.Open();
                SqlCommand delete = new SqlCommand();
                delete.Connection = connection;
                delete.CommandType = CommandType.Text;
                delete.CommandText = "Delete FROM PersonSubject where ID = @ID ";

                delete.Parameters.Add(new SqlParameter("@ID", SqlDbType.UniqueIdentifier, 50, "ID"));

                using (SqlDataAdapter adapter = new SqlDataAdapter("select * from PersonSubject", connection))
                {
                    adapter.DeleteCommand = delete;

                    DataSet ds = new DataSet();

                    adapter.Fill(ds, "PersonSubject");

                    for (int i = ds.Tables[0].Rows.Count - 1; i >= 0; i--)
                    {
                        if (person.ID.Equals(ds.Tables[0].Rows[i]["PersonID"]))
                        {
                            DataRow row = ds.Tables[0].Rows[i];
                            row.Delete();
                        }
                    }

                    SqlCommand insert = new SqlCommand();
                    insert.Connection = connection;
                    insert.CommandType = CommandType.Text;
                    insert.CommandText = "Insert into PersonSubject Values (@ID,@PI,@NAME)";

                    insert.Parameters.Add(new SqlParameter("@ID", SqlDbType.UniqueIdentifier, 50, "ID"));
                    insert.Parameters.Add(new SqlParameter("@PI", SqlDbType.UniqueIdentifier, 50, "PersonID"));
                    insert.Parameters.Add(new SqlParameter("@NAME", SqlDbType.VarChar, 50, "Name"));

                    adapter.InsertCommand = insert;

                    foreach (var sub in person.SubjectList)
                    {
                        ds.Tables[0].Rows.Add(Guid.NewGuid(), person.ID, sub.Name);
                    }
                    adapter.Update(ds.Tables[0]);
                }
            }
        }
        public void AddNewMatch(Guid victimID, string checkID)
        {
            using (var context = new UniBinderEF())
            {
                context.MatchedPeoples.Add(new MatchedPeople {
                    FirstPersonID = new Guid(checkID), SecondPersonID = victimID, Id = Guid.NewGuid() });
                context.SaveChanges();
            }
        }

    }
}
