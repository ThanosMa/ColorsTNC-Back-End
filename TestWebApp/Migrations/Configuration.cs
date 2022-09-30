namespace TestWebApp.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using TestWebApp.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<TestWebApp.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        /// <summary>
        /// Creating Roles and Admin User
        /// </summary>
        /// <param name="context"></param>
        protected override void Seed(TestWebApp.Models.ApplicationDbContext context)
        {
            if (!context.Roles.Any(x => x.Name == "Admin"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole() { Name = "Admin" };
                manager.Create(role);
            }
            if (!context.Roles.Any(x => x.Name == "Employee"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole() { Name = "Employee" };
                manager.Create(role);
            }
            if (!context.Roles.Any(x => x.Name == "Visitor"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole() { Name = "Visitor" };
                manager.Create(role);
            }
            var passwordHass = new PasswordHasher();//ergaliothikh gia na kruptografw kwdikous
            if (!context.Users.Any(x => x.Email == "Thanos@gmail.com"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store); // gnostopoiw sto Asp.Net
                var user = new ApplicationUser()   //ftiaxnw ton user
                {
                    UserName = "Thanos",
                    Email = "Thanos@gmail.com",
                    PasswordHash = passwordHass.HashPassword("123"),
                    FirstName = "Athanasios",
                    LastName = "Mastrogiannis"
                };
                manager.Create(user);
                manager.AddToRole(user.Id, "Admin");
            }
        }
    }
}
