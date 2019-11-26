using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using UniBinderAPI.Database;
using UniBinderAPI.EntityFramework;
using UniBinderAPI.Managers;
using UniBinderAPI.Models;


namespace UniBinderAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class PersonController : ApiController
    {
        UserDataInserter userDataInserter = new UserDataInserter();
        Lazy<UserDataReader> _reader = new Lazy<UserDataReader>();

        #region GetApi

        [Route("api/person/count")]
        [HttpGet]
        public int GetNumber()
        {
            return _reader.Value.PeopleNumber();
        }

        // GET: api/Person
        public IEnumerable<Person> Get()
        {
            return _reader.Value.ReadUserData();
        }

        // GET: api/Person/5
        public HttpResponseMessage Get(int id)
        {
            var user = _reader.Value.ReadUserData().Where(x => x.ID == id).FirstOrDefault();
            if (user == null)
            {
                UnknownData(id.ToString(), "ID");
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, UnknownData(id.ToString(), UnknownData(id.ToString(), "ID")));
            }
            return Request.CreateResponse(HttpStatusCode.OK, user);
        }

        [Route("api/person/ID")]
        [HttpGet]
        // [AllowAnonymous]
        public int getID(string username)
        {
            return RetrieveID(username);
        }



        [Route("api/person/Pass")]
        [HttpGet]
        // [AllowAnonymous]
        public HttpResponseMessage getPassword(string username)
        {
            var people = _reader.Value.ReadUserData();
            var person = people.Where(x => x.Username.ToLower() == username.ToLower()).FirstOrDefault();
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
            var people = _reader.Value.ReadUserData();
            var personCredentials = people.Where(x => x.Username.ToLower() == username.ToLower()).FirstOrDefault();
            if (people.Exists(x => x.Username.ToLower() == username.ToLower()))
                if (personCredentials == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, UnknownData(username, "Username"));

                };
            IAuthContainerModel model = GetJWTContainerModel(username, RetrieveID(username).ToString()); //might remove case sensitivity
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

        [Route("api/person/ChangeUserSettings")]
        [HttpPut]
        public IHttpActionResult ChangeUserSettings(Person person)
        {
            if(userDataInserter.UpdatePersonInfo(person)) return Ok();
            return BadRequest();
        }


        #region PostApi

        [Route("api/person/CheckToken")]
        [HttpPost]
        public IHttpActionResult CheckToken(string CheckedToken)
        {
            //IAuthContainerModel model = GetJWTContainerModel(username, 
            //                            RetrieveID(username).ToString());

            //IAuthService authService = new JWTService(model.SecretKey);
            IAuthService authService = new JWTService(ConfigurationManager.AppSettings["SecretJWTKey"]);
            //string OriginalToken = authService.GenerateToken(model);
            var checkedClaims = authService.GetTokenClaims(CheckedToken).ToList();

            //might change FirstOrDefault to First 

            var checkID = checkedClaims.FirstOrDefault(x =>
                                            x.Type.Equals(ClaimTypes.NameIdentifier))
                                            .Value;

            var checkName = checkedClaims.FirstOrDefault(x =>
                                            x.Type.Equals(ClaimTypes.Name))
                                            .Value;

            var legitToken = _reader.Value.ReadUserData().Exists(x =>
                                            x.Username.ToLower() == checkName.ToLower()        //jwt don't have claims for username so i used 'Name' instead
                                            && x.ID.ToString() == checkID);

            if (legitToken) return Ok();
            else return BadRequest();
        }



        [Route("api/person/Registration")]
        [HttpPost]
        public IHttpActionResult Registration(Person person)
        {
            //if (!userDataReader.CheckUniqueData(person.Name, person.Email)) //
            if (!_reader.Value.CheckUniqueData(person.Username, person.Email))
            {
                return Conflict();
            }
            CreateUniqueId(person);
            userDataInserter.LinkSubjectsToPerson(person);
            return AddToDB(person);
        }

        #endregion
        #region Private Methods
        private IHttpActionResult AddToDB(Person person)
        {
            //CreateUniqueId(person);
            userDataInserter.SendUserData(person);
            return Ok();
        }

        private void CreateUniqueId(Person person)
        {
            while (_reader.Value.ReadUserData().Exists(x => x.ID == person.ID)) // prob. is not efficient, maybe should consider to make random number?
            {
                person.ID++;
            }
            return;
        }
        private static JWTContainerModel GetJWTContainerModel(string username, string ID)
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

        private int RetrieveID(string username) // null 
        {
            var p2 = _reader.Value.ReadUserData().Where(x => x.Username == username).First();
            return p2.ID;
        }
        private string UnknownData(string data, string nameOfData)
        {
            return string.Format("No User found with {0} = {1}", nameOfData, data);
        }
        #endregion

    }
}
