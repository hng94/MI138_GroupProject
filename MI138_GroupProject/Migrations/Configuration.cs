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

            var admin = new ApplicationUser { UserName = "admin", Email = "admin@mi138.com" };

            if (!context.Users.Any(u => u.UserName == "admin"))
            {
                base.Seed(context);

                var applicationUserManager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));

                var result = applicationUserManager.Create(admin, "MI138@project");

                if (!result.Succeeded)
                    throw new Exception();
            }

            if (!context.Games.Any(g => g.Name == "Game Sample"))
            {
                var game1 = new Game();
                game1.Created = DateTime.Now;
                game1.CreatedBy = context.Users.FirstOrDefault(u => u.UserName == "admin");
                game1.Name = "Game Sample";
                game1.ScreenshotUrl = "https://www.foxsportsasia.com/uploads/2019/01/images-54.jpeg";
                game1.Published = true;
                game1.Tags = "MOBA";
                context.Games.Add(game1);
            }

            context.SaveChanges();
        }
    }
}
