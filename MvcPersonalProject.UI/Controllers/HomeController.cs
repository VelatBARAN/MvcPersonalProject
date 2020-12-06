using MvcPersonalProject.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcPersonalProject.UI.Controllers
{
    public class HomeController : Controller
    {
        private ServiceManager serviceManager = new ServiceManager();

        public ActionResult Index()
        {
            serviceManager.List();
            return View();
        }
    }
}