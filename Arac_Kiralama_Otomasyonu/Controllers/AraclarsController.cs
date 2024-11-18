using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Arac_Kiralama_Otomasyonu.Models;
using PagedList;

namespace Arac_Kiralama_Otomasyonu.Controllers
{
    public class AraclarsController : Controller
    {
        Arac_Kiralama_ProjesiEntities db = new Arac_Kiralama_ProjesiEntities();
        // GET: Araclars
        public ActionResult arac_kaydet()
        {
            var subeler = new SelectList(db.Subeler, "sube_no", "sube_ad");
            ViewBag.sube_id = subeler;
            var  arackategori = new SelectList(db.AracKategorileri, "kategori_no", "kategori_ad");
            ViewBag.kategori_id = arackategori;
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> arac_kaydet(Araclar yeni_arac,HttpPostedFileBase dosya_nesnesi)
        {
            string resim_adi = "resimyok.jpg";
            if (dosya_nesnesi != null)
            {
                string uzanti = Path.GetExtension(dosya_nesnesi.FileName);
                if (uzanti.Equals(".jpg") || uzanti.Equals(".png"))
                {
                    int son_arac_no = 0;
                    var enBuyukAracNo = db.Araclar.OrderByDescending(x => x.arac_no).FirstOrDefault();
                    if (enBuyukAracNo != null)
                    {
                        son_arac_no = enBuyukAracNo.arac_no;
                    }
                    son_arac_no += 1;
                    resim_adi = Path.GetFileName(dosya_nesnesi.FileName);
                    string tam_yol = Path.Combine(Server.MapPath("~/arac_resimleri/"), resim_adi);
                    dosya_nesnesi.SaveAs(tam_yol);
                    ViewBag.msj = "Görsel başarı ile yüklendi ve kayıt tamamlandı";
                    yeni_arac.arac_no = son_arac_no; // Arac nesnesine arac_no değerini atayın
                    yeni_arac.resim= resim_adi;
                    db.Araclar.Add(yeni_arac);
                    await db.SaveChangesAsync();
                    /* int son_arac_no = db.Araclar.Max(x => x.arac_no);
                     son_arac_no += 1;
                     resim_adi = Path.GetFileName(dosya_nesnesi.FileName);
                     string tam_yol = Server.MapPath("~/arac_resimleri/")+resim_adi;
                     dosya_nesnesi.SaveAs(tam_yol);
                     ViewBag.msj = "Görsel başarı ile yüklendi ve kayıt tamamlandı";
                     yeni_arac.resim = resim_adi;
                     db.Araclar.Add(yeni_arac);
                     await db.SaveChangesAsync();*/

                }
                else
                {
                    ViewBag.msj = "Lütfen resim dosyası seçiniz";
                }
            }
            else
            {
                ViewBag.msj = "Araç resimsiz bir şekilde kaydedildi";
                yeni_arac.resim = resim_adi;
                db.Araclar.Add(yeni_arac);
                await db.SaveChangesAsync();
            }
            var subeler = new SelectList(db.Subeler, "sube_no", "sube_ad");
            ViewBag.sube_id = subeler;
            var arackategori = new SelectList(db.AracKategorileri, "kategori_no", "kategori_ad");
            ViewBag.kategori_id = arackategori;
            return View();
        }
        public ActionResult arac_goster(int? sayfa,int?id)
        {
            var sayfa_no = sayfa ?? 1;
            var arac_listesi = db.Araclar.Where(x => x.kategori_id == id).ToList().ToPagedList(sayfa_no, 8);
            return View(arac_listesi);
        }
        public ActionResult arac_kategorileri()
        {
            var kategoriler = db.AracKategorileri.Select(x => x.kategori_ad).ToList();
            return View(kategoriler);
        }

    }
}