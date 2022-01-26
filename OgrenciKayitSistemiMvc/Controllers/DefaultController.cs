using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OgrenciKayitSistemiMvc.Models.EntityFramework; //Db için kütüphane çağırıldı

namespace OgrenciKayitSistemiMvc.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        DBOgrenciKayitMvcEntities db = new DBOgrenciKayitMvcEntities();
        public ActionResult Index()
        {
            var dersler = db.TBLDERSLER.ToList();
            return View(dersler);
        }
        [HttpGet]
        public ActionResult YeniDers()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniDers(TBLDERSLER p)
        {
            db.TBLDERSLER.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Sil(int id)
        {
            var ders = db.TBLDERSLER.Find(id); //Dersler tablosunda id degiskenine göre bul
            db.TBLDERSLER.Remove(ders); // ders değişkenine göre sil
            db.SaveChanges();//Komutları kaydet
            return RedirectToAction("Index"); // Index e geri döndür
        }

        public ActionResult DersGetir(int id)
        {
            var ders = db.TBLDERSLER.Find(id);
            
            return View("DersGetir",ders);
        }

        public ActionResult Guncelle(TBLDERSLER p)
        {
            var drs = db.TBLDERSLER.Find(p.DERSID);
            drs.DERSAD = p.DERSAD;
            db.SaveChanges();
            return RedirectToAction("Index", "Default");
        }
    }
}