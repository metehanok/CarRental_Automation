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
    public class YoneticisController : Controller
    {
        private Arac_Kiralama_ProjesiEntities db = new Arac_Kiralama_ProjesiEntities();

        // GET: Yoneticis
        public ActionResult Index()
        {
            var yonetici = db.Yonetici.Include(y => y.KullaniciRolleri).Include(y => y.Subeler);
            return View(yonetici.ToList());
        }

        // GET: Yoneticis/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Yonetici yonetici = db.Yonetici.Find(id);
            if (yonetici == null)
            {
                return HttpNotFound();
            }
            return View(yonetici);
        }

        // GET: Yoneticis/Create
        public ActionResult Create()
        {
            ViewBag.rol_id = new SelectList(db.KullaniciRolleri, "rol_no", "rol_ad");
            ViewBag.sube_id = new SelectList(db.Subeler, "sube_no", "sube_ad");
            return View();
        }

        // POST: Yoneticis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "yonetici_no,ad,soyad,email,sifre,telefon,rol_id,sube_id")] Yonetici yonetici)
        {
            if (ModelState.IsValid)
            {
                db.Yonetici.Add(yonetici);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.rol_id = new SelectList(db.KullaniciRolleri, "rol_no", "rol_ad", yonetici.rol_id);
            ViewBag.sube_id = new SelectList(db.Subeler, "sube_no", "sube_ad", yonetici.sube_id);
            return View(yonetici);
        }

        // GET: Yoneticis/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Yonetici yonetici = db.Yonetici.Find(id);
            if (yonetici == null)
            {
                return HttpNotFound();
            }
            ViewBag.rol_id = new SelectList(db.KullaniciRolleri, "rol_no", "rol_ad", yonetici.rol_id);
            ViewBag.sube_id = new SelectList(db.Subeler, "sube_no", "sube_ad", yonetici.sube_id);
            return View(yonetici);
        }

        // POST: Yoneticis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "yonetici_no,ad,soyad,email,sifre,telefon,rol_id,sube_id")] Yonetici yonetici)
        {
            if (ModelState.IsValid)
            {
                db.Entry(yonetici).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.rol_id = new SelectList(db.KullaniciRolleri, "rol_no", "rol_ad", yonetici.rol_id);
            ViewBag.sube_id = new SelectList(db.Subeler, "sube_no", "sube_ad", yonetici.sube_id);
            return View(yonetici);
        }

        // GET: Yoneticis/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Yonetici yonetici = db.Yonetici.Find(id);
            if (yonetici == null)
            {
                return HttpNotFound();
            }
            return View(yonetici);
        }

        // POST: Yoneticis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Yonetici yonetici = db.Yonetici.Find(id);
            db.Yonetici.Remove(yonetici);
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
