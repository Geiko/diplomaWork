using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BookArt.Models;
using BookArt.Areas.Admin.Models;
using System.IO;

namespace BookArt.Areas.Admin.Controllers
{
    [Authorize(Roles = "admin")]
    public class ManageSectionsController : Controller
    {
        private SectionDBContext db = new SectionDBContext();
        private const string SECTION_COVER_URL = "/Content/Images/Sections/SectionCover_{0}.jpg";
        private const int MAX_FILE_SIZE = 1048576;

        // GET: Admin/ManageSections
        public ActionResult Index()
        {
            return View(db.Sections.ToList());
        }

        // GET: Admin/ManageSections/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Section section = db.Sections.Find(id);
            if (section == null)
            {
                return HttpNotFound();
            }

            var workNameList = db.Works.Where(work => work.SectionId == id)
                                        .OrderBy(w => w.Number)
                                        .Select(w => w.Name)
                                        .ToList();
            SectionViewModel sectionViewModel = new SectionViewModel
            {
                Section = section,
                Works = new SelectList(workNameList)
            };

            return View(sectionViewModel);
        }



        // GET: Admin/ManageSections/Create
        public ActionResult Create()
        {
            ViewBag.SectionsAmount = db.Sections.Count();

            return View();
        }

        // POST: Admin/ManageSections/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Number,Title,CoverUrl")] Section section)
        {
            if (ModelState.IsValid)
            {
                db.Sections.Add(section);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(section);
        }

        // GET: Admin/ManageSections/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Section section = db.Sections.Find(id);
            if (section == null)
            {
                return HttpNotFound();
            }

            var workNameList = db.Works.Where(work => work.SectionId == id)
                            .OrderBy(w => w.Number)
                            .Select(w => w.Name).ToList();
            SectionViewModel sectionViewModel = new SectionViewModel
            {
                Section = section,
                Works = new SelectList(workNameList)
            };

            return View(sectionViewModel);
        }



        // POST: Admin/ManageSections/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Number,Title,CoverUrl")] Section section)
        {
            if (ModelState.IsValid)
            {
                db.Entry(section).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(section);
        }


        
        [HttpPost]
        public ActionResult AddCover(HttpPostedFileBase fileToUpload, int id)
        {
            try
            {
                string sectionCoverUrl = string.Format(SECTION_COVER_URL, id);
                string filePath = HttpContext.Request.MapPath(sectionCoverUrl);

                if (fileToUpload != null && fileToUpload.ContentLength > 0 &&
                    fileToUpload.ContentLength < MAX_FILE_SIZE)
                {
                    fileToUpload.SaveAs(filePath);
                }
                
                else
                {
                    throw new ArgumentException("File size must be less then 1 MB and greater then 0 MB");
                }
            }
            catch (FileLoadException ex)
            {
                return View("Error");
            }

            return RedirectToAction("Edit", "ManageSections", new { id = id });
        }

        [HttpPost]
        public ActionResult DeleteCover(int id)
        {
            try
            {
                string sectionCoverUrl = string.Format(SECTION_COVER_URL, id);
                string filePath = HttpContext.Request.MapPath(sectionCoverUrl);

                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                }
                else
                {
                    throw new FileNotFoundException("File not found");
                }
            }
            catch (System.IO.FileNotFoundException ex)
            {
                return View("Error");
            }

            return RedirectToAction("Edit", "ManageSections", new { id = id });
        }



        // GET: Admin/ManageSections/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Section section = db.Sections.Find(id);
            if (section == null)
            {
                return HttpNotFound();
            }

            var workNameList = db.Works.Where(work => work.SectionId == id)
                            .OrderBy(w => w.Number)
                            .Select(w => w.Name).ToList();
            SectionViewModel sectionViewModel = new SectionViewModel
            {
                Section = section,
                Works = new SelectList(workNameList)
            };

            return View(sectionViewModel);
        }



        // POST: Admin/ManageSections/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Section section = db.Sections.Find(id);
            db.Sections.Remove(section);
            db.SaveChanges();
            return RedirectToAction("Index");
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
