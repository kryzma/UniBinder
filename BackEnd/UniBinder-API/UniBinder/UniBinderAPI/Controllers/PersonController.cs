
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using UniBinderAPI.Database;
using UniBinderAPI.Models;

namespace UniBinderAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class PersonController : ApiController
    {
        List<Person> people = new List<Person>();
        UserDataReader userDataReader = new UserDataReader();
        PersonController()
        {
            people = userDataReader.ReadUserData();
        }

        [Route("api/person/count")]
        [HttpGet]
        public int GetNumber()
        {
            return DatabaseUserInfo.UserCount();
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
        public void POST([FromBody]Person value)
        {
            
        }







        //public HttpResponseMessage POST([FromBody]Person value)
        //{
        //    try
        //    {
        //        UserDataInserter a = new UserDataInserter();
        //        a.SendUserData(value);
        //        var message = Request.CreateResponse(HttpStatusCode.Created, value);
        //        message.Headers.Location = new Uri(Request.RequestUri + value.ID.ToString());
        //        return message;
        //    }
        //    catch (Exception ex)
        //    {
        //        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
        //    }
        //}


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
