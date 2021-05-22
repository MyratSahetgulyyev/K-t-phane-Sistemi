using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kutuphane.Models.Entity;

namespace Kutuphane.Controllers
{
    public class KitapController : Controller
    {
        // GET: Kitap
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        public ActionResult Index(string p)
        {
            //var kitaplar = db.KITAP.ToList();
            var kitaplar = from k in db.KITAP select k;
            if (!string.IsNullOrEmpty(p))
            {
                kitaplar = kitaplar.Where(m => m.AD.Contains(p));
            }
            return View(kitaplar.ToList());
        }

        
        [HttpGet]
        public ActionResult KitapEkle()
        {
            //DopDownlist ile veri tabanından texboxa veri çekmek
            List<SelectListItem> dgr1 = (from i in db.TBLKATEGORI.ToList()
                                         select new SelectListItem
                                         {
                                             Text = i.AD,
                                             Value = i.ID.ToString()
                                         }).ToList();
            ViewBag.deger1 = dgr1;
            //////////////////////////////////////////////////////////
            List<SelectListItem> dgr2 = (from i in db.TBLYAZAR.ToList()
                                         select new SelectListItem
                                         {
                                             Text = i.AD +" "+ i.SOYAD,
                                             Value = i.ID.ToString()
                                         }).ToList();
            ViewBag.deger2 = dgr2;
            return View();
        }


        [HttpPost]
        public ActionResult KitapEkle (KITAP p)
        {
            var ktgr = db.TBLKATEGORI.Where(k => k.ID == p.TBLKATEGORI.ID).FirstOrDefault();
            var yzr = db.TBLYAZAR.Where(k => k.ID == p.TBLYAZAR.ID).FirstOrDefault();
            p.TBLKATEGORI = ktgr;
            p.TBLYAZAR = yzr;
            db.KITAP.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KitapSil(int id)
        {
            var ktp = db.KITAP.Find(id);
            db.KITAP.Remove(ktp);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KitapGetir(int id)
        {
            var ktp = db.KITAP.Find(id);
            List<SelectListItem> dgr1 = (from i in db.TBLKATEGORI.ToList()
                                         select new SelectListItem
                                         {
                                             Text = i.AD,
                                             Value = i.ID.ToString()
                                         }).ToList();
            ViewBag.deger1 = dgr1;
            
            List<SelectListItem> dgr2 = (from i in db.TBLYAZAR.ToList()
                                         select new SelectListItem
                                         {
                                             Text = i.AD+" "+i.SOYAD,
                                             Value = i.ID.ToString()
                                         }).ToList();
            ViewBag.deger2 = dgr2;
            return View("KitapGetir", ktp);
        }

        public ActionResult KitapGuncelle (KITAP p)
        {
            var kitap = db.KITAP.Find(p.ID);
            kitap.AD = p.AD;
            kitap.BASIMYIL = p.BASIMYIL;
            kitap.SAYFA = p.SAYFA;
            kitap.YAYINEVI = p.YAYINEVI;
            var ktg = db.TBLKATEGORI.Where(k => k.ID == p.TBLKATEGORI.ID).FirstOrDefault();
            var yzr = db.TBLYAZAR.Where(y => y.ID == p.TBLYAZAR.ID).FirstOrDefault();
            kitap.KATEGORI = ktg.ID;
            kitap.YAZAR = yzr.ID;
            kitap.DURUM = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        
    }
}