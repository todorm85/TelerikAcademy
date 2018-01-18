namespace SolutionTemplate.Data.Migrations
{
    using Data;
    using Microsoft.AspNet.Identity;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<SolutionTemplateDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(SolutionTemplateDbContext context)
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

            //var continentsCount = 7;
            //var continents = new Continent[continentsCount];
            //for (int i = 1; i <= continentsCount; i++)
            //{
            //    continents[i - 1] = new Continent { Id = i, Name = $"Continent_{i}" };
            //}

            //context.Continents.AddOrUpdate(continents);
        }
    }
}
