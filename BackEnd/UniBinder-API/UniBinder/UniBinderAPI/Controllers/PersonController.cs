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

//UNIQUEIDENTIFIER PRIMARY KEY default NEWID(),

namespace UniBinderAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class PersonController : ApiController
    {
        UserDataInserter userDataInserter = new UserDataInserter();
        Lazy<UserDataReader> _reader = new Lazy<UserDataReader>();

        UserDataReader reader = new UserDataReader();
        List<Person> people;

        IRepository<Person> repository = new PersonRepository();




        #region GetApi

        [Route("api/person/SubjectList")]
        [HttpGet]
        public IHttpActionResult GetSubjects()
        {
            return Ok(_reader.Value.SubjectList());
        }


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

        [Route("api/person/{id}")]
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            if (people == null)
            { 
                people = _reader.Value.ReadUserData();
            }
            var user = people[id];

            if (user == null)
            {
                //UnknownData(id.ToString(), "ID");
                return NotFound();
            }

            return Ok(user);
        }

        [Route("api/person/ID")]
        [HttpGet]
        // [AllowAnonymous]
        public IHttpActionResult GetID(string username)
        {

            var person = _reader.Value.ReadUserData().Where(x => x.Username == username).FirstOrDefault();
            if (person == null)
            {
                return NotFound();
            }

            return Ok(person.ID);
        }



        [Route("api/person/Pass")]
        [HttpGet]
        // [AllowAnonymous]
        public IHttpActionResult getPassword(string username)
        {
            var people = _reader.Value.ReadUserData();
            var person = people.FirstOrDefault(x => x.Username.Equals(username, StringComparison.InvariantCultureIgnoreCase));

           // var person = people.Where(x => x.Username.ToLower() == username.ToLower()).FirstOrDefault();
            if (person == null)
            {
                return NotFound();
            }
            return Ok(person.Password);
        }

        [Route("api/person/FilterBySubjects")]
        [HttpGet]
        public IHttpActionResult FilterByChosenSubject(string token)
        {
            IAuthService authService = new JWTService(ConfigurationManager.AppSettings["SecretJWTKey"]);
            var checkedClaims = authService.GetTokenClaims(token).ToList();
            var checkID = checkedClaims.FirstOrDefault(x =>
                                            x.Type.Equals(ClaimTypes.NameIdentifier))
                                            .Value;
            var PersonID = CheckToken(token);
            if (CheckToken(token) == BadRequest()) return BadRequest();

            var matchedPeopleBySubject = new List<Person>();
            var peopleList = _reader.Value.ReadUserData();
            
            var selectedSubjects = peopleList.Where(x => checkID == x.ID.ToString()).FirstOrDefault().SubjectList;

            if(selectedSubjects == null)
            {
                BadRequest(); //BadToken
            }

            var IDCollection = _reader.Value.PeopleWithSameSubjects(new Guid(checkID));
            return Ok(IDCollection);

            //foreach(var person in peopleList)
            //{
            //    foreach (var subject in selectedSubjects)
            //    {
            //        if(person.SubjectList.Exists(x => x.Name == subject.Name) && person.ID.ToString() != checkID)
            //        {
            //            matchedPeopleBySubject.Add(person);
            //            break;
            //        }
            //    }
            //}

            //if(matchedPeopleBySubject == null)
            //{
            //    return NotFound(); //404
            //}

            //return Ok(matchedPeopleBySubject);
        }




        [Route("api/person/Token")]
        [HttpGet]
        // [AllowAnonymous]
        public IHttpActionResult GetToken(string username)
        {
            var people = _reader.Value.ReadUserData();
            var person = people.Where(x => x.Username.Equals(username, StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault();
            if (person == null)
            {
                return NotFound();
            };

            IAuthContainerModel model = GetJWTContainerModel(username.ToLower(), person.ID.ToString()); //might remove case sensitivity
                                                                                                                             // IAuthContainerModel model = GetJWTContainerModel("a", "test"); //might remove case sensitivity
            IAuthService authService = new JWTService(model.SecretKey);
            string token = authService.GenerateToken(model);
            //if (!authService.IsTokenValid(token))
            //    throw new UnauthorizedAccessException();

            return Ok(token);
        }

        #endregion

        [Route("api/person/ChangeUserSettings")]
        [HttpPut]
        public IHttpActionResult ChangeUserSettings([FromBody]Person person)
        {
            if(userDataInserter.UpdatePersonInfo(person)) return Ok();
            return BadRequest();
        }


        [Route("api/person/UpdateUser")]
        [HttpPatch]
        public IHttpActionResult UpdateUser([FromBody]Person person)
        {
            if(person != null)
            {
                var preUpdatedUser = _reader.Value.ReadUserData().Where(x => x.Username == person.Username).FirstOrDefault();
                if (preUpdatedUser == null) return BadRequest();
                //UpdatePersonProperties(person, updatedUser);
                repository.Update(UpdatePersonProperties(person, preUpdatedUser));
                return Ok();
            }
            return BadRequest();
        }

        private Person UpdatePersonProperties(Person person, Person preUpdatedUser)
        {
            person.Age = preUpdatedUser.Age;
            person.Dislikes = preUpdatedUser.Dislikes;
            person.Username = preUpdatedUser.Username;
            person.SubjectList = preUpdatedUser.SubjectList;
            person.Role = preUpdatedUser.Role;
            //person.MatchedPeople = updatedUser.MatchedPeople;
            person.ImageLink = preUpdatedUser.ImageLink;
            person.ID = preUpdatedUser.ID;
            person.Likes = preUpdatedUser.Likes;
            userDataInserter.LinkSubjectsToPerson(person);
            return person;
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

            if (legitToken) return Ok(checkID);
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
                //CreateUniqueId(person);
                //userDataInserter.LinkSubjectsToPerson(person);
                return AddToDB(person);
            }
        }

        #endregion
        #region Private Methods
        private IHttpActionResult AddToDB(Person person)
        {
            //CreateUniqueId(person);
            person.ID = Guid.NewGuid();
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
                //person.ID++;
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

       

        private string UnknownData(string data, string nameOfData)
        {
            return string.Format("No User found with {0} = {1}", nameOfData, data);
        }
        #endregion

    }
}
