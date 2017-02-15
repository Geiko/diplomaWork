using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookArt;

namespace BookArt.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (Session["Enter"] == null) 
            {
                Session["Enter"] = "First"; 
                ViewBag.Enter = 1;
                return View();
            }
            
            ViewBag.Enter = 0;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.AboutContent = System.IO.File.ReadAllText(Server.MapPath(@"~/App_Data/About.txt"));

            return View();
        }
    }
}