using BookArt.Areas.Admin.Models;
using System.Web.Mvc;

namespace BookArt.Areas.Admin.Controllers
{
    public class ManageAboutController : Controller
    {
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
    }
}