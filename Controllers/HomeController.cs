using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.Mvc;
using WebFinal.Models;
using WebFinal.Models.Managers;
using WebFinal.ViewsModels;

namespace WebFinal.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult HomePage()
        {
            DataBaseContext db = new DataBaseContext();
            //List<Uyeler> uyeler = db.Uyeler.ToList();

            HomePageViewModel Model = new HomePageViewModel();
            Model.Urunler = db.Urunler.ToList();
            Model.Uyeler = db.Uyeler.ToList();

            return View(Model);
        }
        [HttpPost]
        public ActionResult HomePage(int? urunid)
        {
            if(Session["aktifmi"]=="aktif")
            {
                DataBaseContext db = new DataBaseContext();
                Urunler urun = db.Urunler.Where(x => x.Id == urunid).FirstOrDefault();
                List<Urunler> urunSepeti = (List<Urunler>)Session["sepet"];
                urunSepeti.Add(urun);
                Session["sepet"] = urunSepeti;
                ViewBag.Result = "Sepete Eklendi";
                ViewBag.Status = "success";
                HomePageViewModel Model = new HomePageViewModel();
                Model.Urunler = db.Urunler.ToList();
                Model.Uyeler = db.Uyeler.ToList();
                return View(Model);
            }
            else
            {
                DataBaseContext db = new DataBaseContext();
                HomePageViewModel Model = new HomePageViewModel();
                Model.Urunler = db.Urunler.ToList();
                Model.Uyeler = db.Uyeler.ToList();
                return View(Model);
            }
           
        }


        public ActionResult HomePageErkek()
        {
            DataBaseContext db = new DataBaseContext();
            //List<Uyeler> uyeler = db.Uyeler.ToList();

            HomePageViewModel Model = new HomePageViewModel();
            Model.Urunler = db.Urunler.ToList();
            Model.Uyeler = db.Uyeler.ToList();

            return View(Model);
        }
        [HttpPost]
        public ActionResult HomePageErkek(int? urunid)
        {
            if (Session["aktifmi"] == "aktif")
            {
                DataBaseContext db = new DataBaseContext();
                Urunler urun = db.Urunler.Where(x => x.Id == urunid).FirstOrDefault();
                List<Urunler> urunSepeti = (List<Urunler>)Session["sepet"];
                urunSepeti.Add(urun);
                Session["sepet"] = urunSepeti;
                ViewBag.Result = "Sepete Eklendi";
                ViewBag.Status = "success";
                HomePageViewModel Model = new HomePageViewModel();
                Model.Urunler = db.Urunler.ToList();
                Model.Uyeler = db.Uyeler.ToList();
                return View(Model);
            }
            else
            {
                DataBaseContext db = new DataBaseContext();
                HomePageViewModel Model = new HomePageViewModel();
                Model.Urunler = db.Urunler.ToList();
                Model.Uyeler = db.Uyeler.ToList();
                return View(Model);
            }
        }
        public ActionResult HomePageKadin()
        {
            DataBaseContext db = new DataBaseContext();
            //List<Uyeler> uyeler = db.Uyeler.ToList();

            HomePageViewModel Model = new HomePageViewModel();
            Model.Urunler = db.Urunler.ToList();
            Model.Uyeler = db.Uyeler.ToList();

            return View(Model);
        }
        [HttpPost]
        public ActionResult HomePageKadin(int? urunid)
        {
            if (Session["aktifmi"] == "aktif")
            {
                DataBaseContext db = new DataBaseContext();
                Urunler urun = db.Urunler.Where(x => x.Id == urunid).FirstOrDefault();
                List<Urunler> urunSepeti = (List<Urunler>)Session["sepet"];
                urunSepeti.Add(urun);
                Session["sepet"] = urunSepeti;
                ViewBag.Result = "Sepete Eklendi";
                ViewBag.Status = "success";
                HomePageViewModel Model = new HomePageViewModel();
                Model.Urunler = db.Urunler.ToList();
                Model.Uyeler = db.Uyeler.ToList();
                return View(Model);
            }
            else
            {
                DataBaseContext db = new DataBaseContext();
                HomePageViewModel Model = new HomePageViewModel();
                Model.Urunler = db.Urunler.ToList();
                Model.Uyeler = db.Uyeler.ToList();
                return View(Model);
            }
        }
        public ActionResult Yonetim()
        {
            if(Session["yetki"] != "admin")
            {
                return RedirectToAction("HomePage", "Home");
            }
            DataBaseContext db = new DataBaseContext();
            List<Urunler> Urunler = db.Urunler.ToList();
            return View(Urunler);
        }    
        public ActionResult Hakkinda()
        {
            return View();
        }      
    }
}