using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OgrenciKayitSistemiMvc.Models.EntityFramework; 

namespace OgrenciKayitSistemiMvc.Controllers
{
    public class OgrenciController : Controller
    {
        // GET: Ogrenci
        DBOgrenciKayitMvcEntities db = new DBOgrenciKayitMvcEntities();
        public ActionResult Index()
        {
            var ogrenciler = db.TBLOGRENCILER.ToList(); /*öğrenciler tablosundaki veriler listeye çekildi*/
            return View(ogrenciler);
        }
        [HttpGet]
        public ActionResult YeniOgrenci()
        {
            List<SelectListItem> degerler = (from i in db.TBLKULUPLER.ToList()//kulüpler tablosu gezildi ve listeye alındı
                                             select new SelectListItem
                                             {
                                                 Text = i.KULUPAD, //külüp adı çekildi
                                                 Value = i.KULUPID.ToString(), //kulüp id çekildi
                                             }).ToList();
            ViewBag.dgr = degerler;
            return View();
        }
        [HttpPost]
        public ActionResult YeniOgrenci(TBLOGRENCILER p3)
        {
            var klp = db.TBLKULUPLER.Where(m => m.KULUPID == p3.TBLKULUPLER.KULUPID).FirstOrDefault();//dropdownlisteyi seçileni çekme
            p3.TBLKULUPLER = klp; 
            db.TBLOGRENCILER.Add(p3);//p3 teki degerleri tabloya ekle
            db.SaveChanges();
            return RedirectToAction("Index"); //işlemler yapıldıktan sonra index sayfasına dön
        }

        public ActionResult Sil(int id)
        {
            var ogrenci = db.TBLOGRENCILER.Find(id);//Tabloda id degiskenine göre bul
            db.TBLOGRENCILER.Remove(ogrenci);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult OgrenciGetir(int id)
        {
            var ogrenci = db.TBLOGRENCILER.Find(id); // id ye göre tabloda veriyi bul
            List<SelectListItem> degerler = (from i in db.TBLKULUPLER.ToList()//kulüpler tablosu gezildi ve listeye alındı
                                             select new SelectListItem
                                             {
                                                 Text = i.KULUPAD, //külüp adı çekildi
                                                 Value = i.KULUPID.ToString(), //kulüp id çekildi
                                             }).ToList();
            ViewBag.dgr = degerler;
            return View("OgrenciGetir", ogrenci);
        }

        public ActionResult Guncelle(TBLOGRENCILER p)
        {
            var ogr = db.TBLOGRENCILER.Find(p.OGRENCIID);
            ogr.OGRAD = p.OGRAD;
            ogr.OGRSOYAD = p.OGRSOYAD;
            ogr.OGRFOTO = p.OGRFOTO;
            ogr.OGRCINSIYET = p.OGRCINSIYET;
            ogr.OGRKULUP = p.OGRKULUP;
            db.SaveChanges();
            return RedirectToAction("Index", "Ogrenci");
        }
    }
}