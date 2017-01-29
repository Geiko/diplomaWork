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
        private int isFirstEnter = 1;

        public ActionResult Index()
        {
            if (Session["Enter"] == null)
            {
                Session["Enter"] = "NotFirst";
                ViewBag.Enter = isFirstEnter;
                return View();
            }

            isFirstEnter = 0;
            ViewBag.Enter = isFirstEnter;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}