using KPMTestEMS.Models;
using KPMTestEMS.Models.Production;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KPMTestEMS.Controllers
{
    public class HomeController : ApplicationBaseController
    {
        // GET: Home/Index
        public ActionResult Index()
        {
            return View();
        }

        // GET: Home/About
        public ActionResult About()
        {
            ViewBag.Message = "Details about the system";

            return View();
        }

        // GET: /Home/Contact
        public ActionResult Contact()
        {
            ViewBag.Message = "Contact of the administrator";

            return View();
        }

        // GET /Home/ViewProducts
        public ActionResult ViewProducts()
        {
            var model = new ProductsViewModel();

            return View(model);
        }

        // Get: /Home/ProfileDetails
        public ActionResult ProfileDetails()
        {
            return RedirectToAction("ProfileDetails", "Manage");
        }

        // Get: /Home/Create
        public ActionResult Create()
        {
            return RedirectToAction("Create", "ClientOrder");
        }

        // Get: /Home/List
        public ActionResult List()
        {
            return RedirectToAction("List", "ClientOrder");
        }
    }
}