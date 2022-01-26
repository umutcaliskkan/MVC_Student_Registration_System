using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OgrenciKayitSistemiMvc.Controllers
{
    public class HesapController : Controller
    {
        // GET: Hesap
        public ActionResult Index(double sayi1=0,double sayi2=0)
        {
            double toplamsonuc = sayi1 + sayi2;
            double cikarmasonuc = sayi1 - sayi2;
            double bolmesonuc = sayi1 / sayi2;
            double carpmasonuc = sayi1 * sayi2;
            ViewBag.snctoplam = toplamsonuc;
            ViewBag.snccikarma = cikarmasonuc;
            ViewBag.sncbolme = bolmesonuc;
            ViewBag.snccarpma = carpmasonuc;//controllerdeki degeri viewe taşıma
            return View();
        }
    }
}