using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OgrenciKayitSistemiMvc.Models.EntityFramework; //entitiy kütüphane dahil edildi

namespace OgrenciKayitSistemiMvc.Controllers
{
    public class KuluplerController : Controller
    {
        // GET: Kulupler
        DBOgrenciKayitMvcEntities db = new DBOgrenciKayitMvcEntities();
        public ActionResult Index()
        {
            var kulupler = db.TBLKULUPLER.ToList();
            return View(kulupler);
        }
        [HttpGet]
        public ActionResult YeniKulup()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniKulup(TBLKULUPLER p2)
        {
            db.TBLKULUPLER.Add(p2);
            db.SaveChanges();
            return View();
        }

        public ActionResult Sil(int id)
        {
            var kulup = db.TBLKULUPLER.Find(id);// Yukarıda id den gönderdiğim değere göre tabloda veriyi bul
            db.TBLKULUPLER.Remove(kulup); // kulup degiskeninden gelen degeri kaldı
            db.SaveChanges();
            return RedirectToAction("Index"); //İşlemi yaptıktan sonra index e döndür
        }

        public ActionResult KulupGetir(int id)
        {
            var Kulup = db.TBLKULUPLER.Find(id);

            return View("KulupGetir",Kulup);
        }

        public ActionResult Guncelle(TBLKULUPLER p)
        {
            var klp = db.TBLKULUPLER.Find(p.KULUPID);
            klp.KULUPAD = p.KULUPAD;
            db.SaveChanges();
            return RedirectToAction("Index", "Kulupler");
        }
    }
}