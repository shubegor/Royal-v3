using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Hotel.Models;

namespace Hotel.Controllers
{
    public class WeeksController : Controller
    {
        private HotelContext db = new HotelContext();

        // GET: Weeks
        public ActionResult Index()
        {
            return View(db.Weeks.ToList());
        }

        // GET: Weeks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Week week = db.Weeks.Find(id);
            if (week == null)
            {
                return HttpNotFound();
            }
            return View(week);
        }

        // GET: Weeks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Weeks/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Day,Coefficient")] Week week)
        {
            if (ModelState.IsValid)
            {
                db.Weeks.Add(week);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(week);
        }

        // GET: Weeks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Week week = db.Weeks.Find(id);
            if (week == null)
            {
                return HttpNotFound();
            }
            return View(week);
        }

        // POST: Weeks/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Day,Coefficient")] Week week)
        {
            if (ModelState.IsValid)
            {
                db.Entry(week).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(week);
        }

        // GET: Weeks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Week week = db.Weeks.Find(id);
            if (week == null)
            {
                return HttpNotFound();
            }
            return View(week);
        }

        // POST: Weeks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Week week = db.Weeks.Find(id);
            db.Weeks.Remove(week);
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
