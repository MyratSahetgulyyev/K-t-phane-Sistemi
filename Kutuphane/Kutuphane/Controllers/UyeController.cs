using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kutuphane.Models.Entity;
using PagedList;
using PagedList.Mvc;
namespace Kutuphane.Controllers
    
{
    public class UyeController : Controller
    {
        // GET: Uye
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        public ActionResult Index( int sayfa=1)
        {
            var veri = db.TBLUYELER.ToList().ToPagedList(sayfa,4);
            return View(veri);
        }



        [HttpGet]
        public ActionResult UyeEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UyeEkle(TBLUYELER u)
        {
            if (!ModelState.IsValid)
            {
                return View("UyeEkle");
            }
            db.TBLUYELER.Add(u);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UyeSil(int id)
        {
            var uye = db.TBLUYELER.Find(id);
            db.TBLUYELER.Remove(uye);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult UyeGetir(int id)
        {
            var uye = db.TBLUYELER.Find(id);
            return View("UyeGetir", uye);
        }

        public ActionResult UyeGuncelle(TBLUYELER u)
        {
            var uye = db.TBLUYELER.Find(u.ID);
            uye.AD = u.AD;
            uye.SOYAD= u.SOYAD;
            uye.MAIL= u.MAIL;
            uye.KULLANICIADI= u.KULLANICIADI;
            uye.SIFRE= u.SIFRE;
            uye.FOTOGRAF= u.FOTOGRAF;
            uye.TELEFON= u.TELEFON;
            uye.OKUL= u.OKUL;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
         public ActionResult UyeKitaplar (int id)
        {
            var uyekitap = db.TBLHAREKET.Where(x => x.UYE == id).ToList();
            var uyead = db.TBLUYELER.Find(id).AD;
            var uyesoyad = db.TBLUYELER.Find(id).SOYAD;
            ViewBag.ad = uyead;
            ViewBag.soyad = uyesoyad;
            return View(uyekitap);
        }

    }
}