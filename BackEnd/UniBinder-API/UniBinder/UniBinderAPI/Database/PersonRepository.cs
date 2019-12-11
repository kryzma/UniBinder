using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniBinderAPI.EntityFramework;

namespace UniBinderAPI.Database
{
    public class PersonRepository : IRepository<Person>
    {
        UniBinderEF _dbContext;
        IRepository<PersonSubject> repository = new PersonSubjectRepository();


        public PersonRepository()
        {
            _dbContext = new UniBinderEF();
        }

        public IEnumerable<Person> List
        {
            get
            {
                return _dbContext.People;
            }

        }

        public void Add(Person entity)
        {
            _dbContext.People.Add(entity);
            _dbContext.SaveChanges();
        }

        public void Delete(Person entity)
        {
            _dbContext.People.Remove(entity);
            _dbContext.SaveChanges();
            
        }

        public Person FindById(Guid Id)
        {
            return _dbContext.People.Where(x => x.ID == Id).FirstOrDefault();
        }

        public void Update(Person entity)
        {

                _dbContext.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                _dbContext.SaveChanges();
            }
        }
    }
