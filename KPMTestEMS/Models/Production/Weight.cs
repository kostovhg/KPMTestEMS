using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KPMTestEMS.Models.Production
{
    public class Weight
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public Single PaperWeight { get; set; }
    }
}