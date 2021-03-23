using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebFinal.Models;
using WebFinal.Models.Managers;


namespace WebFinal.Controllers
{
    public class CUyeController : Controller
    {
        // GET: CUye
        public ActionResult KayitOl()
        {
            return View();
        }
        [HttpPost]
        public ActionResult KayitOl(Uyeler Uye)
        {
            DataBaseContext db = new DataBaseContext();
            db.Uyeler.Add(Uye);
            int sonuc = db.SaveChanges();
            if (sonuc > 0)
            {
                ViewBag.Result = "Uye kaydedildi";
                ViewBag.Status = "success";
            }
            else
            {
                ViewBag.Result = "Uye Kaydedilemedi";
                ViewBag.Status = "danger";
            }

            return View();
        }
        public ActionResult Giris()
        {        
            return View();
        }
        [HttpPost]
        public ActionResult Giris(Uyeler uye)
        {
            if(Session["aktifmi"]=="aktif")
            {
                return RedirectToAction("HomePage", "Home");

            }
            DataBaseContext db = new DataBaseContext();                        
            Uyeler u = null;
            List<Adminler> tumAdminler = db.Adminler.ToList();
            string testadminad = uye.KullaniciAdi;
            string tesadminsifre = uye.Parola;
            Adminler a = new Adminler();
            a.AdminAdi = testadminad;
            a.Sifre = tesadminsifre;
            foreach(var admin in tumAdminler)
            {
               if(a.AdminAdi.Equals(admin.AdminAdi,0) && a.Sifre.Equals(admin.Sifre,0))
               {
                    Session["yetki"] = "admin";
                    Session["adminadi"] = a.AdminAdi;
                    Session["aktifmi"] = "aktif";
                    Session["sepet"] = new List<Urunler>();
                    return RedirectToAction("HomePage","Home");
               }
            }
            u = db.Uyeler.Where(x => x.KullaniciAdi == uye.KullaniciAdi && x.Parola == uye.Parola).SingleOrDefault();
            if (u != null)
            {
                    uye.Aktifmi = true;
                    Session["kadi"] = uye.KullaniciAdi;
                    Session["aktifmi"] = "aktif";
                    Session["yetki"] = "Uye";
                    Session["sepet"] = new List<Urunler>();
            }
            else
            {
                    return RedirectToAction("KayitOl","CUye");
            }          
            
            return RedirectToAction("HomePage","Home");
        }
        public ActionResult Cikis()
        {
            if(Session["aktifmi"]!="aktif")
            {
                return RedirectToAction("HomePage", "Home");
            }
            Session.Remove("kadi");
            Session.Remove("aktifmi");
            Session.Remove("yetki");
            Session.Remove("sepet");
            return RedirectToAction("Giris","CUye");
        }
    }
    
}