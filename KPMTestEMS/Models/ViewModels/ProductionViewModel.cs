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

        public string ClientId { get; set; }
        public string SelectedBrandId { get; set; }
        public IEnumerable<SelectListItem> AvaiableBrands { get; set; }
        public string SelectedWeightId { get; set; }
        public IEnumerable<SelectListItem> AvaiableWeights { get; set; }
        public string SelectedWidthId { get; set; }
        public IEnumerable<SelectListItem> AvaiableWidths { get; set; }

        public DateTime DueDate { get; set; }

        public int Quantity { get; set; }
        public string Comment { get; set; }

        public ProductionViewModel()
        {
            AvaiableBrands = new List<SelectListItem>();
            AvaiableWeights = new List<SelectListItem>();
            AvaiableWeights = new List<SelectListItem>();
        }
    }
}
