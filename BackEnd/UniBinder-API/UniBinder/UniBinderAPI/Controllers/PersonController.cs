using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Claims;
using System.Web.Http;
using System.Web.Http.Cors;
using UniBinderAPI.Database;
using UniBinderAPI.EntityFramework;
using UniBinderAPI.Managers;
using UniBinderAPI.Models;
using System.IO;
using UniBinderAPI.FileManager;
using System.Drawing;
using System.Data.Entity.Infrastructure;

//UNIQUEIDENTIFIER PRIMARY KEY default NEWID(),

namespace UniBinderAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class PersonController : ApiController
    {
        UserDataInserter userDataInserter = new UserDataInserter();
        Lazy<UserDataReader> _reader = new Lazy<UserDataReader>();

        List<Person> people;

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
            //ImageProcessor();
            return _reader.Value.ReadUserData();
        }

        [Route("api/person/{id}")]
        [HttpGet]
        public IHttpActionResult Get(Guid id)
        {
            var user = _reader.Value.ReadUserData().Where(x => x.ID == id).FirstOrDefault();

            if (user == null)
            {
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


        [Route("api/person/GetImage")]
        [HttpGet]
        // [AllowAnonymous]
        public IHttpActionResult GetImage(Guid PersonID)
        {
            var user = _reader.Value.ReadUserData().Where(x => x.ID == PersonID).FirstOrDefault();

            if (user == null)
            {
                return BadRequest();
            }

            return Ok(ImageProcessor(PersonID.ToString()));
        }

        public string ImageProcessor(string imgName)
        {
            var domainPath = AppDomain.CurrentDomain.BaseDirectory;
            //var path1 = string.Format(, imgName);
            var fullPath = domainPath + "Images" + @"\" + imgName + ".jpg";
            System.Diagnostics.Debug.WriteLine(fullPath);



            var base64String = Convert.ToBase64String(File.ReadAllBytes(fullPath));
            return base64String;
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
        }


        public IHttpActionResult ResolveToken(string token)
        {
            IAuthService authService = new JWTService(ConfigurationManager.AppSettings["SecretJWTKey"]);
            var checkedClaims = authService.GetTokenClaims(token).ToList();
            var checkID = checkedClaims.FirstOrDefault(x =>
                                            x.Type.Equals(ClaimTypes.NameIdentifier))
                                            .Value;
            var PersonID = CheckToken(token);
            if (CheckToken(token) == BadRequest()) return BadRequest();
            return Ok();
        }


        [Route("api/person/UserDataByToken")]
        [HttpGet]
        // [AllowAnonymous]
        public IHttpActionResult GetUserWithToken(string token)
        {
            IAuthService authService = new JWTService(ConfigurationManager.AppSettings["SecretJWTKey"]);
            var checkedClaims = authService.GetTokenClaims(token).ToList();
            var checkID = checkedClaims.FirstOrDefault(x =>
                                            x.Type.Equals(ClaimTypes.NameIdentifier))
                                            .Value;
            //var PersonID = CheckToken(token);
            if (CheckToken(token) == BadRequest())
            {
                return BadRequest();
            }

            var searchedUser = _reader.Value.ReadUserData().Where(x => x.ID.ToString() == checkID).FirstOrDefault();

            if (searchedUser == null)
            {
                return NotFound();
            }

            return Ok(searchedUser);
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
            return Ok(token);
        }

        #endregion

        [Route("api/person/ChangeUserSettings")]
        [HttpPut]
        public IHttpActionResult ChangeUserSettings([FromBody]Person person)
        {
            if (userDataInserter.UpdatePersonInfo(person)) return Ok();
            return BadRequest();
        }

        [Route("api/person/UpdateUser")]
        [HttpPatch]
        public IHttpActionResult UpdateUser([FromBody]Person updatedUser)
        {
            if (updatedUser == null) return BadRequest();
            var currentUser = GetCurrentUser(updatedUser);
            if (currentUser == null) return NotFound();

            Person user = new Person() { Name = updatedUser.Name, Password = updatedUser.Password,
                                        Surname = updatedUser.Surname, Email = updatedUser.Email, ID = updatedUser.ID, SubjectList = updatedUser.SubjectList };


            if (user.SubjectList == null)
            {
                using (var db = new UniBinderEF())
                {

                    db.People.Attach(user);
                    if(user.Password != null)
                    {
                        db.Entry(user).Property(x => x.Password).IsModified = true;
                    }
                    db.Entry(user).Property(x => x.Name).IsModified = true;
                    db.Entry(user).Property(x => x.Surname).IsModified = true;
                    db.Entry(user).Property(x => x.Email).IsModified = true;
                    try
                    {
                        db.SaveChanges();
                    }
                    catch (Exception)
                    {
                        return BadRequest();
                    }
                }
                return Ok();
            }

            else
            {
                userDataInserter.LinkSubjectsToPersonDataTable(user);
                return Ok();
            }
        }


        private Person GetCurrentUser(Person updatedUser)
        {
            return _reader.Value.ReadUserData().Where(x => x.ID == updatedUser.ID).FirstOrDefault();
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


        [Route("api/person/SaveImage")]
        [HttpPost]
        public IHttpActionResult PostImage(ImgHandler img)
        {
            var domainPath = AppDomain.CurrentDomain.BaseDirectory;
            //var path1 = string.Format(, imgName);
            var fullPath = domainPath + "Images" + @"\" + img.ImgPath + ".jpg";

            

            var image = Image.FromStream(new MemoryStream(Convert.FromBase64String(img.ImgBase64.Remove(0,23))));
            //var path = string.Format("../../img/{0}", img.ImgPath);

            image.Save(fullPath);
            return Ok();
        }


        [Route("api/person/Match")]
        [HttpPost]
        public IHttpActionResult AddMatch(string token, Guid victimID)
        {
            IAuthService authService = new JWTService(ConfigurationManager.AppSettings["SecretJWTKey"]);
            var checkedClaims = authService.GetTokenClaims(token).ToList();
            var checkID = checkedClaims.FirstOrDefault(x =>
                                            x.Type.Equals(ClaimTypes.NameIdentifier))
                                            .Value;
            if (CheckToken(token) == BadRequest())
            {
                return BadRequest();
            }

            if (new Guid(checkID) == victimID) return Conflict();

            using (var context = new UniBinderEF())
            {
                context.MatchedPeoples.Add(new MatchedPeople { FirstPersonID = new Guid(checkID), SecondPersonID = victimID });
                context.SaveChanges();
            }
            return Ok();
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

                var checkEmail = people.Where(x => x.Email.ToLower() == email.ToLower()).FirstOrDefault();
                if(checkEmail != null)
                {
                    return Conflict();
                }
                
                //if (people.Exists(x => x.Email.Equals(email, StringComparison.InvariantCultureIgnoreCase))) return Conflict();
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
                    new Claim(ClaimTypes.Name, username.ToLower())
                }
            };
        }



        public virtual void HandleException(Exception exception)
        {

        }



        private string UnknownData(string data, string nameOfData)
        {
            return string.Format("No User found with {0} = {1}", nameOfData, data);
        }
        #endregion

    }
}
