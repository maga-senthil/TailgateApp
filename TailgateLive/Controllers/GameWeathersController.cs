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
    public class GameWeathersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: GameWeathers
        public ActionResult Index()
        {
            return View(db.GameWeathers.ToList());
        }

        // GET: GameWeathers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GameWeather gameWeather = db.GameWeathers.Find(id);
            if (gameWeather == null)
            {
                return HttpNotFound();
            }
            return View(gameWeather);
        }

        // GET: GameWeathers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GameWeathers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,gameId,gameWeek,gameDate,awayTeam,homeTeam,gameTimeET,tvStation,winner,stadium,isDome,geoLat,geoLong,low,high,forecast,windChill,windSpeed,domeImg,smallImg,mediumImg,largeImg")] GameWeather gameWeather)
        {
        //    if (ModelState.IsValid)
        //    {
        //        db.GameWeathers.Add(gameWeather);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(gameWeather);
        //}

        GameWeather tempWeather = new GameWeather();
        List<List<string>> weatherList = new List<List<string>>();
        weatherList = NFL_API.GET_NFL.RunAsyncWeather();
            for (int i = 0; i<weatherList.Count; i++)
            {
                tempWeather.gameId      = weatherList[i][0];
                tempWeather.gameWeek    = weatherList[i][1];
                tempWeather.gameDate    = weatherList[i][2];
                tempWeather.awayTeam    = weatherList[i][3];
                tempWeather.homeTeam    = weatherList[i][4];
                tempWeather.gameTimeET  = weatherList[i][5];
                tempWeather.tvStation   = weatherList[i][6];
                tempWeather.winner      = weatherList[i][7];
                tempWeather.stadium     = weatherList[i][8];
                tempWeather.isDome      = weatherList[i][9];
                tempWeather.geoLat      = weatherList[i][10];
                tempWeather.geoLong     = weatherList[i][11];
                tempWeather.low         = weatherList[i][12];
                tempWeather.high        = weatherList[i][13];
                tempWeather.forecast    = weatherList[i][14];
                tempWeather.windChill   = weatherList[i][15];
                tempWeather.windSpeed   = weatherList[i][16];
                tempWeather.domeImg     = weatherList[i][17];
                tempWeather.smallImg    = weatherList[i][18];
                tempWeather.mediumImg   = weatherList[i][19];
                tempWeather.largeImg    = weatherList[i][20];

                db.GameWeathers.Add(tempWeather);
                db.SaveChanges();
            }
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            return View(gameWeather);
        }

        // GET: GameWeathers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GameWeather gameWeather = db.GameWeathers.Find(id);
            if (gameWeather == null)
            {
                return HttpNotFound();
            }
            return View(gameWeather);
        }

        // POST: GameWeathers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,gameId,gameWeek,gameDate,awayTeam,homeTeam,gameTimeET,tvStation,winner,stadium,isDome,geoLat,geoLong,low,high,forecast,windChill,windSpeed,domeImg,smallImg,mediumImg,largeImg")] GameWeather gameWeather)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gameWeather).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(gameWeather);
        }

        // GET: GameWeathers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GameWeather gameWeather = db.GameWeathers.Find(id);
            if (gameWeather == null)
            {
                return HttpNotFound();
            }
            return View(gameWeather);
        }

        // POST: GameWeathers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GameWeather gameWeather = db.GameWeathers.Find(id);
            db.GameWeathers.Remove(gameWeather);
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
