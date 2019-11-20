
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using UniBinderAPI.Database;
using UniBinderAPI.DependencyInjection;
using UniBinderAPI.EntityFramework;
using UniBinderAPI.Managers;
using UniBinderAPI.Models;


namespace UniBinderAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class PersonController : ApiController
    {
        UserDataReader userDataReader = new UserDataReader();
        UserDataInserter userDataInserter = new UserDataInserter();
        Lazy<UserDataInserter> _inserter = new Lazy<UserDataInserter>();
        Lazy<UserDataReader> _reader = new Lazy<UserDataReader>();

        PersonDI _personDI = new PersonDI(new PersonReader());



        #region GetApi
        [Route("api/person/list")]
        [HttpGet]
        public IEnumerable<Person> GetList()
        {
            //return userDataReader.ReadUserData();
            var list = _personDI.GetPeople();
            return list;
        }


        [Route("api/person/count")]
        [HttpGet]
        public int GetNumber()
        {
            //return userDataReader.ReadUserData().Count;
            return _reader.Value.ReadUserData().Count;
        }

        // GET: api/Person
        public IEnumerable<Person> Get()
        {
            //return userDataReader.ReadUserData();
            return _reader.Value.ReadUserData();
        }

        // GET: api/Person/5
        public HttpResponseMessage Get(int id)
        {
            
            var userID = _reader.Value.ReadUserData().Where(x => x.ID == id).FirstOrDefault();
            if(userID == null)
            {
                UnknownData(id.ToString(), "ID");
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, UnknownData(id.ToString(), UnknownData(id.ToString(), "ID")));
            }
            return Request.CreateResponse(HttpStatusCode.OK, userID);
        }

        [Route("api/person/ID")]
        [HttpGet]
       // [AllowAnonymous]
        public  int getID(string username)
        {
            return RetrieveID(username);
        }



        [Route("api/person/Pass")]
        [HttpGet]
        // [AllowAnonymous]
        public HttpResponseMessage getPassword(string username)
        {
            List<Person> people = userDataReader.ReadUserData();
            var person = people.Where(x => x.Name.ToLower() == username.ToLower()).FirstOrDefault();
            if (person == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, UnknownData(username, "username"));
            }
            return Request.CreateResponse(HttpStatusCode.OK, person.Password);
        }

        [Route("api/person/Token")]
        [HttpGet]
       // [AllowAnonymous]
        public HttpResponseMessage GetToken(string username)
        {
            List<Person> people = userDataReader.ReadUserData();
            var personCredentials = people.Where(x => x.Name.ToLower() == username.ToLower()).FirstOrDefault();
            if (people.Exists(x => x.Name.ToLower() == username.ToLower()))
                if (personCredentials == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, UnknownData(username, "Username"));

                };
            IAuthContainerModel model = GetJWTContainerModel(username.ToLower(), RetrieveID(username.ToLower()).ToString()); //might remove case sensitivity
           // IAuthContainerModel model = GetJWTContainerModel("a", "test"); //might remove case sensitivity
            IAuthService authService = new JWTService(model.SecretKey);
            string token = authService.GenerateToken(model);

            if (!authService.IsTokenValid(token))
                throw new UnauthorizedAccessException();
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, token);
            }
        }
        #endregion
        #region PostApi
        [Route("api/person/Registration")]
        [HttpPost]
        public IHttpActionResult Registration(Person person)
        {
            if (userDataReader.CheckUniqueData(person.Name, person.Email))
            {

                //userDataInserter.SendUserData(person);
               
                return Ok();
            }
            return Content(HttpStatusCode.Ambiguous, "Pick unique email or nickname"); 
        }

        #endregion
        #region Private Methods
        private static JWTContainerModel GetJWTContainerModel(string username,  string ID)
        {
            return new JWTContainerModel()
            {
                Claims = new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, ID),
                    new Claim(ClaimTypes.Name, username.ToLower()),
                }
            };
        }

        private int RetrieveID(string username)
        {
            var p2 = userDataReader.ReadUserData().Where(x => x.Name.ToLower() == username.ToLower()).FirstOrDefault().ID;
            return p2;
        }
        private string UnknownData(string data, string nameOfData)
        {
            return string.Format("No User found with {0} = {1}", nameOfData, data);
        }
        private bool CheckExistingData(Person person, List<Person> people)
        {
            if (people.Exists(x => x.Name.ToLower() == person.Name.ToLower() || x.Email.ToLower() == person.Email.ToLower())) return true;
            return false;
        }
        #endregion

    }
}
