namespace ExpenseTracker.Data.Migrations
{
    using System.Data.Entity.Migrations;

    public sealed class Configuration : DbMigrationsConfiguration<ExpenseTracker.Data.ApplicationDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ExpenseTracker.Data.ApplicationDbContext context)
        {
        }
    }
}
