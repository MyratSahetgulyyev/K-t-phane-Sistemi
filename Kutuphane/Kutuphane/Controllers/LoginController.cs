using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kutuphane.Models.Entity;
using System.Web.Security;


namespace Kutuphane.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        public ActionResult GirisYap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult GirisYap(TBLUYELER p)
        {
            var bilgi = db.TBLUYELER.FirstOrDefault(x => x.MAIL == p.MAIL && x.SIFRE == p.SIFRE);
            if (bilgi != null)
            {
                FormsAuthentication.SetAuthCookie(bilgi.MAIL, false);
                Session["mail"] = bilgi.MAIL.ToString();
                //TempData["id"] = bilgi.ID.ToString();
                //TempData["Adi"] = bilgi.AD.ToString();
                //TempData["Soyad"] = bilgi.SOYAD.ToString();
                //TempData["Kul"] = bilgi.KULLANICIADI.ToString();
                //TempData["Sifre"] = bilgi.SIFRE.ToString();
                //TempData["Okul"] = bilgi.OKUL.ToString();
                return RedirectToAction("Index", "Panel");
            }
            else
            {
                return View();
            }
        }
    }
}