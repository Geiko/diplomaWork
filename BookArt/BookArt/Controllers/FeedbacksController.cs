using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BookArt.Models;
using Microsoft.AspNet.Identity;
using System.Web.Configuration;
using Newtonsoft.Json.Linq;
using System.Net.Mail;

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
            string currentUserId = User.Identity.IsAuthenticated ? User.Identity.GetUserId() : "anonym";
            string Email = string.Empty;  
            if (!currentUserId.Equals("anonym"))
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
                bool isHuman = SetRecaptcha();

                if(isHuman == true)
                {
                    feedback.Date = DateTime.Now;
                    db.Feedbacks.Add(feedback);
                    db.SaveChanges();
                    ViewBag.FeedbackMessage = "Ваше повідомлення надіслано. Дякуємо!";

                    SendEmaile(feedback.Content);
                }
            }

            return View(feedback);
        }



        private bool SetRecaptcha()
        {
            var response = Request["g-recaptcha-response"];
            string secretKey = "6LdjFxQUAAAAAOl-wMwhNg3vrieixjMOfcNZ1Elp";
            var client = new WebClient();
            var result = client.DownloadString(string.Format("https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}", secretKey, response));
            var obj = JObject.Parse(result);

            bool status = (bool)obj.SelectToken("success");
            ViewBag.RecaptchaMessage = status ? "Ok" : "Упс! Ви робот, спробуйте ще";
            return status;
        }



        private void SendEmaile(string content)
        {
            MailAddress from = new MailAddress("k.i.geiko@gmail.com", "Website BookArt...");
            MailAddress to = new MailAddress("k.i.geiko@yandex.ua");
            MailMessage m = new MailMessage(from, to);
            m.Subject = "Надійшло нове повідомленняю";
            m.Body = content;
            m.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.Credentials = new NetworkCredential("k.i.geiko@gmail.com", "KG16011962");
            smtp.EnableSsl = true;
            smtp.Send(m);
        }
    }
}
