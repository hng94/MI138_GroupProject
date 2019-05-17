using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MI138_GroupProject.Models;
using Microsoft.AspNet.Identity;

namespace MI138_GroupProject.Controllers
{
    [Authorize]
    public class GamesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Games
        public ActionResult Index()
        {
            Session["CurrentGame"] = null;
            if (User.IsInRole("Admin"))
            {
                return View("IndexAdmin", db.Games.ToList());
            }
            return View(db.Games.ToList());
        }

        // GET: Games/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Game game = db.Games.Include("Reviews.CreatedBy").Where(g => g.ID == id).FirstOrDefault();
            if (game == null)
            {
                return HttpNotFound();
            }
            Session["CurrentGame"] = game;
            return View(game);
        }

        public ActionResult CreateReview()
        {
            ViewBag.CurrentGame = Session["CurrentGame"];
            return View();
        }


        // GET: Games/Create
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateReview(Review vm)
        {
            ViewBag.CurrentGame = Session["CurrentGame"];
            var currentGame = (Game) Session["CurrentGame"];
            var game = db.Games.FirstOrDefault(g => g.ID == (int) currentGame.ID);
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
            }
            return RedirectToAction("Details", Session["CurrentGameID"]);
        }
        // POST: Games/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,ScreenshotUrl,Created")] Game game)
        {
            if (ModelState.IsValid)
            {
                db.Games.Add(game);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(game);
        }

        // GET: Games/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Game game = db.Games.Find(id);
            if (game == null)
            {
                return HttpNotFound();
            }
            return View(game);
        }

        // POST: Games/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,ScreenshotUrl,Created")] Game game)
        {
            if (ModelState.IsValid)
            {
                db.Entry(game).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(game);
        }

        // GET: Games/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Game game = db.Games.Find(id);
            if (game == null)
            {
                return HttpNotFound();
            }
            return View(game);
        }

        // POST: Games/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Game game = db.Games.Find(id);
            db.Games.Remove(game);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
