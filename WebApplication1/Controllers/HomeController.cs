using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using GameCompany.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
using System.Net.Http;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly DatabaseContext _context;

        public HomeController(DatabaseContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            //List<GameC> games = db.Games.Where(g => g.Deleted == false).ToList();
            var games = _context.Game_company.Include(g => g.Tag).ToList();
            return View(games);

        }
        public ActionResult Send(int? id)
        {

            var gamest = _context.Game_company.Include(g => g.Tag).ToList();
            if (id == null)
            {
                ViewData["Message"] = "Error occured during posting";
                return View("Index", gamest);
            }
            var games = _context.Game_company.Where(g => g.ID == id).ToList();
            var tag = _context.Tag.Where(t=>t.GameCompanyID==id).ToList();
            GameVM gm = new GameVM();
            gm.Name = games.Select(g => g.Name).First();
            gm.CreatorEmail = "avaz@gmail.com";
            gm.CreatorPassword = "Avaz595981!";
            gm.Tags = tag.Select(g => g.Name).ToList();
            gm.ScreenshotUrl = games.Select(g => g.ScreenshotUrl).First();

            using (var client = new HttpClient()) { 
                client.BaseAddress = new Uri("http://localhost:50992/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.PostAsJsonAsync("api/games/creategame",gm).Result;
                if (response.IsSuccessStatusCode)
                {

                    ViewData["Message"] = "The game Succesfully Posted";
                    return View("index", gamest);
                }

                ViewData["Message"] = "Error occured during posting";
                return View("Index", gamest);
            }
        }


        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
