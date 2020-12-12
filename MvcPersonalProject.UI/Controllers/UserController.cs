using MvcPersonalProject.BLL;
using MvcPersonalProject.Entity;
using MvcPersonalProject.Entity.ValueObjects;
using MvcPersonalProject.UI.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace MvcPersonalProject.UI.Controllers
{
    [Auth]
    public class UserController : Controller
    {
        private UserManager userManager = new UserManager();

        public ActionResult Index()
        {
            return View(userManager.List());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = userManager.Find(x => x.Id == id.Value);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = userManager.Find(x => x.Id == id.Value);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(User user,HttpPostedFileBase Image)
        {
            User u = userManager.Find(x => x.Id == user.Id);
            if (ModelState.IsValid)
            {
                if (Image != null &&
                      (Image.ContentType == "image/jpeg" ||
                       Image.ContentType == "image/jpg" ||
                       Image.ContentType == "image/png"))
                {
                    string filename = $"user_{user.Id}.{Image.ContentType.Split('/')[1]}";
                    Image.SaveAs(Server.MapPath($"~/Image/user/{filename}"));
                    u.Image = filename;
                }
                u.Name = user.Name;
                u.Surname = user.Surname;
                u.Email = user.Email;
                u.Github = user.Github;
                u.Instagram = user.Instagram;
                u.Twitter = user.Twitter;
                u.Telegram = user.Telegram;
                u.Degree = user.Degree;
                //u.Password = Crypto.Hash(user.Password.ToString(), "MD5");
                userManager.Update(u);
                return RedirectToAction("Index");
            }
            return View(user);
        }

        [HttpGet]
        public ActionResult PasswordChange(int? id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult PasswordChange(PasswordChangeViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = userManager.Find(x => x.Email == model.Email);
                if (user == null)
                {
                    return HttpNotFound();
                }
                user.Password = Crypto.Hash(model.Password.ToString(), "MD5");
                userManager.Update(user);
                ViewBag.Success = "Şifreniz başarılı bir şekilde değiştirildi";
                return View(model);
            }
            ViewBag.Fail = "Şifre değiştirilirken hata oluştu" ;
            return View(model);
        }
    }
}