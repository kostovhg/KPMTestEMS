using KPMTestEMS.Models.Production;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KPMTestEMS.Models
{
    public class ProductsViewModel
    {
        // create set of paper properties to be send to the view
        // each property represent set of related table regcords.
        // Except dueDate, wich will be created when view is called.

        // IQueryable are usable for LINQ reguests.
        // Here we dont have need to sort products
        //public IQueryable<Brand> Brand { get; set; }

        //public IQueryable<Weight> Weight { get; set; }

        //public IQueryable<Width> Width { get; set; }

        public List<Brand> Brand
        {
            get
            {
                using (var context = new TestDbContext())
                {
                    var brands = new List<Brand>();
                    foreach (var br in context.Brand)
                    {
                        brands.Add(br);
                    }

                    return brands;
                }
            }
        }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DueDate { get; set; }

        public List<string> Gmss
        {
            get
            {
                using (var context = new TestDbContext())
                {
                    var weights = new List<string>();
                    foreach (var gms in context.Weight)
                    {
                        weights.Add(gms.PaperWeight.ToString());
                    }

                    return weights;
                }
            }
        }

        public List<string> Sizes
        {
            get
            {
                var context = new TestDbContext();
                var sizes = new List<string>();
                foreach (var size in context.Width)
                {
                    sizes.Add(size.PaperWidth.ToString());
                }

                return sizes;
            }
        }
    }
}