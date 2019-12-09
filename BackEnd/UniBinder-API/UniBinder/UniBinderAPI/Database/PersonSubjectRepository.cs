using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniBinderAPI.EntityFramework;

namespace UniBinderAPI.Database
{
    public class PersonSubjectRepository : IRepository<PersonSubject>
    {
        UniBinderEF _dbContext;

        public IEnumerable<PersonSubject> List
        {
            get
            {
                return _dbContext.PersonSubjects;
            }
        }

        public void Add(PersonSubject entity)
        {
            if (!_dbContext.PersonSubjects.ToList().Exists(x => x.PersonID == entity.PersonID && x.Name == entity.Name))
            {
                _dbContext.PersonSubjects.Add(entity);
                _dbContext.SaveChanges();
            }
            
        }

        public void Delete(PersonSubject entity)
        {
            if (!_dbContext.PersonSubjects.ToList().Exists(x => x.PersonID == entity.PersonID && x.Name == entity.Name))
            {
                _dbContext.PersonSubjects.Remove(entity);
                _dbContext.SaveChanges();
            }
        }

        public PersonSubject FindById(int Id)
        {
            throw new NotImplementedException();
        }

        public void Update(PersonSubject entity)
        {
            _dbContext.Entry(entity).State = System.Data.Entity.EntityState.Modified;
        }
    }
}