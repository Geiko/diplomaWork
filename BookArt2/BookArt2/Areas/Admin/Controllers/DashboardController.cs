using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookArt2.Areas.Admin.Controllers
{
    public class DashboardController : Controller
    {

        //[Authorize]

        // GET: Admin/Dashboard
        public ActionResult Index()
        {
            return View();
        }
    }
}