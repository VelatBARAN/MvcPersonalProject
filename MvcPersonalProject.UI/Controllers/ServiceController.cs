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
    public class ServiceController : Controller
    {
        private ServiceManager serviceManager = new ServiceManager();

        public ActionResult Index()
        {
            return View(serviceManager.ListQueryable().OrderByDescending(x=>x.CreatedOn).ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Services services = serviceManager.Find(x => x.Id == id.Value);
            if (services == null)
            {
                return HttpNotFound();
            }
            return View(services);
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Services services = serviceManager.Find(x => x.Id == id.Value);
            if (services == null)
            {
                return HttpNotFound();
            }
            return View(services);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]

        public ActionResult Edit(Services services)
        {
            if (ModelState.IsValid)
            {
                Services s = serviceManager.Find(x => x.Id == services.Id);
                s.Text = services.Text;
                s.Title = services.Title;
                serviceManager.Update(s);
                return RedirectToAction("Index");
            }
            return View(services);
        }
    }
}