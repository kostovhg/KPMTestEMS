using KPMTestEMS.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KPMTestEMS.Controllers
{
    public class ClientOrderController : Controller
    {
        // GET: ClientsOrders
        public ActionResult Index()
        {
            return View();
        }

        // GET: ClientOrder/List
        public ActionResult List()
        {
            TestDbContext database = new TestDbContext();

            var id = User.Identity.GetUserId();

            List<ClientOrder> orders = database.ClientsOrders.Where(o => o.ClientId == id).ToList();

            return View(orders);
        }
        // GET: ClientOrder/Create
        public ActionResult Create()
        {

            TestDbContext database = new TestDbContext();

            var model = new OrderViewModel();

            model.Brand = database.Brand;
            model.Weight = database.Weight;
            model.Width = database.Width;
            model.DueDate = DateTime.Now.AddDays(10);

            return View(model);
        }

        // POST: ClientOrder/Create
        [HttpPost]
        public ActionResult Create(OrderViewModel model)
        {
            if(ModelState.IsValid)
            {
                using (var database = new TestDbContext())
                {
                    // Get Client id
                    var clientId = database.Users
                        .Where(u => u.UserName == this.User.Identity.Name)
                        .First()
                        .Id;

                    //ClientOrder order = new Order(
                        
                    //    );
                }
            }

            return View();
        }
    }
}