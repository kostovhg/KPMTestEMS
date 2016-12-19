using KPMTestEMS.Models.Production;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace KPMTestEMS.Models.Helpers
{
    public class SeedHelper
    {
        internal static void SeedDatabase(TestDbContext context)
        {
            SeedProductionParameters(context);
            SeedRolesAndUsers(context);
        }

        private static void SeedProductionParameters(TestDbContext context)
        {
            if (!context.Brand.Any())
            {
                context.Brand.AddOrUpdate(
                    b => b.PaperBrand,
                    new Brand {
                        PaperBrand = "TP",
                        FullName = "Toilet Paper",
                        Description = "Tissue product for sanitary-higienic use. Mass 14,5 - 35 gsm. Play 1-3. Reel width min 17 cm, max 275 cm. Core 76, 150 or 273 mm. External diameter maximum 200 cm."},
                    new Brand
                    {
                        PaperBrand = "KT",
                        FullName = "Kitchen towels",
                        Description = "Tissue product for sanitary-higienic use. Mass 14,5 - 35 gsm. Play 1-3. Reel width min 17 cm, max 275 cm. Core 76, 150 or 273 mm. External diameter maximum 200 cm."},
                    new Brand
                    {
                        PaperBrand = "FT",
                        FullName = "Facial tissue",
                        Description = "Tissue product for sanitary-higienic use. Mass 14,5 - 35 gsm. Play 1-3. Reel width min 17 cm, max 275 cm. Core 76, 150 or 273 mm. External diameter maximum 200 cm."}
                    );
            }

            if (!context.Width.Any())
            {
                context.Width.AddOrUpdate(
                    w => w.PaperWidth,
                    new Width { PaperWidth = 36 },
                    new Width { PaperWidth = 44 },
                    new Width { PaperWidth = 65 },
                    new Width { PaperWidth = 84 },
                    new Width { PaperWidth = 110 },
                    new Width { PaperWidth = 122 },
                    new Width { PaperWidth = 156 },
                    new Width { PaperWidth = 165 },
                    new Width { PaperWidth = 255 }
                );
            }

            if (!context.Weight.Any())
            {
                context.Weight.AddOrUpdate(
                    w => w.PaperWeight,
                    new Weight { PaperWeight = 14f },
                    new Weight { PaperWeight = 14.5f },
                    new Weight { PaperWeight = 15f },
                    new Weight { PaperWeight = 15.5f },
                    new Weight { PaperWeight = 16f },
                    new Weight { PaperWeight = 17f },
                    new Weight { PaperWeight = 18f },
                    new Weight { PaperWeight = 20f }
                );
            }
        }

        private static void SeedRolesAndUsers(TestDbContext context)
        {

            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            if (!roleManager.RoleExists(RoleNames.ROLE_ADMINISTRATOR))
            {
                var roleresult = roleManager.Create(new IdentityRole(RoleNames.ROLE_ADMINISTRATOR));
            }
            if (!roleManager.RoleExists(RoleNames.ROLE_TRADER))
            {
                var roleresult = roleManager.Create(new IdentityRole(RoleNames.ROLE_TRADER));
            }
            if (!roleManager.RoleExists(RoleNames.ROLE_CLIENT))
            {
                var roleresult = roleManager.Create(new IdentityRole(RoleNames.ROLE_CLIENT));
            }

            var users = new string[5, 4] {
                { "admin@kpm.bg", "trader@kpm.bg", "ivan@abv.bg", "pesho@abv.bg"},
                { "Admin", "Petar Petrov", "Ivan Ivanov", "Petar Ivanov"},
                { "KPM EAD", "KPM EAD", "IvanovInvest EOOD", "TarnovoPaper AD"},
                { "Admin", "Trader", "Owner", "Production Manager"},
                { "Admin", "Trader", "Client", "Client"}
            };

            for (int i = 0; i < users.GetLength(1); i++)
            {
                ApplicationUser user = userManager.FindByName(users[0, i]);


                if (user == null)
                {
                    userManager.PasswordValidator = new PasswordValidator
                    {
                        RequiredLength = 1,
                        RequireDigit = false,
                        RequireLowercase = false,
                        RequireNonLetterOrDigit = false,
                        RequireUppercase = false,
                    };

                    user = new ApplicationUser()
                    {
                        UserName = users[0, i],
                        Email = users[0, i],
                        FullName = users[1, i],
                        Company = users[2, i],
                        Position = users[3, i],
                        RegistrationDate = DateTime.Now,
                    };
                    IdentityResult userResult = userManager.Create(user, "123");
                    if (userResult.Succeeded)
                    {
                        var result = userManager.AddToRole(user.Id, users[4, i]);
                    }
                }
            }
        }
    }
}