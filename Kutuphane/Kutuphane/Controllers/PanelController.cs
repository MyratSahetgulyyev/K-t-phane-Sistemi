using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Kutuphane.Models.Entity;

namespace Kutuphane.Controllers
{
    public class PanelController : Controller
    {
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        // GET: Panelhttp
        [HttpGet]
        [Authorize]
        public ActionResult Index()
        {
            var mails = (string)Session["mail"];
            var degerler = db.TBLUYELER.FirstOrDefault(x => x.MAIL == mails);

            return View(degerler);
        }

        [HttpPost]
        public ActionResult Index2(TBLUYELER p)
        {
            var dgr = (string)Session["mail"];
            var uye = db.TBLUYELER.FirstOrDefault(x => x.MAIL == dgr);
            uye.SIFRE = p.SIFRE;
            uye.AD = p.AD;
            uye.SOYAD = p.SOYAD;
            uye.KULLANICIADI = p.KULLANICIADI;
            uye.FOTOGRAF = p.FOTOGRAF;
            uye.OKUL = p.OKUL;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Kitaplarim()
        {
            var uyemail = (string)Session["mail"];
            var id = db.TBLUYELER.Where(x => x.MAIL == uyemail.ToString()).Select(z => z.ID).FirstOrDefault();
            var veriler = db.TBLHAREKET.Where(x => x.ID==id).ToList();
            return View(veriler);
        }
        public ActionResult CikisYap()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("GirisYap", "Login");
        }

    }
}