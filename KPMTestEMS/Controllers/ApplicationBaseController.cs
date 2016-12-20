using KPMTestEMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

// Source https://www.codeproject.com/tips/991663/displaying-user-full-name-instead-of-user-email-in
namespace KPMTestEMS.Controllers
{
    public class ApplicationBaseController : Controller
    {
        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if(User != null)
            {
                var context = new TestDbContext();
                var username = User.Identity.Name;

                if (!string.IsNullOrEmpty(username))
                {
                    var user = context.Users.SingleOrDefault(u => u.UserName == username);
                    string fullName = user.FullName;
                    ViewData.Add("FullName", fullName);
                }
            }
            base.OnActionExecuted(filterContext);
        }

        public ApplicationBaseController() { }

        #region HelperMethods
        // Those methods create enumerable lists for
        // OrderViewModel to be filled in order form
        public IEnumerable<SelectListItem> GetBrands()
        {
            var database = new TestDbContext();
            var brands = database.Brand.Select(b => new SelectListItem
            {
                Value = b.ID.ToString(),
                Text = b.PaperBrand
            });
            return new SelectList(brands, "Value", "Text");
        }
        public IEnumerable<SelectListItem> GetWeights()
        {
            var database = new TestDbContext();
            var weights = database.Weight.Select(b => new SelectListItem
            {
                Value = b.ID.ToString(),
                Text = b.PaperWeight.ToString()
            });
            return new SelectList(weights, "Value", "Text");
        }
        public IEnumerable<SelectListItem> GetWidths()
        {
            var database = new TestDbContext();
            var widths = database.Width.Select(b => new SelectListItem
            {
                Value = b.ID.ToString(),
                Text = b.PaperWidth.ToString()
            });
            return new SelectList(widths, "Value", "Text");
        }
        #endregion
    }
}