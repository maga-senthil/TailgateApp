﻿using Microsoft.Ajax.Utilities;
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
