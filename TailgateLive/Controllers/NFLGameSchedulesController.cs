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
    public class NFLGameSchedulesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: NFLGameSchedules
        public ActionResult Index()
        {
            return View(db.NFLGameSchedulesDb.ToList());
        }

        // GET: NFLGameSchedules/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NFLGameSchedule nFLGameSchedule = db.NFLGameSchedulesDb.Find(id);
            if (nFLGameSchedule == null)
            {
                return HttpNotFound();
            }
            return View(nFLGameSchedule);
        }

        // GET: NFLGameSchedules/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NFLGameSchedules/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,gameId,gameWeek,gameDate,awayTeam,homeTeam,gameTimeET,tvStation,winner")] NFLGameSchedule nFLGameSchedule)
        {
            //if (ModelState.IsValid)
            //{
            //    db.NFLGameSchedulesDb.Add(nFLGameSchedule);
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}

            //return View(nFLGameSchedule);

           
            NFLGameSchedule tempSchedule = new NFLGameSchedule();
            List<List<string>> scheduleList = new List<List<string>>();
            scheduleList = NFL_API.GET_NFL.RunAsyncSchedule();
            for (int i = 0; i < scheduleList.Count; i++)
            {
                tempSchedule.gameId = scheduleList[i][0];
                tempSchedule.gameWeek = scheduleList[i][1];
                tempSchedule.gameDate = scheduleList[i][2];
                tempSchedule.awayTeam = scheduleList[i][3];
                tempSchedule.homeTeam = scheduleList[i][4];
                tempSchedule.gameTimeET = scheduleList[i][5];
                tempSchedule.tvStation = scheduleList[i][6];
                tempSchedule.winner = scheduleList[i][7];
                db.NFLGameSchedulesDb.Add(tempSchedule);
                db.SaveChanges();
            }
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            return View(nFLGameSchedule);
        }

        // GET: NFLGameSchedules/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NFLGameSchedule nFLGameSchedule = db.NFLGameSchedulesDb.Find(id);
            if (nFLGameSchedule == null)
            {
                return HttpNotFound();
            }
            return View(nFLGameSchedule);
        }

        // POST: NFLGameSchedules/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,gameId,gameWeek,gameDate,awayTeam,homeTeam,gameTimeET,tvStation,winner")] NFLGameSchedule nFLGameSchedule)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nFLGameSchedule).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nFLGameSchedule);
        }

        // GET: NFLGameSchedules/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NFLGameSchedule nFLGameSchedule = db.NFLGameSchedulesDb.Find(id);
            if (nFLGameSchedule == null)
            {
                return HttpNotFound();
            }
            return View(nFLGameSchedule);
        }

        // POST: NFLGameSchedules/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NFLGameSchedule nFLGameSchedule = db.NFLGameSchedulesDb.Find(id);
            db.NFLGameSchedulesDb.Remove(nFLGameSchedule);
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
        public ActionResult CreateEvent(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NFLGameSchedule nFLGameSchedule = db.NFLGameSchedulesDb.Find(id);
            if (nFLGameSchedule == null)
            {
                return HttpNotFound();
            }
            return RedirectToAction("Create", "Events", nFLGameSchedule);
        }
        public ActionResult ViewEvents(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NFLGameSchedule nFLGameSchedule = db.NFLGameSchedulesDb.Find(id);
            if (nFLGameSchedule == null)
            {
                return HttpNotFound();
            }
            return RedirectToAction("Index", "Events", nFLGameSchedule);
        }
    }
}
