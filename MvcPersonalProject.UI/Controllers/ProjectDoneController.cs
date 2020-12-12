using MvcPersonalProject.BLL;
using MvcPersonalProject.Entity;
using MvcPersonalProject.UI.Filters;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MvcPersonalProject.UI.Controllers
{
    [Auth]
    public class ProjectDoneController : Controller
    {
        private ProjectDoneManager projectDoneManager = new ProjectDoneManager();
        private ServiceManager serviceManager = new ServiceManager();

        public ActionResult Index()
        {
            return View(projectDoneManager.ListQueryable().Include("Services").OrderByDescending(x=>x.CreatedOn).ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectsDones projectsDones = projectDoneManager.Find(x => x.Id == id.Value);
            if (projectsDones == null)
            {
                return HttpNotFound();
            }
            return View(projectsDones);
        }

        [HttpGet]
        public ActionResult Create()
        {
            //IEnumerable<SelectListItem> list = (from k in serviceManager.List()
            //                             select new SelectListItem
            //                             {
            //                                 Text = k.Title,
            //                                 Value = k.Id.ToString()
            //                             }).ToList();
            //ViewBag.ServicesId = list;
            ViewBag.ServicesList = new SelectList(serviceManager.List(), "Id", "Title");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create(ProjectsDones projectsDones , HttpPostedFileBase Image1, HttpPostedFileBase Image2, HttpPostedFileBase Image3)
        {
            ModelState.Remove("CreatedOn");
            ModelState.Remove("ModifiedOn");
            if (ModelState.IsValid)
            {
                if (Image1 != null &&
                      (Image1.ContentType == "image/jpeg" ||
                       Image1.ContentType == "image/jpg" ||
                       Image1.ContentType == "image/png"))
                {
                    string filename1 = $"{projectsDones.ProjectName}_Image1.{Image1.ContentType.Split('/')[1]}";
                    Image1.SaveAs(Server.MapPath($"~/Image/projectsdone/{filename1}"));
                    projectsDones.Image1 = filename1;
                }
                if (Image2 != null &&
                      (Image2.ContentType == "image/jpeg" ||
                       Image2.ContentType == "image/jpg" ||
                       Image2.ContentType == "image/png"))
                {
                    string filename2 = $"{projectsDones.ProjectName}_Image2.{Image2.ContentType.Split('/')[1]}";
                    Image2.SaveAs(Server.MapPath($"~/Image/projectsdone/{filename2}"));
                    projectsDones.Image2 = filename2;
                }
                if (Image3 != null &&
                      (Image3.ContentType == "image/jpeg" ||
                       Image3.ContentType == "image/jpg" ||
                       Image3.ContentType == "image/png"))
                {
                    string filename3 = $"{projectsDones.ProjectName}_Image3.{Image3.ContentType.Split('/')[1]}";
                    Image3.SaveAs(Server.MapPath($"~/Image/projectsdone/{filename3}"));
                    projectsDones.Image3 = filename3;
                }

                projectDoneManager.Insert(projectsDones);
                return RedirectToAction("Index");
            }
            ViewBag.ServicesList = new SelectList(serviceManager.List(), "Id", "Title",projectsDones.ServicesId);
            return View(projectsDones);
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            //ViewBag.ServicesId = (from k in serviceManager.List()
            //                      select new SelectListItem
            //                      {
            //                          Text = k.Title,
            //                          Value = k.Id.ToString()
            //                      }).ToList();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectsDones projectsDones = projectDoneManager.Find(x => x.Id == id.Value);
            if (projectsDones == null)
            {
                return HttpNotFound();
            }
            ViewBag.ServicesId = new SelectList(serviceManager.List(), "Id", "Title", projectsDones.ServicesId);
            return View(projectsDones);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(ProjectsDones projectsDones, HttpPostedFileBase Image1, HttpPostedFileBase Image2, HttpPostedFileBase Image3)
        {
            ModelState.Remove("ModifiedOn");
            if (ModelState.IsValid)
            {
                ProjectsDones projectsDonesEdit = projectDoneManager.Find(x => x.Id == projectsDones.Id);
                if (Image1 != null &&
                      (Image1.ContentType == "image/jpeg" ||
                       Image1.ContentType == "image/jpg" ||
                       Image1.ContentType == "image/png"))
                {
                    string filename1 = $"{projectsDones.ProjectName}_Image1.{Image1.ContentType.Split('/')[1]}";
                    Image1.SaveAs(Server.MapPath($"~/Image/projectsdone/{filename1}"));
                    projectsDonesEdit.Image1 = filename1;
                }
                if (Image2 != null &&
                      (Image2.ContentType == "image/jpeg" ||
                       Image2.ContentType == "image/jpg" ||
                       Image2.ContentType == "image/png"))
                {
                    string filename2 = $"{projectsDones.ProjectName}_Image2.{Image2.ContentType.Split('/')[1]}";
                    Image2.SaveAs(Server.MapPath($"~/Image/projectsdone/{filename2}"));
                    projectsDonesEdit.Image2 = filename2;
                }
                if (Image3 != null &&
                      (Image3.ContentType == "image/jpeg" ||
                       Image3.ContentType == "image/jpg" ||
                       Image3.ContentType == "image/png"))
                {
                    string filename3 = $"{projectsDones.ProjectName}_Image3.{Image3.ContentType.Split('/')[1]}";
                    Image3.SaveAs(Server.MapPath($"~/Image/projectsdone/{filename3}"));
                    projectsDonesEdit.Image3 = filename3;
                }

                projectsDonesEdit.ProjectName = projectsDones.ProjectName;
                projectsDonesEdit.ServicesId = projectsDones.ServicesId;
                projectsDonesEdit.Teknologies = projectsDones.Teknologies;
                projectsDonesEdit.Description = projectsDones.Description;
                projectsDonesEdit.ProjectDoneDate = projectsDones.ProjectDoneDate;
                projectsDonesEdit.Customer = projectsDones.Customer;
                projectDoneManager.Update(projectsDonesEdit);
                return RedirectToAction("Index");
            }
            ViewBag.ServicesId = new SelectList(serviceManager.List(), "Id", "Title", projectsDones.ServicesId);
            return View(projectsDones);
        }

        [HttpPost]
        public ActionResult Delete(int? id)
        {
            ProjectsDones projectsDone = projectDoneManager.Find(x => x.Id == id.Value);
            if (projectsDone != null)
            {
                int res = projectDoneManager.Delete(projectsDone);
                if (res > 0)
                {
                    System.IO.File.Delete(Server.MapPath($"~/Images/projectsdone/{projectsDone.ProjectName}_Image1"));
                    System.IO.File.Delete(Server.MapPath($"~/Images/projectsdone/{projectsDone.ProjectName}_Image2"));
                    System.IO.File.Delete(Server.MapPath($"~/Images/projectsdone/{projectsDone.ProjectName}_Image3"));
                    return Json(new { hasError = false, Message = $"{ projectsDone.ProjectName }" + " adlı proje başarılı bir şekilde silindi." }, JsonRequestBehavior.AllowGet);
                    //return Json(new { hasError = false, Massage = "Personel başarılı bir şekilde silindi." });
                }
                else
                {
                    return Json(new { hasError = true, Message = $"{ projectsDone.ProjectName }" + " adlı proje silinirken hata oluştu." }, JsonRequestBehavior.AllowGet);
                    //return Json(new { hasError = true, Message = "Personel silinirken hata oluştu." });
                }
            }
            return Json(new { results = true, Message = $"{ projectsDone.ProjectName }" + " adlı bir personel bulunamadı." }, JsonRequestBehavior.AllowGet);
        }
    }
}