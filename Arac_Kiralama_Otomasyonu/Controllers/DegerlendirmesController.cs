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
    public class DegerlendirmesController : Controller
    {
        private Arac_Kiralama_ProjesiEntities db = new Arac_Kiralama_ProjesiEntities();

        // GET: Degerlendirmes
        public ActionResult Index()
        {
            var degerlendirme = db.Degerlendirme.Include(d => d.Araclar).Include(d => d.Musteriler);
            return View(degerlendirme.ToList());
        }

        // GET: Degerlendirmes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Degerlendirme degerlendirme = db.Degerlendirme.Find(id);
            if (degerlendirme == null)
            {
                return HttpNotFound();
            }
            return View(degerlendirme);
        }

        // GET: Degerlendirmes/Create
        public ActionResult Create()
        {
            ViewBag.arac_id = new SelectList(db.Araclar, "arac_no", "marka");
            ViewBag.musteri_id = new SelectList(db.Musteriler, "musteri_no", "ad");
            return View();
        }

        // POST: Degerlendirmes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "degerlendirme_no,musteri_id,arac_id,puan,yorum,inceleme_tarihi")] Degerlendirme degerlendirme)
        {
            if (ModelState.IsValid)
            {
                db.Degerlendirme.Add(degerlendirme);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.arac_id = new SelectList(db.Araclar, "arac_no", "marka", degerlendirme.arac_id);
            ViewBag.musteri_id = new SelectList(db.Musteriler, "musteri_no", "ad", degerlendirme.musteri_id);
            return View(degerlendirme);
        }

        // GET: Degerlendirmes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Degerlendirme degerlendirme = db.Degerlendirme.Find(id);
            if (degerlendirme == null)
            {
                return HttpNotFound();
            }
            ViewBag.arac_id = new SelectList(db.Araclar, "arac_no", "marka", degerlendirme.arac_id);
            ViewBag.musteri_id = new SelectList(db.Musteriler, "musteri_no", "ad", degerlendirme.musteri_id);
            return View(degerlendirme);
        }

        // POST: Degerlendirmes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "degerlendirme_no,musteri_id,arac_id,puan,yorum,inceleme_tarihi")] Degerlendirme degerlendirme)
        {
            if (ModelState.IsValid)
            {
                db.Entry(degerlendirme).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.arac_id = new SelectList(db.Araclar, "arac_no", "marka", degerlendirme.arac_id);
            ViewBag.musteri_id = new SelectList(db.Musteriler, "musteri_no", "ad", degerlendirme.musteri_id);
            return View(degerlendirme);
        }

        // GET: Degerlendirmes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Degerlendirme degerlendirme = db.Degerlendirme.Find(id);
            if (degerlendirme == null)
            {
                return HttpNotFound();
            }
            return View(degerlendirme);
        }

        // POST: Degerlendirmes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Degerlendirme degerlendirme = db.Degerlendirme.Find(id);
            db.Degerlendirme.Remove(degerlendirme);
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
