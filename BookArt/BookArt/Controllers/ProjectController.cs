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
        private BookArtDBContext db = new BookArtDBContext();

        // GET: Books
        public ActionResult Index()
        {
            return View(db.Books.ToList());  
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}