using KPMTestEMS.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KPMTestEMS.Controllers
{
    [Authorize]
    public class ClientOrderController : Controller
    {
        // GET: ClientsOrders
        public ActionResult Index()
        {
            return View();
        }

        // GET: ClientOrder/List
        [HttpGet]
        public ActionResult List()
        {
            TestDbContext database = new TestDbContext();

            var id = User.Identity.GetUserId();

            List<ClientOrder> clientOrders = new List<ClientOrder>();
            foreach (var order in database.ClientsOrders.Where(o => o.ClientId == id).OrderBy(o => o.DueDate))
            {
                clientOrders.Add(order);
            }

            return View(clientOrders);
        }

        private IEnumerable<SelectListItem> GetBrands()
        {
            var database = new TestDbContext();
            var brands = database.Brand.Select(b => new SelectListItem
            {
                Value = b.ID.ToString(),
                Text = b.PaperBrand
            });
            return new SelectList(brands, "Value", "Text");
        }
        private IEnumerable<SelectListItem> GetWeights()
        {
            var database = new TestDbContext();
            var weights = database.Weight.Select(b => new SelectListItem
            {
                Value = b.ID.ToString(),
                Text = b.PaperWeight.ToString()
            });
            return new SelectList(weights, "Value", "Text");
        }
        private IEnumerable<SelectListItem> GetWidths()
        {
            var database = new TestDbContext();
            var widths = database.Width.Select(b => new SelectListItem
            {
                Value = b.ID.ToString(),
                Text = b.PaperWidth.ToString()
            });
            return new SelectList(widths, "Value", "Text");
        }
        // GET: ClientOrder/Create
        [HttpGet]
        public ActionResult Create()
        {
            var model = new ProductionViewModel
            {
                AvaiableBrands = GetBrands(),
                AvaiableWeights = GetWeights(),
                AvaiableWidths = GetWidths(),
                DueDate = DateTime.Now
            };

            return View(model);
        }

        // POST: ClientOrder/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateOrder(ProductionViewModel model)
        {
            var errors = ModelState
                .Where(x => x.Value.Errors.Count > 0)
                .Select(x => new { x.Key, x.Value.Errors })
                .ToArray();

            if (!ModelState.IsValid)
            {
                return RedirectToAction("Create");
            }

            using (var database = new TestDbContext())
            {
                // Get Client id
                var clientId = database.Users
                    .Where(u => u.UserName == this.User.Identity.Name)
                    .First()
                    .Id;
                // create new object <ClientOrder>
                // take model string values for SelectedId's
                // and parse them to integers to match
                // indexes id's in ClientOrder table
                var clientOrder = new ClientOrder(
                    clientId,
                    int.Parse(model.SelectedBrandId),
                    int.Parse(model.SelectedWeightId),
                    int.Parse(model.SelectedWidthId),
                    model.DueDate,
                    model.Quantity,
                    model.Comment
                    );

                // save changes
                database.ClientsOrders.Add(clientOrder);
                database.SaveChanges();
                //database.ClientsOrders.Add(model);

                return RedirectToAction("List");
            }

        }
    }
}