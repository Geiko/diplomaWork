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
        private SectionDBContext db = new SectionDBContext();
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


        
        [HttpPost]
        public string Create(FeedbackViewModel feedback)
        {
            string message = "";
            if (ModelState.IsValid)
            {
                bool isHuman = false;
                try
                {
                    isHuman = GetCaptchaStatus(feedback.CaptchaResponse);
                }
                catch (System.Net.WebException)
                {
                    message = "No Internet";
                }

                if (isHuman == true)
                {
                    Feedback f = new Feedback();
                    f.Date = DateTime.Now;
                    f.UsersEmail = feedback.UsersEmail;
                    f.Content = feedback.Content;
                    f.Date = DateTime.Now;

                    db.Feedbacks.Add(f);
                    db.SaveChanges();
                    message = "Ваше повідомлення надіслано. Дякуємо!";

                    //SendEmaile(feedback.Content);
                }
                else
                {
                    message = "Упс! Ви робот";
                }
            }
            else
            {
                message = "Введено невалідні данні";
            }

            return message;
        }



        private bool GetCaptchaStatus(string CaptchaResponse)
        {
            //var response = Request["g-recaptcha-response"]; 
            var response = CaptchaResponse;
            // for localhost 
            // string secretKey = "6LdjFxQUAAAAAOl-wMwhNg3vrieixjMOfcNZ1Elp"; 
            string secretKey = "6LeV9RUUAAAAAL1rpipumYXsJTXr1LBHs2sJaMZ7";
            var client = new WebClient();
            var result = client.DownloadString(string.Format("https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}", secretKey, response));
            var obj = JObject.Parse(result);

            bool status = (bool)obj.SelectToken("success");
            ViewBag.RecaptchaMessage = status ? "Ok" : "Упс! Ви робот, спробуйте ще";
            return status;
        }



        private void SendEmaile(string content)
        {
            MailAddress from = new MailAddress("k.i.geiko@gmail.com", "Website BookArt");
            MailAddress to = new MailAddress("k.i.geiko@yandex.ua");
            MailMessage m = new MailMessage(from, to);
            m.Subject = "Надійшло нове повідомленняю";
            m.Body = content;
            m.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.Credentials = new NetworkCredential("k.i.geiko@gmail.com", "***");
            smtp.EnableSsl = true;
            smtp.Send(m);
        }
    }
}
