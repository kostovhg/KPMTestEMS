using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KPMTestEMS.Controllers.Trader
{
    public class ProductController : Controller
    {
        // GET: Products
        public ActionResult Index()
        {
            return RedirectToAction("UnderConstruction", controllerName: "Home");
        }

        // GET: Products/List
        public ActionResult List()
        {
            return RedirectToAction("UnderConstruction", controllerName: "Home");
        }

        // GET: Procuts/Create
        public ActionResult Create()
        {
            return RedirectToAction("UnderConstruction", controllerName: "Home");
        }

        // POST: Products/Create
        [HttpPost]
        public ActionResult CreateProduct()
        {
            return RedirectToAction("UnderConstruction", controllerName: "Home");
        }

        // GET: Products/Edit
        public ActionResult Edit()
        {
            return RedirectToAction("UnderConstruction", controllerName: "Home");
        }

        // POST: Products/Edit
        [HttpPost]
        public ActionResult EditProduct()
        {
            return RedirectToAction("UnderConstruction", controllerName: "Home");
        }

        // GET: Products/Remove
        public ActionResult Remove()
        {
            return RedirectToAction("UnderConstruction", controllerName: "Home");
        }

        // Post: Products/Remove
        [HttpPost]
        public ActionResult RemoveProduct()
        {
            return RedirectToAction("UnderConstruction", controllerName: "Home");
        }
    }
}