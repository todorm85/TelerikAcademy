namespace ExpenseTracker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserToRecord : DbMigration
    {
        public override void Up()
        {
            this.AddColumn("dbo.Records", "UserId", c => c.String(maxLength: 128));
            this.CreateIndex("dbo.Records", "UserId");
            this.AddForeignKey("dbo.Records", "UserId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            this.DropForeignKey("dbo.Records", "UserId", "dbo.AspNetUsers");
            this.DropIndex("dbo.Records", new[] { "UserId" });
            this.DropColumn("dbo.Records", "UserId");
        }
    }
}
