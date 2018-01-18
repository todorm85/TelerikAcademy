namespace ExpenseTracker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateRecordAndCategory : DbMigration
    {
        public override void Up()
        {
            this.CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ParentCategoryId = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.ParentCategoryId)
                .Index(t => t.ParentCategoryId)
                .Index(t => t.IsDeleted);
            
            this.CreateTable(
                "dbo.Records",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Expense = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Income = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CategoryId = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId)
                .Index(t => t.IsDeleted);
            
        }
        
        public override void Down()
        {
            this.DropForeignKey("dbo.Records", "CategoryId", "dbo.Categories");
            this.DropForeignKey("dbo.Categories", "ParentCategoryId", "dbo.Categories");
            this.DropIndex("dbo.Records", new[] { "IsDeleted" });
            this.DropIndex("dbo.Records", new[] { "CategoryId" });
            this.DropIndex("dbo.Categories", new[] { "IsDeleted" });
            this.DropIndex("dbo.Categories", new[] { "ParentCategoryId" });
            this.DropTable("dbo.Records");
            this.DropTable("dbo.Categories");
        }
    }
}
