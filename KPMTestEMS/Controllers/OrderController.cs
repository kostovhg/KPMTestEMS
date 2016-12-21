using KPMTestEMS.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;


namespace KPMTestEMS.Controllers
{
    // Controller for handling operations with Orders

    [Authorize]
    public class OrderController : ApplicationBaseController
    {
        // GET: Orders
        public ActionResult Index()
        {
            return RedirectToAction("List");
        }

        // GET: Order/List
        // Source: https://www.asp.net/mvc/overview/getting-started/getting-started-with-ef-using-mvc/sorting-filtering-and-paging-with-the-entity-framework-in-an-asp-net-mvc-application
        public async Task<ActionResult> List(string sortOrder, string currentFilter, string searchString, int? page)
        {
            #region SwitchSortingParameters
            ViewBag.CurrentSort = sortOrder;
            ViewData["IdSortParam"] = String.IsNullOrEmpty(sortOrder) ? "id_desc" : "";
            ViewData["DateSortParam"] = sortOrder == "Date" ? "date_desc" : "Date";
            ViewData["ClientSortParam"] = sortOrder == "Client" ? "client_desc" : "Client";
            ViewData["BrandSortParam"] = sortOrder == "Brand" ? "brand_desc" : "Brand";
            ViewData["WeightSortParam"] = sortOrder == "Weight" ? "weight_desc" : "Weight";
            ViewData["WidthSortParam"] = sortOrder == "Width" ? "width_desc" : "Width";
            ViewData["QuantitySortParam"] = sortOrder == "Quantity" ? "quantity_desc" : "Quantity";
            ViewData["StatusSortParam"] = sortOrder == "Status" ? "status_desc" : "Status";
            ViewData["CurrentFilter"] = searchString;

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;
            #endregion
            // Create instance of database, take curent user id
            var database = new TestDbContext();
            var id = User.Identity.GetUserId();
            // Create IQueryable set of ClientOrder type, to allow query for filtering Clients Orders
            IQueryable<ClientOrder> orders;

            // Filter orders for logget user if he is a client
            if (User.IsInRole("Trader") || User.IsInRole("Admin"))
            {
                orders = from o in database.ClientsOrders select o;

                // Check if there is search string in URI and filter by users if such exist
                // Search is currently avaiable only for Admin and Trader
                if (!String.IsNullOrEmpty(searchString))
                {
                    orders = orders.Where(o => o.Client.Company.Contains(searchString)
                    || o.Client.FullName.Contains(searchString) || o.Client.Email.Contains(searchString));
                }
            }
            else
            {
                orders = from o in database.ClientsOrders where o.ClientId == id select o;
            }

            #region Sorting
            switch (sortOrder)
            {
                case "date_desc":
                    orders = orders.OrderByDescending(o => o.DueDate);
                    break;
                case "Date":
                    orders = orders.OrderBy(o => o.DueDate);
                    break;
                case "client_desc":
                    orders = orders.OrderByDescending(o => o.Client.Company);
                    break;
                case "Client":
                    orders = orders.OrderBy(o => o.Client.Company);
                    break;
                case "brand_desc":
                    orders = orders.OrderByDescending(o => o.Brand.PaperBrand);
                    break;
                case "Brand":
                    orders = orders.OrderBy(o => o.Brand.PaperBrand);
                    break;
                case "weight_desc":
                    orders = orders.OrderByDescending(o => o.Weight.PaperWeight);
                    break;
                case "Weight":
                    orders = orders.OrderBy(o => o.Weight.PaperWeight);
                    break;
                case "width_desc":
                    orders = orders.OrderByDescending(o => o.Width.PaperWidth);
                    break;
                case "Width":
                    orders = orders.OrderBy(o => o.Width.PaperWidth);
                    break;
                case "quantity_desc":
                    orders = orders.OrderByDescending(o => o.Quantity);
                    break;
                case "Quantity":
                    orders = orders.OrderBy(o => o.Quantity);
                    break;
                case "status_desc":
                    orders = orders.OrderByDescending(o => o.Status);
                    break;
                case "Status":
                    orders = orders.OrderBy(o => o.Status);
                    break;
                case "id_desc":
                    orders = orders.OrderByDescending(o => o.ID);
                    break;
                default:
                    orders = orders.OrderBy(o => o.ID);
                    break;

            }
            #endregion

            //int pageSize = 3;
            int pageNumber = (page ?? 1);
            //orders.ToPagedList(pageNumber, pageSize);
            return View(await orders.AsNoTracking().ToListAsync());
        }

