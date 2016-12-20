using KPMTestEMS.Models.Production;
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
        [ForeignKey("Brand")]
        public int BrandId { get; set; }
        public virtual Brand Brand { get; set; }

        [Required]
        [ForeignKey("Weight")]
        public int WeightId { get; set; }
        
        public virtual Weight Weight{ get; set; }

        [Required]
        [ForeignKey("Width")]
        public int WidthId { get; set; }
        public virtual Width Width{ get; set; }

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
            int brand,
            int weight,
            int width,
            DateTime dueDate,
            int quantity,
            string status,
            string comment
            )
        {
            this.ClientId = clientId;
            this.BrandId = brand;
            this.WeightId = weight;
            this.WidthId = width;
            this.DueDate = dueDate;
            this.Quantity = quantity;
            this.Status = status;
            this.Comment = comment;
        }
    }
}