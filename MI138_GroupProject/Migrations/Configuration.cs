namespace MI138_GroupProject.Migrations
{
    using MI138_GroupProject.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Web.Security;

    internal sealed class Configuration : DbMigrationsConfiguration<MI138_GroupProject.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "MI138_GroupProject.Models.ApplicationDbContext";
        }

        protected override void Seed(MI138_GroupProject.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            if (!context.Roles.Any(r => r.Name == "Admin" || r.Name == "User" || r.Name == "Developer"))
            {
                var roleStore = new RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(roleStore);
                var userRole = new IdentityRole { Name = "User" };
                var adminRole = new IdentityRole { Name = "Admin" };
                var devRole = new IdentityRole { Name = "Developer" };
                roleManager.Create(userRole);
                roleManager.Create(adminRole);
                roleManager.Create(devRole);
            }

            if (!context.Users.Any(u => u.UserName == "admin"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new ApplicationUserManager(store);
                var admin = new ApplicationUser { UserName = "admin", Email = "admin@mail.com" };

                manager.Create(admin, "P@stWork2893");
                manager.AddToRole(admin.Id, "Admin");
            }
        }
    }
}
