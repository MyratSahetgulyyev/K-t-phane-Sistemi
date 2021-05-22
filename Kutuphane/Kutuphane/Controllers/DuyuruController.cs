using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kutuphane.Models.Entity;

namespace Kutuphane.Controllers
{
    public class DuyuruController : Controller
    {
        // GET: Duyuru
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        public ActionResult Index()
        {
            var degerler = db.TBLDUYURU.ToList();
            return View(degerler);
        }

        public ActionResult DuyuruGetir(int id)
        {
            var deger = db.TBLDUYURU.Find(id);
            return View(deger);
        }

        [HttpGet]
        public ActionResult DuyuruEkle()
        {
            
            return View();
        }

        [HttpPost]
        public ActionResult DuyuruEkle(TBLDUYURU p)
        {
            db.TBLDUYURU.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DuyuruSil(int id)
        {
            var kategori = db.TBLDUYURU.Find(id);
            db.TBLDUYURU.Remove(kategori);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DuyuruGuncelle(TBLDUYURU d)
        {
            var ktg = db.TBLDUYURU.Find(d.ID);
            ktg.KONU = d.KONU;
            ktg.ICERIK = d.ICERIK;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}