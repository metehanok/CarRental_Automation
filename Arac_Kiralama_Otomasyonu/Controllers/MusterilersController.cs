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
    public class MusterilersController : Controller
    {
        private Arac_Kiralama_ProjesiEntities db = new Arac_Kiralama_ProjesiEntities();

        // GET: Musterilers
        public ActionResult Index()
        {
            var musteriler = db.Musteriler.Include(m => m.KullaniciRolleri);
            return View(musteriler.ToList());
        }

        // GET: Musterilers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Musteriler musteriler = db.Musteriler.Find(id);
            if (musteriler == null)
            {
                return HttpNotFound();
            }
            return View(musteriler);
        }

        // GET: Musterilers/Create
        public ActionResult Create()
        {
            ViewBag.rol_id = new SelectList(db.KullaniciRolleri, "rol_no", "rol_ad");
            return View();
        }

        // POST: Musterilers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "musteri_no,ad,soyad,email,sifre,telefon,rol_id")] Musteriler musteriler)
        {
            if (ModelState.IsValid)
            {
                musteriler.rol_id = 3;
                db.Musteriler.Add(musteriler);
                db.SaveChanges();
                return RedirectToAction("Index","Home");
            }

            ViewBag.rol_id = new SelectList(db.KullaniciRolleri, "rol_no", "rol_ad", musteriler.rol_id);
            return View(musteriler);
        }

        // GET: Musterilers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Musteriler musteriler = db.Musteriler.Find(id);
            if (musteriler == null)
            {
                return HttpNotFound();
            }
            ViewBag.rol_id = new SelectList(db.KullaniciRolleri, "rol_no", "rol_ad", musteriler.rol_id);
            return View(musteriler);
        }

        // POST: Musterilers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "musteri_no,ad,soyad,email,sifre,telefon,rol_id")] Musteriler musteriler)
        {
            if (ModelState.IsValid)
            {
                musteriler.rol_id = 3;
                db.Entry(musteriler).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.rol_id = new SelectList(db.KullaniciRolleri, "rol_no", "rol_ad", musteriler.rol_id);
            return View(musteriler);
        }

        // GET: Musterilers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Musteriler musteriler = db.Musteriler.Find(id);
            if (musteriler == null)
            {
                return HttpNotFound();
            }
            return View(musteriler);
        }

        // POST: Musterilers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Musteriler musteriler = db.Musteriler.Find(id);
            db.Musteriler.Remove(musteriler);
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
