using KPMTestEMS.Models.Production;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KPMTestEMS.Models
{
    public class OrderViewModel
    {
        // create set of paper properties to be send to the view
        // each property represent set of related table regcords.
        // Except dueDate, wich will be created when view is called.
        public IQueryable<Brand> Brand { get; set; }

        public IQueryable<Weight> Weight { get; set; }

        public IQueryable<Width> Width { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DueDate { get; set;}
    }
}