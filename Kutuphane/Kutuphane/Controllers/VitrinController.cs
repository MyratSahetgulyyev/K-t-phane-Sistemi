using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kutuphane.Models.Entity;
using Kutuphane.Models.Siniflarim;

namespace Kutuphane.Controllers
{
    public class VitrinController : Controller
    {
        // GET: Vitrin
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        public ActionResult Index()
        {
            Class1 cs = new Class1();
            cs.Deger1 = db.KITAP.ToList();
            cs.Deger2 = db.TBLACIKLAMA.ToList();
            return View(cs);
        }
    }
}