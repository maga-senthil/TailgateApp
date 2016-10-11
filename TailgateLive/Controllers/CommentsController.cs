using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.Identity;
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
    public class CommentsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Comments
        public ActionResult Index()
        {
            var comments = db.Comments.Include(c => c.Events).Include(c => c.User);
            return View(comments.ToList());
        }

        // GET: Comments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = db.Comments.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }

        // GET: Comments/Create
        public ActionResult Create()
        {
            ViewBag.EventId = new SelectList(db.EventDb, "Id", "EventTitle");
            ViewBag.UserId = new SelectList(db.UserProfile, "Id", "UserName");
            return View();
        }

        // POST: Comments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Comments,UserId,EventId")] Comment comment)
        {
            string userId = User.Identity.GetUserId();
            User currentUser = db.UserProfile.FirstOrDefault(x => x.LoginId == userId);
          

            if (ModelState.IsValid)
            {

              comment.Comments = comment.Comments;
              comment.UserId = currentUser.Id;
              comment.EventId = comment.EventId;
           
                db.Comments.Add(comment);
                db.SaveChanges();
                //int commentId = comment.Id;
                //return RedirectToAction("CommentSearch", new { EventId =comment.EventId });

               return RedirectToAction("CommentSearch", new { EventId = comment .EventId  });
            }

            //ViewBag.EventId = new SelectList(db.EventDb, "Id", "EventTitle", comment.EventId);
            //ViewBag.UserId = new SelectList(db.UserProfile, "Id", "UserName", comment.UserId);
            // return View(comment);
            return View(comment);
        }

        // GET: Comments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = db.Comments.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            ViewBag.EventId = new SelectList(db.EventDb, "Id", "EventTitle", comment.EventId);
            ViewBag.UserId = new SelectList(db.UserProfile, "Id", "UserName", comment.UserId);
            return View(comment);
        }

        // POST: Comments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Comments,UserId,EventId")] Comment comment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(comment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EventId = new SelectList(db.EventDb, "Id", "EventTitle", comment.EventId);
            ViewBag.UserId = new SelectList(db.UserProfile, "Id", "UserName", comment.UserId);
            return View(comment);
        }

        // GET: Comments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = db.Comments.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }

        // POST: Comments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Comment comment = db.Comments.Find(id);
            db.Comments.Remove(comment);
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

        public ActionResult EventIndex(int EventId)
        {
            var EventDetails = db.EventDb.Where(x=> x.Id ==EventId).FirstOrDefault();
            return View(EventDetails);
        }
        public ActionResult CommentSearch(int EventId)
        {
            Event newEvent = new Event();
            newEvent = db.EventDb.Where(x => x.Id == EventId).FirstOrDefault();
            NFLGameSchedule game = new NFLGameSchedule();
            game = db.NFLGameSchedulesDb.Where(x => x.Id == newEvent.NFLGameScheduleId).FirstOrDefault();
            string[] weather = NFL_API.GET_NFL.GetWeather(game.homeTeam);

            CommentSearchModel model = new CommentSearchModel() { EventId = EventId };
            var PeopleComments = db.Comments.Where(y => y.EventId == model.EventId).ToList();
            PeopleComments.Reverse();
            model.List_Commments = PeopleComments;
            foreach (var item in PeopleComments)
            {
                var userId = db.Comments.FirstOrDefault(a => a.Comments == item.Comments);
                User commentUser = db.UserProfile.FirstOrDefault(b => b.Id == userId.UserId);
                model.UserName = commentUser.UserName;
            }
            Event eventDetail = db.EventDb.FirstOrDefault(y => y.Id == model.EventId);
            model.EventTitle = eventDetail.EventTitle;
            NFLGameSchedule eventSchedule = db.NFLGameSchedulesDb.FirstOrDefault(z => z.Id == eventDetail.NFLGameScheduleId);
            model.gameDate = eventSchedule.gameDate;
            model.gameWeek = eventSchedule.gameWeek;
            model.gameTimeET = eventSchedule.gameTimeET;
            model.homeTeam = eventSchedule.homeTeam;
            model.awayTeam = eventSchedule.awayTeam;
            model.EventComments = eventDetail.EventComments;
            model.stadium   = weather[8] ;
            model.isDome    = weather[9] ;
            model.geoLat    = weather[10];
            model.geoLong   = weather[11];
            model.low       = weather[12];
            model.high      = weather[13];
            model.forecast  = weather[14];
            model.windChill = weather[15];
            model.windSpeed = weather[16];
            model.domeImg   = weather[17];
            model.smallImg  = weather[18];
            model.mediumImg = weather[19];
            model.largeImg  = weather[20];
            return View(model);

        }
        [HttpPost]
        public ActionResult CommentSearch(CommentSearchModel model)
        {
            //var PeopleComments = db.Comments.Where(y => y.EventId == model.EventId).ToList();
            //model.List_Commments = PeopleComments;
            var userId = User.Identity.GetUserId();
            User currentUser = db.UserProfile.FirstOrDefault(x => x.LoginId == userId);
            //model.UserName = currentUser.UserName;
            //Event eventDetail = db.EventDb.FirstOrDefault(y => y.Id == model.EventId);
            //model.EventTitle = eventDetail.EventTitle;
            var comment = new Comment
            {
                UserId = db.UserProfile.Where(x => x.LoginId == userId).FirstOrDefault().Id,
                EventId = model.EventId,
                Comments = model.CommentString
            };
            db.Comments.Add(comment);
            db.SaveChanges();
           return(CommentSearch(model.EventId));
        }
        public ActionResult GoMap(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = db.EventDb.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            return RedirectToAction("EventDisplay", "Events", @event);
        }
    }
}