        // GET: Order/Create
        [HttpGet]
        public ActionResult Create()
        {
            var model = new OrderViewModel
            {
                AvaiableBrands = GetBrands(),
                AvaiableWeights = GetWeights(),
                AvaiableWidths = GetWidths(),
                DueDate = DateTime.Now
            };

            return View(model);
        }

        // POST: Order/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateOrder(OrderViewModel model)
        {
            var errors = ModelState
                .Where(x => x.Value.Errors.Count > 0)
                .Select(x => new { x.Key, x.Value.Errors })
                .ToArray();

            if (!ModelState.IsValid)
            {
                
                return RedirectToAction("Create");
            }

            if(model.SelectedBrandId == null || model.SelectedWeightId == null || model.SelectedWidthId == null)
            {
                string message = "";
                if (model.SelectedBrandId == null)
                    message = "You did not select brand";
                if (model.SelectedWeightId == null)
                    message = "You did not select weight";
                if (model.SelectedWidthId == null)
                    message = "You did not select width";
                ViewBag.Message = message;

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
                    "Pending",
                    model.Comment
                    );

                // save changes
                database.ClientsOrders.Add(clientOrder);
                database.SaveChanges();
                //database.ClientsOrders.Add(model);

                return RedirectToAction("List");
            }

        }

        // GET: Orders/Edit
        public ActionResult Edit(int id)
        {
            //using (var database = new TestDbContext())
            //{
            //    // Get order from database
            //    var order = database.ClientsOrders
            //        .Where(o => o.ID == id)
            //        .First();

            //    // Create a view model
            //    var model = new OrderViewModel();
            //    model.ClientId = order.ClientId;
            //    model.DueDate = order.DueDate;
            //    model.Quantity = order.Quantity;
            //    model.Comment = order.Comment;

            //    // Pass the model to the view
            //    return View(model);
            //}
            return RedirectToAction("UnderConstruction", controllerName: "Home");
        }

        // POST: Orders/Edit
        [HttpPatch]
        public ActionResult EditOrder(int id)
        {
            return RedirectToAction("UnderConstruction", controllerName: "Home");
        }

        // GET: Orders/Delete
        public ActionResult Delete()
        {
            return RedirectToAction("UnderConstruction", controllerName: "Home");
        }

        // POST: Orders/Delete
        [HttpPost]
        public ActionResult DeleteOrder()
        {
            return RedirectToAction("UnderConstruction", controllerName: "Home");
        }


        #region HelperMethods

        // GET: Order/ProfileDetails
        public ActionResult ProfileDetails()
        {
            return RedirectToAction("ProfileDetails", "Manage");
        }


        // Folloing methods are currently part of parent ApplicationBaseController 

        // Those methods create enumerable lists for
        // OrderViewModel to be filled in order form
        //private IEnumerable<SelectListItem> GetBrands()
        //{
        //    var database = new TestDbContext();
        //    var brands = database.Brand.Select(b => new SelectListItem
        //    {
        //        Value = b.ID.ToString(),
        //        Text = b.PaperBrand
        //    });
        //    return new SelectList(brands, "Value", "Text");
        //}
        //private IEnumerable<SelectListItem> GetWeights()
        //{
        //    var database = new TestDbContext();
        //    var weights = database.Weight.Select(b => new SelectListItem
        //    {
        //        Value = b.ID.ToString(),
        //        Text = b.PaperWeight.ToString()
        //    });
        //    return new SelectList(weights, "Value", "Text");
        //}
        //private IEnumerable<SelectListItem> GetWidths()
        //{
        //    var database = new TestDbContext();
        //    var widths = database.Width.Select(b => new SelectListItem
        //    {
        //        Value = b.ID.ToString(),
        //        Text = b.PaperWidth.ToString()
        //    });
        //    return new SelectList(widths, "Value", "Text");
        //} 
        #endregion
    }
}