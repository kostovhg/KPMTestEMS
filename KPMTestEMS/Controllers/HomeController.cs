using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KPMTestEMS.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Details about the system";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contact of the administrator";

            return View();
        }
    }
}