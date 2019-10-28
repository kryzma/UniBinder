using LogIn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UniBinderAPI.Models;

namespace UniBinderAPI.Controllers
{
    public class PersonController : ApiController
    {
        List<P> p = new List<P>();
        List<Person> people = new List<Person>();
        List<Subject> subjects = new List<Subject>();
        PersonController()
        {
            subjects.Add(new Subject { Name = "math" });
            UserDataReader userDataReader = new UserDataReader();
            people = userDataReader.ReadUserData();

        }


        // GET: api/Person
        public IEnumerable<Person> Get()
        {
            return people;
        }

        // GET: api/Person/5
        public Person Get(int id)
        {
            return people.Where(x => x.ID == id).FirstOrDefault();
        }

        // POST: api/Person
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Person/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Person/5
        public void Delete(int id)
        {
        }
    }
}
