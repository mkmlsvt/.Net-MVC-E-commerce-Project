using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebFinal.Models;
using WebFinal.Models.Managers;

namespace WebFinal.Controllers
{
    public class CUrunController : Controller
    {
        // GET: CUrun
        Context c = new Context();

        public ActionResult YeniUrun()
        {
            if (Session["yetki"] != "admin")
            {
                return RedirectToAction("HomePage", "Home");
            }
            return View();
        }
        [HttpPost]
        public ActionResult YeniUrun(Urunler urun)
        {
            DataBaseContext db = new DataBaseContext();
            if (Request.Files.Count > 0)
            {
                string dosyaadi = Path.GetFileName(Request.Files[0].FileName);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "/Images/" + dosyaadi;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                string fileName = dosyaadi;
                urun.Resim = "/Images/" + dosyaadi;
                db.Urunler.Add(urun);
                int sonuc = db.SaveChanges();
                if (sonuc > 0)
                {
                    ViewBag.Result = "Urun kaydedilmistir";
                    ViewBag.Status = "success";
                }
                else
                {
                    ViewBag.Result = "Urun Kaydedilemedi";
                    ViewBag.Status = "danger";
                }
            }
            return View();
        }

        public ActionResult Duzenle(int? urunid)
        {
            if (Session["yetki"] != "admin")
            {
                return RedirectToAction("HomePage", "Home");
            }
            Urunler urun = null;
            if (urunid != null)
            {
                DataBaseContext db = new DataBaseContext();
                urun = db.Urunler.Where(x => x.Id == urunid).FirstOrDefault();
                Session["urunid"] = urunid;
            }
            return View(urun);
        }
        [HttpPost]
        public ActionResult Duzenle(Urunler model)
        {
            DataBaseContext db = new DataBaseContext();
            int urunid =(int)Session["urunid"];
            string dosyaadi = Path.GetFileName(Request.Files[0].FileName);
            string uzanti = Path.GetExtension(Request.Files[0].FileName);
            string yol = "/Images/" + dosyaadi;
            Request.Files[0].SaveAs(Server.MapPath(yol));
            string fileName = dosyaadi;
            model.Resim = "/Images/" + dosyaadi;
            Urunler urun = db.Urunler.Where(x => x.Id == urunid).FirstOrDefault();
            if (urun != null)
            {
                urun.Resim = model.Resim;
                urun.Ad = model.Ad;
                urun.Erkekmi = model.Erkekmi;
                urun.Indirim = model.Indirim;
                urun.Fiyat = model.Fiyat;

                int sonuc = db.SaveChanges();
                if (sonuc > 0)
                {
                    ViewBag.Result = "Urun guncellendi";
                    ViewBag.Status = "success";
                }
                else
                {
                    ViewBag.Result = "Urun guncellenmedi";
                    ViewBag.Status = "danger";
                }
            }

            return View();
        }
        public ActionResult Sil(int? urunid)
        {
            if (Session["yetki"] != "admin")
            {
                return RedirectToAction("HomePage", "Home");
            }
            Urunler urun = null;
            if(urunid!=null)
            {
                DataBaseContext db = new DataBaseContext();
                urun = db.Urunler.Where(x => x.Id == urunid).FirstOrDefault();
            }
            return View(urun);
        }
        [HttpPost,ActionName("Sil")]
        public ActionResult Silok(int? urunid)
        {          
            if (urunid != null)
            {
                DataBaseContext db = new DataBaseContext();
                Urunler urun = db.Urunler.Where(x => x.Id == urunid).FirstOrDefault();
                db.Urunler.Remove(urun);
                db.SaveChanges();
            }
            return RedirectToAction("Yonetim","Home");
        }
        public ActionResult Sepet()
        {
            var sepet = (List<Urunler>)Session["sepet"];
            return View();
        }
        [HttpPost, ActionName("Sepet")]
        public ActionResult SepetOk()
        {         
            //Session.Remove("sepet");
            //System.Threading.Thread.Sleep(5000);
            //return RedirectToAction("HomePage", "Home");
            return RedirectToAction("Onay","CUrun");
        }           
        public ActionResult Onay()
        {
            return View();
        }
        [HttpPost,ActionName("Onay")]
        public ActionResult OnayOk()
        {
            Session["sepet"] = new List<Urunler>();         
            return RedirectToAction("HomePage", "Home");         
        }
        public ActionResult SepettenSil(int? urunid)
        {
            DataBaseContext db = new DataBaseContext();
            Urunler urun = db.Urunler.Where(x => x.Id == urunid).FirstOrDefault();
            List<Urunler> urunSepeti = (List<Urunler>)Session["sepet"];
            urunSepeti.RemoveAll(q => q.Id == urun.Id);
            Session["sepet"] = urunSepeti;
            return RedirectToAction("Sepet", "CUrun");
        }
    }
    
}