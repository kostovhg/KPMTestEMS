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
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            // Seed defalut values for products if database is empty
            if (!context.Brand.Any())
            {
                context.Brand.AddOrUpdate(
                    b => b.PaperBrand,
                    new Brand { PaperBrand = "TP" },
                    new Brand { PaperBrand = "KT" },
                    new Brand { PaperBrand = "KN" }
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
            
            if(!context.Weight.Any())
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

            // Seeding role of admin in AspNetRoles.
            // Source http://stackoverflow.com/questions/19280527/mvc-5-seed-users-and-roles
            if (!context.Roles.Any(r => r.Name == "Admin"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                manager.Create(new IdentityRole { Name = "Admin" });
                manager.Create(new IdentityRole { Name = "Trader" });
                manager.Create(new IdentityRole { Name = "Client" });
            }

            if (!context.Users.Any())
            {
                this.CreateUser(context, "admin@kpm.bg", "Admin", "KPM", "Admin", "123");
                this.SetRoleToUser(context, "admin@kpm.bg", "Admin");
                this.CreateUser(context, "trader@kpm.bg", "Ivan Ivanov", "KPM", "Trader", "123");
                this.SetRoleToUser(context, "trader@kpm.bg", "Trader");
                this.CreateUser(context, "pesho@abv.bg", "Petar Petrov", "Petrov OOD", "Owner", "123");
                this.SetRoleToUser(context, "pesho@abv.bg", "Client");

            }
        }

        private void SetRoleToUser(TestDbContext context, string email, string role)
        {
            var store = new UserStore<ApplicationUser>(context);
            var manager = new UserManager<ApplicationUser>(store);

            var user = context.Users.Where(u => u.Email.Equals(email)).First();

            var result = manager.AddToRole(user.Id, role);

            if (!result.Succeeded)
            {
                throw new Exception(string.Join(";", result.Errors));
            }
        }

        private void CreateUser(TestDbContext context, string email, string fullName, string company, string possition, string password)
        {
            var store = new UserStore<ApplicationUser>(context);
            var manager = new UserManager<ApplicationUser>(store);
            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 1,
                RequireDigit = false,
                RequireLowercase = false,
                RequireNonLetterOrDigit = false,
                RequireUppercase = false,
            };

            var user = new ApplicationUser
            {
                UserName = email,
                FullName = fullName,
                Email = email,
                Company = company,
                Position = possition,
                RegistrationDate = DateTime.Now
            };

            var result = manager.Create(user, password);

            if (!result.Succeeded)
            {
                throw new Exception(string.Join("; ", result.Errors));
            }

        }
    }
}
