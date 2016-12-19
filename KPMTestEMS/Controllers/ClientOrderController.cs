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

            List<ClientOrder> orders = database.ClientsOrders.Where(o => o.ClientId == id).ToList();

            return View(orders);
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
        // GET: ClientOrder/Create
        [HttpGet]
        public ActionResult Create()
        {
            TestDbContext database = new TestDbContext();

            var model = new ProductionViewModel();

            model.DueDate = DateTime.Now.AddDays(10);

            // Fill temporal lists for view model from database
            //var brandList = new List<Brands>();
            //foreach (var brand in database.Brand)
            //    brandList.Add(new Brands { Id = brand.ID, Name = brand.PaperBrand });
            //var weightList = new List<Weights>();
            //foreach (var weight in database.Weight)
            //    weightList.Add(new Weights { Id = weight.ID, WeightValue = weight.PaperWeight });
            //var widthList = new List<Widths>();
            //foreach (var width in database.Width)
            //{
            //    widthList.Add(new Widths { Id = width.ID, WidthValue = width.PaperWidth });
            //}

            model.BrandList = GetBrands();
            //model.WeightList = weightList;
            //model.WidhtList = widthList;

            model.SelectedBrand = 3;
            model.SelectedWeight = 1;
            model.SelectedWidth = 2;

            return View(model);
        }

        // POST: ClientOrder/Create
        [HttpPost]
        //[ValidateAntiForgeryToken]
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

                // Get model data

                // Select Brand Id is in model.BrandList
                // todo :save and redirect

                // dave changes
                //database.ClientsOrders.Add(model);

                return RedirectToAction("List");
            }

        }
    }
}