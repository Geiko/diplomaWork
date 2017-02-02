using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BookArt.Models;
//using Contracts.Authorization;
using Microsoft.AspNet.Identity;
using System.Web.Configuration;
using Newtonsoft.Json.Linq;

namespace BookArt.Controllers
{
    public class FeedbacksController : Controller
    {
        private BookArtDBContext db = new BookArtDBContext();
        private ApplicationDbContext dba = new ApplicationDbContext();
        
        // GET: Feedbacks/Create
        public ActionResult Create()
        {
            var feedback = new Feedback
            {
                UsersEmail = GetUserMail()
            };

            return View(feedback);
        }

        private string GetUserMail()
        {
            string currentUserId = User.Identity.IsAuthenticated
                ? User.Identity.GetUserId() : "ANONYM";
            string Email = string.Empty;  
            if (!currentUserId.Equals( "ANONYM"))
            {
                 Email = dba.Users.FirstOrDefault(x => x.Id == currentUserId).Email;
            }

            return Email;
        }
        

        // POST: Feedbacks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,UsersEmail,Content,Date")] Feedback feedback)
        {
            if (ModelState.IsValid)
            {
                var response = Request["g-recaptcha-response"];
                string secretKey = "6LdjFxQUAAAAAOl-wMwhNg3vrieixjMOfcNZ1Elp";
                var client = new WebClient();
                var result = client.DownloadString(string.Format("https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}", secretKey, response));
                var obj = JObject.Parse(result);
                var status = (bool)obj.SelectToken("success");
                ViewBag.RecaptchaMessage = status ? "Ok" : "Упс! Ви робот, спробуйте ще";

                if(status == true)
                {
                    feedback.Date = DateTime.Now;
                    db.Feedbacks.Add(feedback);
                    db.SaveChanges();
                    ViewBag.FeedbackMessage = "Ваше повідомлення надіслано. Дякуємо!";
                }
            }

            return View(feedback);
        }
    }
}
