
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
        List<Person> people = new List<Person>();
        List<Credentials> credentials = new List<Credentials>();
        UserDataReader userDataReader = new UserDataReader();

        PersonController()
        {

            ///Iskelti
            people = userDataReader.ReadUserData();
        }

        [Route("api/person/count")]
        [HttpGet]
        public int GetNumber()
        {
            return 1;
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


        [Route("api/person/ID")]
        [HttpGet]
       // [AllowAnonymous]
        public  int getID(string username)
        {
            return RetrieveID(username);
        }

        private int RetrieveID(string username)
        {
            var p2 = people.Where(x => x.Name == username).FirstOrDefault().ID;
            return p2;
        }

        [Route("api/person/Pass")]
        [HttpGet]
       // [AllowAnonymous]
        public string getPassword(string username)
        {
            var person = people.Where(x => x.Name == username).ToList().FirstOrDefault();
            return person.Password;
            throw new HttpResponseException(HttpStatusCode.Unauthorized);
        }

        // DELETE: api/Person/5
        public void Delete(int id)
        {
        }

        [Route("api/person/Token")]
        [HttpGet]
       // [AllowAnonymous]
        public string GetToken(string username)
        {
            var personCredentials = people.Where(x => x.Name == username).ToList().FirstOrDefault();
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
                return token;
            }
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
        #endregion

    }
}
