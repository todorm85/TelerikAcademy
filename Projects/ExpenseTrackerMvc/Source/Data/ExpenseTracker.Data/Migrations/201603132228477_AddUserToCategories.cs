namespace ExpenseTracker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserToCategories : DbMigration
    {
        public override void Up()
        {
            this.AddColumn("dbo.Categories", "UserId", c => c.String(maxLength: 128));
            this.CreateIndex("dbo.Categories", "UserId");
            this.AddForeignKey("dbo.Categories", "UserId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            this.DropForeignKey("dbo.Categories", "UserId", "dbo.AspNetUsers");
            this.DropIndex("dbo.Categories", new[] { "UserId" });
            this.DropColumn("dbo.Categories", "UserId");
        }
    }
}
