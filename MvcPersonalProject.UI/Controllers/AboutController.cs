using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MvcPersonalProject.BLL;
using MvcPersonalProject.Entity;
using MvcPersonalProject.UI.Filters;

namespace MvcPersonalProject.UI.Controllers
{
    [Auth]
    public class AboutController : Controller
    {
        private AboutManager aboutManager = new AboutManager();

        public ActionResult Index()
        {
            return View(aboutManager.List());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            About about = aboutManager.Find(x => x.Id == id.Value);
            if (about == null)
            {
                return HttpNotFound();
            }
            return View(about);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            About about = aboutManager.Find(x => x.Id == id.Value);
            if (about == null)
            {
                return HttpNotFound();
            }
            return View(about);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(About about, HttpPostedFileBase Image)
        {
            if (ModelState.IsValid)
            {
                About a = aboutManager.Find(x => x.Id == about.Id);
                if (Image != null &&
                      (Image.ContentType == "image/jpeg" ||
                       Image.ContentType == "image/jpg" ||
                       Image.ContentType == "image/png"))
                {
                    string filename = $"user_{about.Id}.{Image.ContentType.Split('/')[1]}";
                    Image.SaveAs(Server.MapPath($"~/Image/user/{filename}"));
                    a.Image = filename;
                }
                a.Text = about.Text;
                aboutManager.Update(a);
                return RedirectToAction("Index");
            }
            return View(about);
        }

    }
}
