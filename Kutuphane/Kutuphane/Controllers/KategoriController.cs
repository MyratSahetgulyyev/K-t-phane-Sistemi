using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kutuphane.Models.Entity;
namespace Kutuphane.Controllers
{
    public class KategoriController : Controller
    {


        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        // GET: Kategori
        public ActionResult Index()
        {
            var degerler = db.TBLKATEGORI.Where(x=>x.DURUM==true).ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult KategoriEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult KategoriEkle (TBLKATEGORI p)
        {
            db.TBLKATEGORI.Add(p);
            db.SaveChanges();
            return View();
        }

        public ActionResult Sil (int id)
        {
            var kategori = db.TBLKATEGORI.Find(id);
            //db.TBLKATEGORI.Remove(kategori);
            kategori.DURUM = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult Getir (int id)
        {
            var ktg = db.TBLKATEGORI.Find(id);
            return View("Getir", ktg);
        }

        public ActionResult KategoriGuncelle(TBLKATEGORI p)
        {
            var ktg = db.TBLKATEGORI.Find(p.ID);
            ktg.AD = p.AD;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}