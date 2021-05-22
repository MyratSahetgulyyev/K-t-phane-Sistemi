using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kutuphane.Models.Entity;

namespace Kutuphane.Controllers
{
    public class YazarController : Controller
    {
        // GET: Yazar
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        public ActionResult Index()
        {
            var degerler = db.TBLYAZAR.ToList();
            db.SaveChanges();
            return View(degerler);
        }


        [HttpGet]
        public ActionResult YazarEkle ()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YazarEkle(TBLYAZAR p)
        {
            if (!ModelState.IsValid)
            {
                return View("YazarEkle");
            }
            db.TBLYAZAR.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult YazarSil (int id) 
        {
            var yazar = db.TBLYAZAR.Find(id);
            db.TBLYAZAR.Remove(yazar);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult YazarGetir (int id)
        {
            var yzr = db.TBLYAZAR.Find(id);
            return View("YazarGetir", yzr);
        }

        public ActionResult YazarGuncelle (TBLYAZAR p)
        {
            var yzr = db.TBLYAZAR.Find(p.ID);
            yzr.ID = p.ID;
            yzr.AD = p.AD;
            yzr.SOYAD = p.SOYAD;
            yzr.DETAY = p.DETAY;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult YazarKitaplar(int id)
        {
            var liste = db.KITAP.Where(x => x.YAZAR == id).ToList();
            var yazar = db.TBLYAZAR.Where(x => x.ID == id).Select(x => x.AD + " " + x.SOYAD).FirstOrDefault();
            ViewBag.soyad = yazar;
            return View(liste);

        }
    }
}