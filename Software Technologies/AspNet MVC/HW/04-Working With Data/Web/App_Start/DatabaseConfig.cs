namespace SimpleTwitter
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using SimpleTwitter.Data;
    using SimpleTwitter.Data.Migrations;
    using SimpleTwitter.Data.Models;

    internal class DatabaseConfig
    {
        public static void Config()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<SimpleTwitterDbContext, Configuration>());
            SimpleTwitterDbContext.Create().Database.Initialize(true);

            Seed();
        }

        public static void Seed()
        {
            var context = new SimpleTwitterDbContext();
            SeedAdmin(context);
        }

        private static void SeedAdmin(SimpleTwitterDbContext context)
        {
            if (!context.Roles.Any(r => r.Name == "Admin"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "Admin" };

                manager.Create(role);
            }

            if (!context.Users.Any(u => u.UserName == "admin"))
            {
                var store = new UserStore<User>(context);
                var manager = new ApplicationUserManager(store);
                var user = new User
                {
                    UserName = "admin",
                    PasswordHash = new PasswordHasher().HashPassword("admin"),
                    SecurityStamp = Guid.NewGuid().ToString()
                };

                context.Users.AddOrUpdate(user);
                context.SaveChanges();
                manager.AddToRole(user.Id, "Admin");
            }

            if (context.Users.Count() <= 1)
            {
                var random = new Random();
                for (int i = 1; i <= 5; i++)
                {
                    var user = new User()
                    {
                        UserName = $"u{i}",
                        PasswordHash = new PasswordHasher().HashPassword($"u{i}"),
                        SecurityStamp = Guid.NewGuid().ToString()
                    };

                    context.Users.AddOrUpdate(user);
                }

                context.SaveChanges();
            }
        }
    }
}