using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using TailgateLive.Models;
using System.Web.Security;
using System.Data.Entity.Infrastructure;

namespace TailgateLive.Controllers
{
    public class EventsController : Controller
    {
        

        private ApplicationDbContext db = new ApplicationDbContext();


        // GET: Events
        public ActionResult Index(NFLGameSchedule nFLGameSchedule)
        {

            return View(db.EventDb.ToList());
        }

        // GET: Events/Details/5
        public ActionResult Details(int? id)
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
            return View(@event);
        }

        // GET: Events/Create
        public ActionResult Create(NFLGameSchedule nFLGameSchedule)
        {
            return View();
        }

        // POST: Events/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create([Bind(Include = "Id,EventTitle,EventDate,EventRating,EventStatus,EventComments,Users,NFLGameScheduleId")] Event @event)
        {

            
            string userId = User.Identity.GetUserId();
            User currentUser = db.UserProfile.FirstOrDefault(x => x.LoginId == userId);
            @event.Users = new List<User>();
            @event.Users.Add(currentUser);
            if (ModelState.IsValid)
            {
                db.EventDb.Add(@event);
                currentUser.Events.Add(@event);
                db.SaveChanges();
                int eventId = @event.Id;
               return RedirectToAction("EventDisplay", new { id = eventId });
            }

            return View(@event);
        }
        

        // GET: Events/Edit/5
        public ActionResult Edit(int? id)
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
            return View(@event);
        }

        // POST: Events/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Edit([Bind(Include = "Id,EventTitle,EventDate,EventRating,EventStatus,EventComments,Latitude,Longitude,UserId")] Event @event)

        {
            if (ModelState.IsValid)
            {
                db.Entry(@event).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(@event);
        }

        // GET: Events/Delete/5
        public ActionResult Delete(int? id)
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
            return View(@event);
        }

        // POST: Events/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Event @event = db.EventDb.Find(id);
            db.EventDb.Remove(@event);
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



        
        public ActionResult EventDisplay(int? id)
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
            return View(@event);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EventDisplay([Bind(Include = "Id,EventTitle,EventDate,EventRating,EventStatus,EventComments,Latitude,Longitude")] Event @event)
        {
            if (ModelState.IsValid)
            {
                db.Entry(@event).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("HostEventView");
            }
            return View(@event);
        }

        public ActionResult HostEventView()
        {
            return View();
        }


        public ActionResult EventIndex(int EventId)
        {
            var EventDetails = db.EventDb.Where(x => x.Id == EventId).FirstOrDefault();
            return View(EventDetails);
        }
        public ActionResult CommentSearch(int EventId)
        {
            return View(new CommentSearchModel() { EventId = EventId });
        }
        [HttpPost]
        public ActionResult CommentSearch(CommentSearchModel model)
        {
            var PeopleComments = db.Comments.Where(y => y.EventId == model.EventId).ToList();
            model.List_Commments = PeopleComments;
            var userId = User.Identity.GetUserId();
            var comment = new Comment
            {
                UserId = db.UserProfile.Where(x => x.LoginId == userId).FirstOrDefault().Id,
                EventId = model.EventId,
                Comments = model.CommentString
            };
            db.Comments.Add(comment);
            db.SaveChanges();

            return View(model);

        }


    }
}
