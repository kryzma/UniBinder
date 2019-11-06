
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
using UniBinderAPI.Managers;
using UniBinderAPI.Models;


namespace UniBinderAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class PersonController : ApiController
    {
        UserDataReader userDataReader = new UserDataReader();
        UserDataInserter userDataInserter = new UserDataInserter();

        PersonController()
        {           
        }

        [Route("api/person/count")]
        [HttpGet]
        public int GetNumber()
        {
            return userDataReader.ReadUserData().Count;
        }

        // GET: api/Person
        public IEnumerable<Person> Get()
        {
            return userDataReader.ReadUserData();
        }

        // GET: api/Person/5
        public HttpResponseMessage Get(int id)
        {
            var userID = userDataReader.ReadUserData().Where(x => x.ID == id).FirstOrDefault();
            if(userID == null)
            {
                UnknownData(id.ToString(), "ID");
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
            var person = people.Where(x => x.Name == username).ToList().FirstOrDefault();
            if (person == null) UnknownData(username, "Username");
            return Request.CreateResponse(HttpStatusCode.OK, person);
        }

        [Route("api/person/Token")]
        [HttpGet]
       // [AllowAnonymous]
        public HttpResponseMessage GetToken(string username)
        {
            List<Person> people = userDataReader.ReadUserData();
            var personCredentials = people.Where(x => x.Name == username).ToList().FirstOrDefault();
            if (personCredentials == null) UnknownData(username, "Username");
            IAuthContainerModel model = GetJWTContainerModel(username, RetrieveID(username).ToString());
            IAuthService authService = new JWTService(model.SecretKey);
            string token = authService.GenerateToken(model);

            if (!authService.IsTokenValid(token))
                throw new UnauthorizedAccessException();
            else
            {
                //List<Claim> claims = authService.GetTokenClaims(token).ToList();
                //System.Diagnostics.Debug.WriteLine(claims.FirstOrDefault(e => e.Type.Equals(ClaimTypes.Name)).Value);
                //System.Diagnostics.Debug.WriteLine(claims.FirstOrDefault(e => e.Type.Equals(ClaimTypes.Email)).Value);
                //System.Diagnostics.Debug.WriteLine(token);
                return Request.CreateResponse(HttpStatusCode.OK, token);
            }
        }

        [Route("api/person/Registration")]
        [HttpPost]
        public IHttpActionResult Registration(Person person)
        {
            var people = userDataReader.ReadUserData();
            if(!CheckExistingData(person, people))
            {
                userDataInserter.SendUserData(person);
                return Ok();
            }
            return Content(HttpStatusCode.BadRequest, "Pick unique email or nickname"); 
        }

        #region Private Methods
        private static JWTContainerModel GetJWTContainerModel(string username,  string ID)
        {
            return new JWTContainerModel()
            {
                Claims = new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, ID),
                    new Claim(ClaimTypes.Name, username),
                    //new Claim(ClaimTypes.Email, password)
                }
            };
        }

        private int RetrieveID(string username)
        {
            var p2 = userDataReader.ReadUserData().Where(x => x.Name == username).FirstOrDefault().ID;
            return p2;
        }
        private HttpResponseMessage UnknownData(string data, string nameOfData)
        {
            string message = string.Format("No User found with {0} = {1}", nameOfData, data);
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, message);
        }
        private bool CheckExistingData(Person person, List<Person> people)
        {
            if (people.Exists(x => x.Name == person.Name || x.Email == person.Email)) return true;
            return false;
        }
        #endregion

    }
}
