using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kutuphane.Models.Entity;

namespace Kutuphane.Controllers
{
    public class IstatistikController : Controller
    {
        // GET: Istatistik
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        public ActionResult Index()
        {
            var deger1 = db.TBLUYELER.Count();
            ViewBag.dgr1 = deger1;

            var kitap = db.KITAP.Count();
            ViewBag.ktp = kitap;

            var para = db.TBLCEZALAR.Sum(x => x.PARA);
            ViewBag.pr = para;

            var ibk = db.TBLHAREKET.Count(x => x.ISLEMDURUM == true);
            return View();
        }

        public ActionResult Hava()
        {
            return View();
        }

        public ActionResult HavaKart()
        {
            return View();
        }
        public ActionResult Galery()
        {
            return View();
        }


        [HttpPost]
        public ActionResult ResimKayit(HttpPostedFileBase dosya)
        {
            if (dosya.ContentLength > 0)
            {
                string dosyayolu = Path.Combine(Server.MapPath("~/web2/resimler/"), Path.GetFileName(dosya.FileName));
                dosya.SaveAs(dosyayolu);
            }
            return RedirectToAction("Galery");
        }

        public ActionResult LinqKartlar()
        {
            var kitap = db.KITAP.Count();
            ViewBag.ktp = kitap;

            var uyeler = db.TBLUYELER.Count();
            ViewBag.ylr = uyeler;

            var tutar = db.TBLCEZALAR.Sum(x => x.PARA);
            ViewBag.ttr = tutar;

            var odunckitap = db.TBLHAREKET.Where(x => x.ISLEMDURUM == false).Count();
            ViewBag.dncktp = odunckitap;

            var kategori = db.TBLKATEGORI.Count();
            ViewBag.ktgr = kategori;

            var eniyi = db.ENCOKYAZAN().FirstOrDefault();
            ViewBag.iyiyzr = eniyi;

            var eniyiyayievi = db.enyayin1();
            ViewBag.yayev = eniyiyayievi;

            return View();
        }
    }
}