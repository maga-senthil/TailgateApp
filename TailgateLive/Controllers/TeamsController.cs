﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TailgateLive.Models;
using System.Threading.Tasks;

namespace TailgateLive.Controllers
{
    public class TeamsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Teams
        public ActionResult Index()
        {
            return View(db.TeamDb.ToList());
        }

        // GET: Teams/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Team team = db.TeamDb.Find(id);
            if (team == null)
            {
                return HttpNotFound();
            }
            return View(team);
        }

        // GET: Teams/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Teams/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult CreateOld([Bind(Include = "Id,TeamName")] Team team)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.TeamDb.Add(team);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(team);
        //}

        public ActionResult Create([Bind(Include = "Id,TeamName")] Team team)
        {
            Team tempTeam = new Team();
            foreach (string t in GetTeamNames())
            {
                tempTeam.TeamName = t;
                db.TeamDb.Add(tempTeam);
                db.SaveChanges();
            }
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            return View(team);
        }
        public List<string> GetTeamNames()
        {
            List<List<string>> teamsList = new List<List<string>>();
            teamsList = NFL_API.GET_NFL.RunAsyncNFLTeam();
            List<string> teamNameLong = new List<string>();
            string name;
            for (int i = 0; i < teamsList.Count; i++)
            {
                name = teamsList[i][1];
                teamNameLong.Add(name);
            }
            return teamNameLong;
        }

        // GET: Teams/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Team team = db.TeamDb.Find(id);
            if (team == null)
            {
                return HttpNotFound();
            }
            return View(team);
        }

        // POST: Teams/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,TeamName")] Team team)
        {
            if (ModelState.IsValid)
            {
                db.Entry(team).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(team);
        }

        // GET: Teams/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Team team = db.TeamDb.Find(id);
            if (team == null)
            {
                return HttpNotFound();
            }
            return View(team);
        }

        // POST: Teams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Team team = db.TeamDb.Find(id);
            db.TeamDb.Remove(team);
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
