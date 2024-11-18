using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Arac_Kiralama_Otomasyonu.Models;

namespace Arac_Kiralama_Otomasyonu.Controllers
{
    public class SubelersController : Controller
    {
        private Arac_Kiralama_ProjesiEntities db = new Arac_Kiralama_ProjesiEntities();

        public ActionResult Index()
        {
            return View(db.Subeler.ToList());
        }

        // GET: Subelers

        // GET: Subelers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subeler subeler = db.Subeler.Find(id);
            if (subeler == null)
            {
                return HttpNotFound();
            }
            return View(subeler);
        }

        // GET: Subelers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Subelers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "sube_no,sube_ad,adres,telefon")] Subeler subeler)
        {
            if (ModelState.IsValid)
            {
                db.Subeler.Add(subeler);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(subeler);
        }

        // GET: Subelers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subeler subeler = db.Subeler.Find(id);
            if (subeler == null)
            {
                return HttpNotFound();
            }
            return View(subeler);
        }

        // POST: Subelers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "sube_no,sube_ad,adres,telefon")] Subeler subeler)
        {
            if (ModelState.IsValid)
            {
                db.Entry(subeler).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(subeler);
        }

        // GET: Subelers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subeler subeler = db.Subeler.Find(id);
            if (subeler == null)
            {
                return HttpNotFound();
            }
            return View(subeler);
        }

        // POST: Subelers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Subeler subeler = db.Subeler.Find(id);
            db.Subeler.Remove(subeler);
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
