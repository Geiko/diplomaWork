using BookArt.Areas.Admin.Models;
using System;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace BookArt.Areas.Admin.Controllers
{
    [Authorize(Roles = "admin")]
    public class ManageAboutController : Controller
    {
        private const string ABOUT_PHOTO_URL = "/Content/Images/Misc/KostPhoto.JPG";
        private const int MAX_FILE_SIZE = 1048576;



        // GET: Admin/ManageAbout
        public ActionResult Edit()
        {
            AboutViewModel aboutViewModel = new AboutViewModel
            {
                AboutContent = System.IO.File.ReadAllText(Server.MapPath(@"~/App_Data/About.txt"))
            };

            return View(aboutViewModel);
        }



        // POST: Admin/ManageFeedbacks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AboutContent, Result")] AboutViewModel aboutViewModel)
        {
            if (ModelState.IsValid)
            {
                string updatedData = aboutViewModel.AboutContent;
                string dataFile = Server.MapPath("~/App_Data/About.txt");
                System.IO.File.WriteAllText(dataFile, updatedData);

                aboutViewModel.Result = "Зміни збережені";
            }
            else
            {
                aboutViewModel.Result = "Зміни не були збережені. Данні не валідні";
            }

            return View(aboutViewModel);
        }


        [HttpPost]
        public ActionResult AddPhoto(HttpPostedFileBase fileToUpload)
        {
            try
            {
                string filePath = HttpContext.Request.MapPath(ABOUT_PHOTO_URL);

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

            return RedirectToAction("Edit", "ManageAbout");
        }
    }
}