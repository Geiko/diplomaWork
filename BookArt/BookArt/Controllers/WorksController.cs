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
    public class WorksController : Controller
    {
        private SectionDBContext db = new SectionDBContext();
        //private const string BOOK_SECTION_NAME = "Книга";
        int PAGE_SIZE = 8;



        // GET: Works
        public ActionResult Index(int? id, int? page)
        {
            List<Work> works = db.Works.Where(w => w.SectionId == id)
                                        .OrderBy(w => w.Number).ToList();
            int pageNumber = (page ?? 1);
            return View(works.ToPagedList(pageNumber, PAGE_SIZE));
        }
    }
}
