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
    public class ManagePagesController : Controller
    {
        private SectionDBContext db = new SectionDBContext();
        private const string PAGE_COVER_URL = "/Content/Images/Pages/PageCover_{0}.jpg";
        private const int MAX_FILE_SIZE = 1048576;



        // GET: Admin/ManagePages
        public ActionResult Index(string sectionTitle, string workName, string sectionFlag)
        {
            List<Page> pages = new List<Page>();
            if (!string.IsNullOrEmpty(sectionTitle)
                && !string.IsNullOrEmpty(workName)
                && !string.IsNullOrEmpty(sectionFlag))
            {
                if (sectionFlag.Equals("no"))
                {
                    int workId = db.Works.Where(w => w.Name.Equals(workName))
                                        .FirstOrDefault().Id;
                    pages = db.Pages.Where(w => w.WorkId == workId).ToList();
                }
            }

            List<string> sectionTitleList = db.Sections.OrderBy(t => t.Number).Select(s => s.Title).ToList();
            sectionTitleList.Insert(0, "");

            List<string> workNameList = new List<string>();
            if (!string.IsNullOrEmpty(sectionTitle))
            {
                int secId = db.Sections.Where(w => w.Title.Equals(sectionTitle)).FirstOrDefault().Id;
                workNameList = db.Works.Where(w => w.SectionId == secId)
                                        .Select(w => w.Name).OrderBy(n => n).ToList();
            }

            PageViewModel pageViewModel = new PageViewModel
            {
                Pages = pages,
                Works = new SelectList(workNameList),
                Sections = new SelectList(sectionTitleList)
            };

            return View(pageViewModel);
        }



        // GET: Admin/ManagePages/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Page page = db.Pages.Find(id);
            if (page == null)
            {
                return HttpNotFound();
            }

            string workName = db.Works.Where(w => w.Id == page.WorkId).FirstOrDefault().Name;

            PageViewModel pageViewModel = new PageViewModel
            {
                Page = page,
                WorkName = workName
            };
            return View(pageViewModel);
        }



        // GET: Admin/ManagePages/Create
        public ActionResult Create(string worName)
        {

            int worId;
            if (!string.IsNullOrEmpty(worName))
            {
                worId = db.Works.Where(s => s.Name.Equals(worName))
                                    .FirstOrDefault().Id;
            }
            else
            {
                return HttpNotFound();
            }

            ViewBag.WorkId = worId;
            ViewBag.WorkName = worName;

            PageViewModel pageViewModel = new PageViewModel
            {
                WorkName = worName
            };
            return View(pageViewModel);
        }



        // POST: Admin/ManagePages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,WorkId,Number,ImgUrl")] Page page)
        {
            if (ModelState.IsValid)
            {
                db.Pages.Add(page);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(page);
        }



        // GET: Admin/ManagePages/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Page page = db.Pages.Find(id);
            if (page == null)
            {
                return HttpNotFound();
            }


            string workName = db.Works.Where(w => w.Id == page.WorkId).FirstOrDefault().Name;

            PageViewModel pageViewModel = new PageViewModel
            {
                Page = page,
                WorkName = workName
            };

            return View(pageViewModel);
        }



        // POST: Admin/ManagePages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,WorkId,Number,ImgUrl")] Page page)
        {
            if (ModelState.IsValid)
            {
                db.Entry(page).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(page);
        }



        [HttpPost]
        public ActionResult AddCover(HttpPostedFileBase fileToUpload, int id)
        {
            try
            {
                string sectionCoverUrl = string.Format(PAGE_COVER_URL, id);
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

            return RedirectToAction("Edit", "ManagePages", new { id = id });
        }



        [HttpPost]
        public ActionResult DeleteCover(int id)
        {
            try
            {
                string sectionCoverUrl = string.Format(PAGE_COVER_URL, id);
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

            return RedirectToAction("Edit", "ManagePages", new { id = id });
        }



        // GET: Admin/ManagePages/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Page page = db.Pages.Find(id);
            if (page == null)
            {
                return HttpNotFound();
            }

            string workName = db.Works.Where(w => w.Id == page.WorkId).FirstOrDefault().Name;

            PageViewModel pageViewModel = new PageViewModel
            {
                Page = page,
                WorkName = workName
            };

            return View(pageViewModel);
        }



        // POST: Admin/ManagePages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Page page = db.Pages.Find(id);
            db.Pages.Remove(page);
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
