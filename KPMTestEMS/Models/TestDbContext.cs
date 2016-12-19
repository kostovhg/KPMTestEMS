using KPMTestEMS.Models.Production;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace KPMTestEMS.Models
{
    //
    // Separated model for accessing and modifying the datebase.
    public class TestDbContext : IdentityDbContext<ApplicationUser>
    {

        public TestDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        // include code created class as model for database table
        // so every thime when we create TestDbContext, we can reach ClientsOrders table
        public virtual IDbSet<ClientOrder> ClientsOrders { get; set; }

        public virtual IDbSet<Brand> Brand { get; set;}

        public virtual IDbSet<Weight> Weight { get; set; }

        public virtual IDbSet<Width> Width { get; set; }

        public static TestDbContext Create()
        {
            return new TestDbContext();
        }

        //public System.Data.Entity.DbSet<KPMTestEMS.Models.Product> Products { get; set; }
    }
}