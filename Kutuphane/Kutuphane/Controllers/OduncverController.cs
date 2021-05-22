using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kutuphane.Models.Entity;


namespace Kutuphane.Controllers
{
    public class OduncverController : Controller
    {
        // GET: Oduncver
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();

        public ActionResult Index()
        {
            var veriler = db.TBLHAREKET.Where(x=>x.ISLEMDURUM==false).ToList();
            return View(veriler);
        }

        [HttpGet]
        public ActionResult OduncVer()
        {
            List<SelectListItem> dgruye = (from i in db.TBLUYELER.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.AD + "" + i.SOYAD,
                                               Value = i.ID.ToString()
                                           }).ToList();
            ViewBag.degerU = dgruye;

            List<SelectListItem> dgrkitap = (from i in db.KITAP.Where(x=>x.DURUM==true).ToList()
                                             select new SelectListItem
                                            {
                                                 Text = i.AD,
                                                 Value = i.ID.ToString()
                                             }).ToList();
            ViewBag.degerK = dgrkitap;

            List<SelectListItem> dgrpersonel = (from i in db.TBLPERSONEL.ToList()
                                                select new SelectListItem
                                                {
                                                    Text = i.PERSONEL,
                                                    Value = i.ID.ToString()
                                                }).ToList();
            ViewBag.degerP = dgrpersonel;
            return View();
        }
        [HttpPost]
        public ActionResult OduncVer(TBLHAREKET p)
        {
            var d1 = db.TBLUYELER.Where(x => x.ID == p.TBLUYELER.ID).FirstOrDefault();
            var d2 = db.KITAP.Where(x => x.ID == p.KITAP1.ID).FirstOrDefault();
            var d3 = db.TBLPERSONEL.Where(x => x.ID == p.TBLPERSONEL.ID).FirstOrDefault();
            p.TBLUYELER = d1;
            p.KITAP1 = d2;
            p.TBLPERSONEL =d3;
            db.TBLHAREKET.Add(p); 
            db.SaveChanges();
            return RedirectToAction("Index");
        }

         public ActionResult OduncGetir (TBLHAREKET p)
        {
            var deger = db.TBLHAREKET.Find(p.ID);
            DateTime zmn1 = DateTime.Parse(deger.IADETARIH.ToString());
            //DateTime zmn = DateTime.Parse(deger.IADETARIH.ToString());
            DateTime zmn2 = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            TimeSpan gun = zmn2 - zmn1;
            ViewBag.dgr = gun.TotalDays;

            return View("OduncGetir", deger);
        }


        public ActionResult OduncGuncelle(TBLHAREKET p)
        {
            var hrkt = db.TBLHAREKET.Find(p.ID);
            hrkt.MUSTEGETITARIH = p.MUSTEGETITARIH;
            hrkt.ISLEMDURUM = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}