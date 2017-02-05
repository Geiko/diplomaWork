using BookArt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookArt.Controllers
{
    public class ProjectController : Controller
    {
        private SectionDBContext db = new SectionDBContext();

        // GET: Books
        public ActionResult Index()
        {
            return View(db.Sections.ToList());
        }
    }
}