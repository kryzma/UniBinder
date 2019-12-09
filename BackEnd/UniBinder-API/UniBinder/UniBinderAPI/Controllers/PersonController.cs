using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
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

        IRepository<Person> repository = new PersonRepository();
        


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
            //return repository.List;
            return _reader.Value.ReadUserData();
        }

        // GET: api/Person/5
        public HttpResponseMessage Get(int id)
        {
            var user = _reader.Value.ReadUserData().FirstOrDefault(x => x.ID == id);
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
        public HttpResponseMessage GetID(string username)
        {

            var person = _reader.Value.ReadUserData().Where(x => x.Username == username).FirstOrDefault();
            if (person == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, UnknownData(person.ID.ToString(), UnknownData(person.ID.ToString(), "ID")));
            }

            return Request.CreateResponse(HttpStatusCode.OK, person.ID);
        }



        [Route("api/person/Pass")]
        [HttpGet]
        // [AllowAnonymous]
        public HttpResponseMessage getPassword(string username)
        {
            var people = _reader.Value.ReadUserData();
            var person = people.FirstOrDefault(x => x.Username.Equals(username, StringComparison.InvariantCultureIgnoreCase));

           // var person = people.Where(x => x.Username.ToLower() == username.ToLower()).FirstOrDefault();
            if (person == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, UnknownData(username, "username"));
            }
            return Request.CreateResponse(HttpStatusCode.OK, person.Password);
        }

        [Route("api/person/FilterBySubjects")]
        [HttpGet]
        public IHttpActionResult FilterByChosenSubject(string token)
        {
            var matchedPeopleBySubject = new List<Person>();
            var peopleList = _reader.Value.ReadUserData();
            IAuthService authService = new JWTService(ConfigurationManager.AppSettings["SecretJWTKey"]);
            var checkedClaims = authService.GetTokenClaims(token).ToList();
            var checkID = checkedClaims.FirstOrDefault(x =>
                                            x.Type.Equals(ClaimTypes.NameIdentifier))
                                            .Value;

            var selectedSubjects = peopleList.Where(x => checkID == x.ID.ToString()).FirstOrDefault().SubjectList;

            if(selectedSubjects == null)
            {
                BadRequest(); //BadToken
            }

            foreach(var person in peopleList)
            {
                foreach (var subject in selectedSubjects)
                {
                    if(person.SubjectList.Exists(x => x.Name == subject.Name) && person.ID.ToString() != checkID)
                    {
                        matchedPeopleBySubject.Add(person);
                        break;
                    }
                }
            }
            if(matchedPeopleBySubject == null)
            {
                return NotFound(); //404
            }
            return Ok(matchedPeopleBySubject);
        }


        [Route("api/person/Token")]
        [HttpGet]
        // [AllowAnonymous]
        public HttpResponseMessage GetToken(string username)
        {
            var people = _reader.Value.ReadUserData();
            var person = people.Where(x => x.Username.Equals(username, StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault();
            if (person == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, UnknownData(username, "Username"));
            };

            IAuthContainerModel model = GetJWTContainerModel(username.ToLower(), person.ID.ToString()); //might remove case sensitivity
                                                                                                                             // IAuthContainerModel model = GetJWTContainerModel("a", "test"); //might remove case sensitivity
            IAuthService authService = new JWTService(model.SecretKey);
            string token = authService.GenerateToken(model);
            //if (!authService.IsTokenValid(token))
            //    throw new UnauthorizedAccessException();

                return Request.CreateResponse(HttpStatusCode.OK, token);
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
                                            x.Username.Equals(checkName, StringComparison.InvariantCultureIgnoreCase)
                                            && x.ID.ToString() == checkID);
                                                   //jwt don't have claims for username so i used 'Name' instead

            if (legitToken) return Ok();
            else return BadRequest();
        }





        [Route("api/person/Registration")]
        [HttpPost]
        public IHttpActionResult Registration(Person person)
        {
            using(var context = new UniBinderEF())
            {
                var people = context.People.ToList();
                if (people.Exists(x => x.Username.Equals(person.Username, StringComparison.InvariantCultureIgnoreCase))) return BadRequest();
                if (people.Exists(x => x.Email.Equals(person.Email, StringComparison.InvariantCultureIgnoreCase))) return Conflict();
                CreateUniqueId(person);
                userDataInserter.LinkSubjectsToPerson(person);
                return AddToDB(person);
            }
        }

        #endregion
        #region Private Methods
        private IHttpActionResult AddToDB(Person person)
        {
            //CreateUniqueId(person);
            userDataInserter.SendUserData(person);
            return Ok();
        }

        public IHttpActionResult CheckUniqueData(string username, string email)
        {
            using (var context = new UniBinderEF())
            {
                var people = context.People.ToList();
                if (people.Exists(x => x.Username.Equals(username, StringComparison.InvariantCultureIgnoreCase))) return BadRequest();
                if (people.Exists(x => x.Email.Equals(email, StringComparison.InvariantCultureIgnoreCase))) return Conflict();
                return Ok();
            }
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
            var p2 = _reader.Value.ReadUserData().Where(x => x.Username.Equals(username, StringComparison.InvariantCultureIgnoreCase)).First();
            if(p2 != null) return p2.ID;
            return -1;

        }
        private string UnknownData(string data, string nameOfData)
        {
            return string.Format("No User found with {0} = {1}", nameOfData, data);
        }
        #endregion

    }
}
