using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KPMTestEMS.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        //[Required]
        //public string Type { get; set; }

        [Required]
        public string Brand { get; set; }

        //[Required]
        //public int Layers { get; set; }

        [Required]
        public Single Weight { get; set; }

        [Required]
        public byte Widht { get; set; }

        public string Description { get; set; }

    }
}