using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace MYUSIS.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            if (Session["AdminPassword"] == null)
            {
                ViewBag.AdminPassword = "No Value";
            }
            else
            {
                ViewBag.AdminPassword = Session["AdminPassword"];
            }
            return View();
        }
        public ActionResult Admin()
        {
            Session["AdminPageVisited"] = true;
            Session["AdminPageVisitedCounter"] = (int)Session["AdminPageVisitedCounter"]+1;
            return View();
        }
        public ActionResult Ogrenci()
        {
            Session["OgrenciPageVisited"] = true;
            Session["OgrenciPageVisitedCounter"] = (int)Session["OgrenciPageVisitedCounter"]+1;
            return View();
        }
        public ActionResult Ogretmen()
        {
            Session["OgretmenPageVisited"] = true;
            Session["OgretmenPageVisitedCounter"] = (int)Session["OgretmenPageVisitedCounter"]+1;
            return View();
        }
        public ActionResult OgrenciIslem()
        {
            return View();
        }
        public ActionResult OgretmenIslem()
        {
            return View();
        }
        public ActionResult Logout()
        {
            Session.Clear();
            Session.RemoveAll();
            Session.Abandon();
            return RedirectToAction("Index");
        }
        public JavaScriptResult GiveMessage()
        {
            string message = "Giriş Yapılıyor...";
            string myscript = "function GiveMessage(){ alert('" + message + "'); }";
            return JavaScript(myscript);
        }
        public PartialViewResult MenuList()
        {

            return PartialView("_PartialPage1");
        }
        public FilePathResult DownloadFile()
        {
            var filePath = Server.MapPath("~/Dosyalar/icerik.pdf");

            return new FilePathResult(filePath, "application/pdf");
        }
        public FileStreamResult DownloadStreamFile()
        {
            var filePath = Server.MapPath("~/Dosyalar/diagram.pdf");

            FileStream fs = new FileStream(filePath, FileMode.Open);
            return new FileStreamResult(fs, "application/pdf");
        }
        public RedirectToRouteResult Page0()
        {
            return RedirectToAction("Index");
        }
        public RedirectToRouteResult Page1()
        {
            return RedirectToAction("Admin");
        }
        public RedirectToRouteResult Page2()
        {
            return RedirectToAction("Ogretmen");
        }
        public RedirectToRouteResult Page3()
        {
            return RedirectToAction("Ogrenci");
        }
    }

    public class RedirectController : Controller
    {
        public RedirectResult RamazanYavuz()
        {
            return Redirect("https://www.github.com/r4ya");
        }
    }
}