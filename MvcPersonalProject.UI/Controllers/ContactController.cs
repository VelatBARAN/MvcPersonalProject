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
    public class ContactController : Controller
    {
        private ContactManager contactManager = new ContactManager();
        public ActionResult Index()
        {
            return View(contactManager.List());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contact contact = contactManager.Find(x => x.Id == id.Value);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contact contact = contactManager.Find(x => x.Id == id.Value);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]

        public ActionResult Edit(Contact contact)
        {
            if (ModelState.IsValid)
            {
                Contact c = contactManager.Find(x => x.Id == contact.Id);
                c.Location = contact.Location;
                c.Email = contact.Email;
                c.Phone = contact.Phone;
                contactManager.Update(c);
                return RedirectToAction("Index");
            }
            return View(contact);
        }
    }
}