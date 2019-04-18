using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MagazaMvc.Models;

namespace MagazaMvc.Areas.Yonetim.Controllers
{
    [Authorize]
    public class UrunController : Controller
    {
        MagazaContext db = new MagazaContext();
        public ActionResult Listele()
        {
            var liste = db.Urunler.ToList();
            return View(liste);
        }
        public ActionResult Ekle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Ekle(Urun model,HttpPostedFileBase UrunResmi)
        {
            if(ModelState.IsValid)
            {
                if(UrunResmi.FileName!=null)
                {
                    //string dosyaadi = DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day + "-" + DateTime.Now.Hour + "-" + DateTime.Now.Minute + "-" + DateTime.Now.Second;
                    string dosyaadi = Guid.NewGuid().ToString()+System.IO.Path.GetExtension(UrunResmi.FileName);
                    UrunResmi.SaveAs(Server.MapPath("~/content/upload/"+dosyaadi));
                    model.UrunResmi = dosyaadi;
                    db.Urunler.Add(model);
                    db.SaveChanges();
                }
                else
                {
                    db.Urunler.Add(model);
                    db.SaveChanges();
                }

                return RedirectToAction("listele");
            }
            else
            {
                return View(model);
            }
       
        }
        public ActionResult Guncelle(int id)
        {
            var guncelleme = db.Urunler.Where(m => m.UrunId == id).FirstOrDefault();
            return View(guncelleme);
        }
        [HttpPost]
        public ActionResult Guncelle(Urun model)
        {
            var eskikayit = db.Urunler.Where(m => m.UrunId == model.UrunId).FirstOrDefault();
            eskikayit.UrunAdi = model.UrunAdi;
            eskikayit.UrunFiyat = model.UrunFiyat;
            eskikayit.UrunAciklama = model.UrunAciklama;
            eskikayit.UrunTarih = model.UrunTarih;
            db.SaveChanges();
            return RedirectToAction("listele");
        }
        public ActionResult Sil(int id)
        {
            var silinecekkayit = db.Urunler.Where(m => m.UrunId == id).FirstOrDefault();
            return View(silinecekkayit);
        }
        [HttpPost]
        public ActionResult Sil(Urun model)
        {
            var silinecekkayit = db.Urunler.Where(m => m.UrunId == model.UrunId).FirstOrDefault();
            db.Urunler.Remove(silinecekkayit);
            db.SaveChanges();
            return RedirectToAction("listele");
        }
    }
}