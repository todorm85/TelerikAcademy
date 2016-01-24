namespace Todos.Data.Migrations
{
    using Data;
    using Microsoft.AspNet.Identity;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Countries.Data.Models;
    public sealed class Configuration : DbMigrationsConfiguration<TodosDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(TodosDbContext context)
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

            var categoriesCount = 5;
            var categories = new Category[categoriesCount];
            for (int i = 1; i <= categoriesCount; i++)
            {
                categories[i - 1] = new Category { Id = i, Name = $"Category_{i}" };
            }

            context.Categories.AddOrUpdate(categories);

            var todosCount = 50;
            var todos = new Todo[todosCount];
            for (int i = 1; i <= todosCount; i++)
            {
                todos[i - 1] = new Todo
                {
                    Id = i,
                    CategoryId = (i % categoriesCount) + 1,
                    Title = $"Todo_{i}",
                    Body = $"Todo_{i}_body",
                };
            }

            context.Todos.AddOrUpdate(todos);
        }
    }
}
