using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TailgateLive.Models;

namespace TailgateLive.Controllers
{
    public class UsersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Users
        public ActionResult Index()
        {
            var userDb = db.UserProfile.Include(u => u.ApplicationUsers);
            return View(userDb.ToList());
        }

        // GET: Users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.UserProfile.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            ViewBag.EmailId = new SelectList(db.Users, "Id", "Email");
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,UserName,UserZipCode,UserRating,EmailId")] User user)
        {
            if (ModelState.IsValid)
            {
                db.UserProfile.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmailId = new SelectList(db.Users, "Id", "Email", user.LoginId);
            return View(user);
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.UserProfile.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmailId = new SelectList(db.Users, "Id", "Email", user.LoginId);
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UserName,UserZipCode,UserRating,EmailId")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmailId = new SelectList(db.Users, "Id", "Email", user.LoginId);
            return View(user);
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.UserProfile.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = db.UserProfile.Find(id);
            db.UserProfile.Remove(user);
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

        public ActionResult ProfileSearch()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ProfileSearch(string UserName,ProfileViewModel model)
        {
            var personDetails = db.UserProfile.Where(x => x.UserName == UserName).FirstOrDefault();

            var comment = new Comment
            {
                UserId = personDetails.Id,
                Comments = model.Comments
            };
            db.Comments.Add(comment);
            db.SaveChangesAsync();

            return View("profile",personDetails);
        }
      
    }
}
