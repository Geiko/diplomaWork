using BookArt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;


namespace BookArt.Controllers
{
    public class ProjectController : Controller
    {
        private SectionDBContext db = new SectionDBContext();
        private const string BOOK_SECTION_NAME = "Книга";
        int PAGE_SIZE = 8;

        // GET: Books
        public ActionResult Index(int? page)
        {
            List<Section> sections = db.Sections.OrderBy(s => s.Number).ToList();
            int pageNumber = (page ?? 1);
            return View(sections.ToPagedList(pageNumber, PAGE_SIZE));
        }



        public ActionResult Works(int? id)
        {
            List<Work> works = db.Works.Where(w => w.SectionId == id)
                                        .OrderBy(w => w.Number).ToList();                        
            return View(works);
        }



        public ActionResult Pages(int? id)
        {
            List<Page> pages = db.Pages.Where(p => p.WorkId == id)
                                        .OrderBy(w => w.Number).ToList();

            var sectionId = db.Works.Find(id).SectionId;
            var sectionTitle = db.Sections.Find(sectionId).Title;

            if (sectionTitle.Equals(BOOK_SECTION_NAME))
            {
                return RedirectToAction($"/Books/{id.ToString()}");
            }

            return View(pages);
        }



        public ActionResult Books(int? id)
        {
            List<Page> pages = db.Pages.Where(p => p.WorkId == id)
                                        .OrderBy(w => w.Number).ToList();
            return View(pages);
        }

    }
}