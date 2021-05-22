using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kutuphane.Models.Entity;

namespace Kutuphane.Controllers
{
    public class MesajlarController : Controller
    {
        // GET: Mesajlar
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        [Authorize]
        public ActionResult Index()
        {
            var uyemesaj = (string)Session["mail"];
            var mesaj = db.TBLMESAJLAR.Where(x => x.ALICI == uyemesaj).ToList();
            return View(mesaj);
        }
        [Authorize]
        public ActionResult Giden()
        {
            var uyemesaj = (string)Session["mail"];
            var mesaj = db.TBLMESAJLAR.Where(x => x.GONDEREN == uyemesaj).ToList();
            return View(mesaj);
        }

        [Authorize]
        [HttpGet]
        public ActionResult YeniMesaj()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniMesaj(TBLMESAJLAR t)
        {
            var uyemesaj = (string)Session["mail"];
            t.GONDEREN = uyemesaj.ToString();
            t.TARIH = DateTime.Parse(DateTime.Now.ToShortDateString());
            db.TBLMESAJLAR.Add(t);
            db.SaveChanges();
            return RedirectToAction("Giden", "Mesajlar");
        }
    }
}