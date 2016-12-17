using KPMTestEMS.Migrations;
using KPMTestEMS.Models;
using Microsoft.Owin;
using Owin;
using System.Data.Entity;

[assembly: OwinStartupAttribute(typeof(KPMTestEMS.Startup))]
namespace KPMTestEMS
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {

            // Add new configuration on startup of the project with new strategy
            // for migrating database to last version
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<TestDbContext, Configuration>());
            ConfigureAuth(app);
        }
    }
}
