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
    public class RezervasyonlarsController : Controller
    {
        private Arac_Kiralama_ProjesiEntities db = new Arac_Kiralama_ProjesiEntities();

        // GET: Rezervasyonlars
        public ActionResult Index()
        {

            if (Session["musterim"]!=null)
            {
                // Kullanıcı giriş yapmışsa, sadece bu kullanıcıya ait rezervasyonları getir
                int musteriID = ((Musteriler)Session["musterim"]).musteri_no;
                var rezervasyonlar = db.Rezervasyonlar.Include(r => r.Araclar).Include(r => r.Musteriler)
                                                     .Where(r => r.musteri_id == musteriID);
                return View(rezervasyonlar.ToList());
            }
            else
            {
                var rezervasyonlar = db.Rezervasyonlar.Include(r => r.Araclar).Include(r => r.Musteriler);
                return View(rezervasyonlar.ToList());
            }
           
        }

        // GET: Rezervasyonlars/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rezervasyonlar rezervasyonlar = db.Rezervasyonlar.Find(id);
            if (rezervasyonlar == null)
            {
                return HttpNotFound();
            }
            return View(rezervasyonlar);
        }

        // GET: Rezervasyonlars/Create
        public ActionResult Create()
        {
            if (Session["musterim"] == null)
            {
                // Kullanıcı giriş yapmamışsa uyarı mesajı oluştur
                ViewBag.ErrorMessage = "Lütfen giriş yapınız.";
            }
            else
            {
                ViewBag.ErrorMessage = null; // Giriş yapılmışsa uyarı mesajını temizle
            }
            ViewBag.arac_id = new SelectList(db.Araclar, "arac_no", "marka");
            ViewBag.musteri_id = new SelectList(db.Musteriler, "musteri_no", "ad");
            return View();
        }

        // POST: Rezervasyonlars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "rezervasyon_no,arac_id,musteri_id,baslangic_tarihi,bitis_tarihi")] Rezervasyonlar rezervasyonlar)
        {
            if (ModelState.IsValid)
            {
                db.Rezervasyonlar.Add(rezervasyonlar);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.arac_id = new SelectList(db.Araclar, "arac_no", "marka", rezervasyonlar.arac_id);
            ViewBag.musteri_id = new SelectList(db.Musteriler, "musteri_no", "ad", rezervasyonlar.musteri_id);
            return View(rezervasyonlar);
        }

        // GET: Rezervasyonlars/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rezervasyonlar rezervasyonlar = db.Rezervasyonlar.Find(id);
            if (rezervasyonlar == null)
            {
                return HttpNotFound();
            }
            ViewBag.arac_id = new SelectList(db.Araclar, "arac_no", "marka", rezervasyonlar.arac_id);
            ViewBag.musteri_id = new SelectList(db.Musteriler, "musteri_no", "ad", rezervasyonlar.musteri_id);
            return View(rezervasyonlar);
        }

        // POST: Rezervasyonlars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "rezervasyon_no,arac_id,musteri_id,baslangic_tarihi,bitis_tarihi")] Rezervasyonlar rezervasyonlar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rezervasyonlar).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.arac_id = new SelectList(db.Araclar, "arac_no", "marka", rezervasyonlar.arac_id);
            ViewBag.musteri_id = new SelectList(db.Musteriler, "musteri_no", "ad", rezervasyonlar.musteri_id);
            return View(rezervasyonlar);
        }

        // GET: Rezervasyonlars/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rezervasyonlar rezervasyonlar = db.Rezervasyonlar.Find(id);
            if (rezervasyonlar == null)
            {
                return HttpNotFound();
            }
            return View(rezervasyonlar);
        }

        // POST: Rezervasyonlars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Rezervasyonlar rezervasyonlar = db.Rezervasyonlar.Find(id);
            db.Rezervasyonlar.Remove(rezervasyonlar);
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
