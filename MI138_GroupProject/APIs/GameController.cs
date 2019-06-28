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
using System.Web.Http.Cors;

namespace MI138_GroupProject.APIs
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/games")]
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

        [Route("getgames")]
        [HttpGet]
        public Game[] GetGames()
        {
            return db.Games.ToArray();
        }

        [Route("createreview")]
        [HttpPost]
        public IHttpActionResult CreateReview([FromBody] ReviewVM vm)
        {
            var game = db.Games.FirstOrDefault(g => g.ID == vm.GameID);
            if (game != null)
            {
                string userId = User.Identity.GetUserId();
                Review review = new Review();
                review.Content = vm.Content;
                review.CreatedBy = db.Users.FirstOrDefault(u => u.Id == userId);
                review.Created = DateTime.Now;
                db.Reviews.Add(review);
                //db.SaveChanges();
                game.Reviews.Add(review);
                db.SaveChanges();
                return Ok();
            }
            return NotFound();
        }

        [Route("creategame")]
        [HttpPost]
        public IHttpActionResult CreateGame([FromBody] GameVM vm)
        {
            string email = vm.CreatorEmail;
            string password = vm.CreatorPassword;
            ApplicationUser user =  UserManager.FindByEmail(email);
            var passwordHasher = new PasswordHasher();

            if (user != null && passwordHasher.VerifyHashedPassword(user.PasswordHash, password) == PasswordVerificationResult.Success)
            {
                Game newGame = new Game();
                newGame.Created = DateTime.Now;
                newGame.CreatedBy = db.Users.Where(u => u.Email == email).FirstOrDefault();
                newGame.Name = vm.Name;
                newGame.ScreenshotUrl = vm.ScreenshotUrl;
                string tags = String.Join(";", vm.Tags.ToArray<string>());
                newGame.Tags = tags;

                db.Games.Add(newGame);
                db.SaveChanges();
                return Ok();
            }
            return NotFound();
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