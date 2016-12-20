using KPMTestEMS.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace KPMTestEMS.Controllers.Trader
{
    [Authorize(Roles = "Trader")]
    public class OrdersController : Controller
    {
        // GET: Orders
        public ActionResult Index()
        {
            return RedirectToAction("List");
        }

        // GET: Orders/List
        public async Task<ActionResult> List(string sortOrder, string searchString)
        {
            ViewData["DateSortParam"] = sortOrder == "Date" ? "date_desc" : "Date";
            ViewData["ClientSortParam"] = sortOrder == "Client" ? "client_desc" : "Client";
            ViewData["BrandSortParam"] = sortOrder == "Brand" ? "brand_desc" : "Brand";
            ViewData["WeightSortParam"] = sortOrder == "Weight" ? "weight_desc" : "Weight";
            ViewData["WidthSortParam"] = sortOrder == "Width" ? "width_desc" : "Width";
            ViewData["QuantitySortParam"] = sortOrder == "Quantity" ? "quantity_desc" : "Quantity";
            ViewData["StatusSortParam"] = sortOrder == "Status" ? "Status_desc" : "Quantity";
            ViewData["CurrentFilter"] = searchString;

            var database = new TestDbContext();

            //var orders = from o in database.ClientsOrders where o.Status != "Deleted" select o;
            var orders = from o in database.ClientsOrders select o;

            if (!String.IsNullOrEmpty(searchString))
            {
                orders = orders.Where(o => o.Client.Company.Contains(searchString)
                || o.Client.FullName.Contains(searchString) || o.Client.Email.Contains(searchString));
            }

            //List<ClientOrder> orders = database.ClientsOrders.ToList()

            switch(sortOrder)
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
                case "Weigth":
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
                    orders = orders.OrderByDescending(o => o.Quantity);
                    break;
                case "Status":
                    orders = orders.OrderBy(o => o.Quantity);
                    break;
                default:
                    orders = orders.OrderBy(o => o.ID);
                    break;

            }

            return View(await orders.AsNoTracking().ToListAsync());
        }

        // GET: Orders/EditOrder
        public ActionResult Edit(int id)
        {
            using (var database = new TestDbContext())
            {
                // Get order from database
                var order = database.ClientsOrders
                    .Where(o => o.ID == id)
                    .First();

                // Create a view model
                var model = new OrderViewModel();
                model.ClientId = order.ClientId;
                model.DueDate = order.DueDate;
                model.Quantity = order.Quantity;
                model.Comment = order.Comment;

                // Pass the model to the view
                return View(model);
            }

        }

        // POST: Orders/EditOrder

        // GET: Orders/DeleteOrder

        // POST: Orders/DeleteOrders
    }
}