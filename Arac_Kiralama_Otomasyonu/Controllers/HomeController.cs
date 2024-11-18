using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Arac_Kiralama_Otomasyonu.Models;
using Newtonsoft.Json;

namespace Arac_Kiralama_Otomasyonu.Controllers
{

    public class HomeController : Controller
    {
        Arac_Kiralama_ProjesiEntities db = new Arac_Kiralama_ProjesiEntities();


        /* public ActionResult login_giris()
         {

             return PartialView();
         }
         [HttpPost]
         public async Task<ActionResult> login_giris(Musteriler gelen_musteri)
         {
             var musterim = await db.Musteriler.FirstOrDefaultAsync(x => x.email == gelen_musteri.email && x.sifre == gelen_musteri.sifre);
             string msj = "";
             if (musterim != null)
             {
                 Session["musterim"] = musterim;
             }
             else
             {
                 msj = "E-mail veya Şifre yanlış";
             }
             return RedirectToAction("index", new { msj });
         }*/

        public ActionResult Index(string msj)
        {
            var subelistesi = db.Subeler.ToList();
            Session["Subeler"] = subelistesi;
            // Session'da "musterim" adında bir değişken varsa ve değeri null değilse, kullanıcı giriş yapmış demektir.
            if (Session["musterim"] != null)
            {
                ViewBag.IsLoggedIn = true;
            }
            else
            {
                ViewBag.IsLoggedIn = false;
            }

            ViewBag.msj = msj;
            return View();
        }

        [HttpGet]
        public ActionResult musteri_girisi()
        {

            return View();
        }
        [HttpPost]
        public async Task<ActionResult> musteri_girisi(Musteriler gelen_musteri)
        {
            var musterim = await db.Musteriler.FirstOrDefaultAsync(x => x.email == gelen_musteri.email && x.sifre == gelen_musteri.sifre);
            string msj = "";
            if (musterim != null)
            {
                FormsAuthentication.SetAuthCookie(musterim.email, false);
                Session["musterim"] = musterim;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                msj = "E-mail veya Şifre yanlış";
                ViewBag.ErrorMessage = msj;
                return View("musteri_girisi", "Home", new { msj });
            }

        }
        public ActionResult kategori_doldur()
        {

            var arac_listem = db.AracKategorileri.ToList();
            return PartialView(arac_listem);
        }
        public ActionResult guv_cikis()
        {
            Session.RemoveAll();//sessionu kaldırır
            Session.Abandon();
            return RedirectToAction("index");//ve index yani anasayfaya yönlendirir.
        }
        public ActionResult kategori_getir()
        {
            var arac_listem = db.AracKategorileri.ToList();
            return PartialView(arac_listem);

        }
        public ActionResult BizeUlasin()
        {
            return PartialView("bize_ulasin", "Home");
        }
        public ActionResult hakkımızda()
        {
            return PartialView("hakkimizda", "Home");
        }
        [HttpPost]
        public ActionResult SendMessage()
        {
            // Mesajı gönderme işlemleri...
            return Content("Talebiniz başarı ile alınmıştır, iyi günler dileriz");
        }

    }
}
