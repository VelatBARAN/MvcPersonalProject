using MvcPersonalProject.BLL;
using MvcPersonalProject.Entity;
using MvcPersonalProject.UI.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MvcPersonalProject.UI.Controllers
{
    [Auth]
    public class ExperienceController : Controller
    {
        ExperienceManager experienceManager = new ExperienceManager();

        public ActionResult Index()
        {
            return View(experienceManager.ListQueryable().OrderByDescending(x => x.CreatedOn).ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Experiences experiences = experienceManager.Find(x => x.Id == id.Value);
            if (experiences == null)
            {
                return HttpNotFound();
            }
            return View(experiences);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create(Experiences experiences)
        {
            ModelState.Remove("CreatedOn");
            ModelState.Remove("ModifiedOn");
            if (ModelState.IsValid)
            {
                experienceManager.Insert(experiences);
                return RedirectToAction("Index");
            }
            return View(experiences);
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Experiences experiences = experienceManager.Find(x => x.Id == id.Value);
            if (experiences == null)
            {
                return HttpNotFound();
            }
            return View(experiences);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(Experiences experiences)
        {
            ModelState.Remove("ModifiedOn");
            if (ModelState.IsValid)
            {
                Experiences exp = experienceManager.Find(x => x.Id == experiences.Id);
                exp.Institution = experiences.Institution;
                exp.Department = experiences.Department;
                exp.Time = experiences.Time;
                exp.Text = experiences.Text;
                exp.City = experiences.City;
                exp.IsActive = experiences.IsActive;
                return RedirectToAction("Index");
            }
            return View(experiences);
        }

        [HttpPost]
        public ActionResult Delete(int? id)
        {
            Experiences experiences = experienceManager.Find(x => x.Id == id.Value);
            if (experiences != null)
            {
                int res = experienceManager.Delete(experiences);
                if (res > 0)
                {
                    return Json(new { hasError = false, Message = $" Deneyim bilgisi başarılı bir şekilde silindi." }, JsonRequestBehavior.AllowGet);
                    //return Json(new { hasError = false, Massage = "Personel başarılı bir şekilde silindi." });
                }
                else
                {
                    return Json(new { hasError = true, Message = $" Deneyim bilgisi silinirken hata oluştu." }, JsonRequestBehavior.AllowGet);
                    //return Json(new { hasError = true, Message = "Personel silinirken hata oluştu." });
                }
            }
            return Json(new { results = true, Message = "Böyle bir deneyim bulunamadı." }, JsonRequestBehavior.AllowGet);
        }
    }
}