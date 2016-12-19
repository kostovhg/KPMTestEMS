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
    public class HomeController : Controller
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
            TestDbContext database = new TestDbContext();

            var model = new ProductionViewModel();

            //model.Brand = database.Brand;
            //model.Width = database.Width;
            

            return View(model);
        }
    }
}