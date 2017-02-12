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
    public class ManageWorksController : Controller
    {
        private SectionDBContext db = new SectionDBContext();
        private const string WORK_COVER_URL = "/Content/Images/Works/WorkCover_{0}.jpg";
        private const int MAX_FILE_SIZE = 1048576;



        // GET: Admin/ManageWorks
        public ActionResult Index(string sectionTitle)
        {
            List<Work> works = new List<Work>();
            if (sectionTitle != null)
            {
                int secId = db.Sections.Where(s => s.Title.Equals(sectionTitle))
                                    .FirstOrDefault().Id;
                works = db.Works.Where(w => w.SectionId == secId).ToList();
            }
            else
            { 
                int minId = db.Sections.OrderBy(s => s.Id).First().Id;
                works = db.Works.Where(w => w.SectionId == minId).ToList();
            }

            List<string> sectionTitleList = db.Sections.Select(s => s.Title).ToList();

            WorkViewModel workViewModel = new WorkViewModel
            {
                Works = works,
                Sections = new SelectList(sectionTitleList)
            };

            return View(workViewModel);
        }



        // GET: Admin/ManageWorks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Work work = db.Works.Find(id);
            if (work == null)
            {
                return HttpNotFound();
            }

            var pageNameList = db.Pages.Where(page => page.WorkId == id)
                            .OrderBy(page => page.Number)
                            .Select(page => page.Number).ToList();

            string sectionTitle = db.Sections.Where(w => w.Id == work.SectionId).FirstOrDefault().Title;

            WorkViewModel workViewModel = new WorkViewModel
            {
                Work = work,
                Pages = new SelectList(pageNameList),
                SectionTitle = sectionTitle
            };

            return View(workViewModel);
        }



        // GET: Admin/ManageWorks/Create
        public ActionResult Create(string secTitle)
        {
            int secId;
            if (secTitle != null)
            {
                secId = db.Sections.Where(s => s.Title.Equals(secTitle))
                                    .FirstOrDefault().Id;
            }
            else
            {
                return HttpNotFound();
            }

            ViewBag.SectionId = secId;

            WorkViewModel workViewModel = new WorkViewModel
            {
                SectionTitle = secTitle
            };
            return View(workViewModel);
        }



        // POST: Admin/ManageWorks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,SectionId,Number,Name,CoverUrl")] Work work)
        {
            if (ModelState.IsValid)
            {
                db.Works.Add(work);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(work);
        }



        // GET: Admin/ManageWorks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Work work = db.Works.Find(id);
            if (work == null)
            {
                return HttpNotFound();
            }

            var pageNameList = db.Pages.Where(page => page.WorkId == id)
                            .OrderBy(page => page.Number)
                            .Select(page => page.Number).ToList();

            string sectionTitle = db.Sections.Where(w => w.Id == work.SectionId).FirstOrDefault().Title;

            WorkViewModel workViewModel = new WorkViewModel
            {
                Work = work,
                Pages = new SelectList(pageNameList),
                SectionTitle = sectionTitle
            };

            return View(workViewModel);
        }



        // POST: Admin/ManageWorks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,SectionId,Number,Name,CoverUrl")] Work work)
        {
            if (ModelState.IsValid)
            {
                db.Entry(work).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(work);
        }
        


        [HttpPost]
        public ActionResult AddCover(HttpPostedFileBase fileToUpload, int id)
        {
            try
            {
                string sectionCoverUrl = string.Format(WORK_COVER_URL, id);
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

            return RedirectToAction("Edit", "ManageWorks", new { id = id });
        }



        [HttpPost]
        public ActionResult DeleteCover(int id)
        {
            try
            {
                string sectionCoverUrl = string.Format(WORK_COVER_URL, id);
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

            return RedirectToAction("Edit", "ManageWorks", new { id = id });
        }



        // GET: Admin/ManageWorks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Work work = db.Works.Find(id);
            if (work == null)
            {
                return HttpNotFound();
            }

            var pageNameList = db.Pages.Where(page => page.WorkId == id)
                            .OrderBy(page => page.Number)
                            .Select(page => page.Number).ToList();


            string sectionTitle = db.Sections.Where(w => w.Id == work.SectionId).FirstOrDefault().Title;

            WorkViewModel workViewModel = new WorkViewModel
            {
                Work = work,
                Pages = new SelectList(pageNameList),
                SectionTitle = sectionTitle
            };

            return View(workViewModel);
        }



        // POST: Admin/ManageWorks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Work work = db.Works.Find(id);
            db.Works.Remove(work);
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
