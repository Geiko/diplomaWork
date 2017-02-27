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
        //private const string BOOK_SECTION_NAME = "Книга";
        int PAGE_SIZE = 8;



        // GET: Books
        public ActionResult Index(int? page)
        {
            List<Section> sections = db.Sections.OrderBy(s => s.Number).ToList();
            int pageNumber = (page ?? 1);
            return View(sections.ToPagedList(pageNumber, PAGE_SIZE));
        }     
    }
}