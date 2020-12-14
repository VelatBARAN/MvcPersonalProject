using MvcPersonalProject.BLL;
using MvcPersonalProject.Common.Helpers;
using MvcPersonalProject.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace MvcPersonalProject.UI.Controllers
{
    public class HomeController : Controller
    {
        private ProjectDoneManager projectDoneManager = new ProjectDoneManager();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ProjectDoneDetail(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectsDones projectDone = projectDoneManager.Find(x => x.Id == id.Value);
            if (projectDone == null)
            {
                return HttpNotFound();
            }
            return View(projectDone);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult MessageSend(string name=null,string email=null,string subject=null,string message = null)
        {
            MailMessage mail = new MailMessage();
            mail.To.Add("baranvelat021@gmail.com");
            mail.From = new MailAddress(email);
            mail.Subject = "Welat BARAN Kişisel Web Sayfası - Gelen Mesaj";
            string Body = $"Merhaba ben {name} <br><br> Email : {email} <br><br> Konu : {subject} <br> <br> Mesaj İçeriği : {message}";
            mail.Body = Body;
            mail.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new System.Net.NetworkCredential("baranvelat021@gmail.com", "liceli21?"); // Enter seders User name and password  
            smtp.EnableSsl = true;
            smtp.Send(mail);
            ViewBag.Info = "Mesajınız başarıyla gönderilmiştir.";
            return View();
        }
    }
}