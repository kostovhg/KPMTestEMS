using KPMTestEMS.Models.Production;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KPMTestEMS.Models
    {
        //public class Brands
        //{
        //    public int Id { get; set; }
        //    public string Name { get; set; }
        //}

        //public class Weights
        //{
        //    public int Id { get; set; }
        //    public Single WeightValue { get; set; }
        //}

        //public class Widths
        //{
        //    public int Id { get; set; }
        //    public byte WidthValue { get; set; }
        //}
        public class ProductionViewModel
        {
            // create set of paper properties to be send to the view
            // each property represent set of related table regcords.

            public ProductionViewModel()
            {
            }

            public ProductionViewModel(int brandId, DateTime dueDate)
            {

            }

            //public IQueryable<Brand> Brand { get; set; }

            //public IQueryable<Weight> Weight { get; set; }

            //public IQueryable<Width> Width { get; set; }

            public List<string> Gmss
            {
                get
                {
                    var context = new TestDbContext();
                    var weights = new List<string>();
                    foreach (var gms in context.Weight)
                    {
                        weights.Add(gms.PaperWeight.ToString());
                    }

                    return weights;
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

            public DateTime DueDate { get; set; }

            public int? SelectedBrand { get; set; }

            public IEnumerable<SelectListItem> BrandList { get; set; }

            public int? SelectedWeight { get; set; }
            public IEnumerable<SelectListItem> WeightList { get; set; }

            public int? SelectedWidth { get; set; }
            public IEnumerable<SelectListItem> WidhtList { get; set; }

        }


    }
