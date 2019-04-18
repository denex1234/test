using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MagazaMvc.Models;
using System.Web.Security;

namespace MagazaMvc.Areas.Yonetim.Controllers
{
    public class AdminController : Controller
    {
        // GET: Yonetim/Admin
        MagazaContext db = new MagazaContext();
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Kullanici model)
        {
            var kullanicivarmi = db.Kullanicilar.Where(m => m.KullaniciAdi == model.KullaniciAdi && m.KullaniciSifre == model.KullaniciSifre).FirstOrDefault();

            if (kullanicivarmi == null)
            {
                ViewBag.Mesaj = "Kullanıcı Adı veya Şifresi Hatalı";
                return View(model);
            }
            else
            {
                FormsAuthentication.SetAuthCookie(model.KullaniciAdi, true);
                return Redirect("/Yonetim/Urun/Listele");
            }
         
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("login");
        }
    }
}