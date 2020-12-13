using MvcPersonalProject.BLL;
using MvcPersonalProject.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
    }
}