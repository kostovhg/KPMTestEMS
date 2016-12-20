using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KPMTestEMS.Controllers.Trader
{
    public class ClientController : ApplicationBaseController
    {
        // GET: Client
        public ActionResult Index()
        {
            return RedirectToAction("UnderConstruction", controllerName: "Home");
        }

        // GET: Client/List
        public ActionResult List()
        {
            return RedirectToAction("UnderConstruction", controllerName: "Home");
        }

        // POST: Client/Details
        public ActionResult Details()
        {
            return RedirectToAction("UnderConstruction", controllerName: "Home");
        }
    }
}