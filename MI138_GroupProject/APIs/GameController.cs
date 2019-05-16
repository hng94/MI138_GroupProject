using MI138_GroupProject.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace MI138_GroupProject.APIs
{
    public class GameController : ApiController
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;
        private ApplicationDbContext db = new ApplicationDbContext();

        public GameController()
        {

        }
        public GameController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? Request.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? Request.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        //[HttpPost]
        //[Route("game/creategame")]
        public HttpResponseMessage Post(GameVM vm)
        {
            string email = vm.CreatorEmail;
            string password = vm.CreatorPassword;
            ApplicationUser user =  UserManager.FindByEmail(email);
            var passwordHasher = new PasswordHasher();
            if (user != null && passwordHasher.VerifyHashedPassword(user.PasswordHash, password) == PasswordVerificationResult.Success)
            {
                Game newGame = new Game();
                newGame.Created = DateTime.Today;
                newGame.CreatedBy = user;
                newGame.Name = vm.Name;
                newGame.ScreenshotUrl = vm.ScreenshotUrl;
                string tags = String.Join(";", vm.Tags.ToArray<string>());
                newGame.Tags = tags;

                db.Games.Add(newGame);
                db.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK, newGame.ID);
            }
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Not found");
        }
        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}