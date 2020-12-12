using MvcPersonalProject.BLL;
using MvcPersonalProject.Common.Helpers;
using MvcPersonalProject.Entity;
using MvcPersonalProject.Entity.ValueObjects;
using MvcPersonalProject.UI.Filters;
using MvcPersonalProject.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace MvcPersonalProject.UI.Controllers
{    
    public class AdminProcessController : Controller
    {
        private UserManager userManager = new UserManager();

        [Auth]
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var pass = Crypto.Hash(model.Password.ToString(), "MD5");
                User user = userManager.Find(x => x.Email == model.Email && x.Password == pass);
                if (user == null)
                {
                    ViewBag.LoginFail = "Lütfen email ayada şifrenizi tekrar kontrol ediniz";
                    return View(model);
                }
                CurrentSession.Set<User>("login", user);
                return RedirectToAction("Index");
            }
            ViewBag.LoginFail = "Lütfen email ayada şifrenizi tekrar kontrol ediniz";
            return View(model);
         }

        public ActionResult LogOut()
        {
            Session.Clear();
            return RedirectToAction("Login");
        }

        public ActionResult ForgetPassword()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ForgetPassword(ForgetPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = userManager.Find(x => x.Email == model.Email);
                if (user == null)
                {
                    ViewBag.EmailNotIsValid = "Lütfen geçerli bir email adresi giriniz.";
                    return View(model);
                }
                int newnumber = 0;
                Random rnd = new Random();
                newnumber = rnd.Next();
                user.Password = Crypto.Hash(newnumber.ToString(), "MD5");
                userManager.Update(user);
                string body = $"Merhaba {user.Name} {user.Surname}; <br> <br> Yeni Şİfre : {newnumber}";
                MailHelper.SendMail(body, user.Email, "Welat BARAN Kişisel Web Sayfası - Yeni Şİfre Talebi", true);
                ViewBag.ForgetPassSuccess = "Yeni şifreniz email adresinize başarılı bir şekilde gönderilmiştir. ";
                return View("ForgetPassword");
            }
            ViewBag.EmailNotIsValid = "Lütfen geçerli bir email adresi giriniz.";
            return View(model);
        }
    }
}