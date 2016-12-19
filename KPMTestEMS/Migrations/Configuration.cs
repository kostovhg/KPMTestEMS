namespace KPMTestEMS.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Models.Production;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Microsoft.AspNet.Identity;
    using System.Collections.Generic;
    using Models;

    public sealed class Configuration : DbMigrationsConfiguration<KPMTestEMS.Models.TestDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            
        }

        protected override void Seed(KPMTestEMS.Models.TestDbContext context)
        { 
       
        }
    }
}
