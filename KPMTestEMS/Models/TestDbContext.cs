using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
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

        public static TestDbContext Create()
        {
            return new TestDbContext();
        }
    }
}