using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BookArt.Models;
using PagedList;

namespace BookArt.Controllers
{
    public class PagesController : Controller
    {
        private SectionDBContext db = new SectionDBContext();
        private const string BOOK_SECTION_NAME = "Книга";
        int PAGE_SIZE = 8;



        // GET: Pages
        public ActionResult Index(int? id, int? page)
        {
            List<Page> pages = db.Pages.Where(p => p.WorkId == id)
                                        .OrderBy(w => w.Number).ToList();

            var sectionId = db.Works.Find(id).SectionId;
            var sectionTitle = db.Sections.Find(sectionId).Title;
            ViewBag.SectionID = sectionId;

            if (sectionTitle.Equals(BOOK_SECTION_NAME))
            {
                return RedirectToAction($"/Books/{id.ToString()}");
            }

            int pageNumber = (page ?? 1);
            return View(pages.ToPagedList(pageNumber, PAGE_SIZE));
        }




        public ActionResult Books(int? id)
        {
            List<Page> pages = db.Pages.Where(p => p.WorkId == id)
                                        .OrderBy(w => w.Number).ToList();
            ViewBag.SectionID = db.Works.Find(id).SectionId;
            return View(pages);
        }
    }
}
