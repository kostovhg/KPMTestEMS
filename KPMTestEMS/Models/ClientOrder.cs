using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KPMTestEMS.Models
{
    public class ClientOrder
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [ForeignKey("Client")]
        public string ClientId { get; set; }

        public virtual ApplicationUser Client { get; set; }

        [Required]
        //[ForeignKey("Brand")]
        public int BrandId { get; set; }

        [Required]
        //[ForeignKey("Weight")]
        public int WeightId { get; set; }

        [Required]
        //[ForeignKey("Width")]
        public int WidthId { get; set; }

        [Required]
        public int Quantity { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DueDate { get; set; }

        public string Status { get; set; }

        public string ClientComment { get; set; }

        public string Comment { get; set; }

        public ClientOrder()
        {
        }

        public ClientOrder(
            string clientId,
            int brandId,
            int weightId,
            int widthId,
            DateTime dueDate,
            int quantity
            )
        {
            this.ClientId = clientId;
            this.BrandId = brandId;
            this.WeightId = weightId;
            this.WidthId = widthId;
            this.DueDate = dueDate;
        }
    }
}