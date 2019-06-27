namespace EntityFrameworkExample.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bag : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bags",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Volume = c.Double(nullable: false),
                        Height = c.Double(nullable: false),
                        ConstructionMaterial = c.String(),
                        Contents = c.String(),
                        CurrentLocation = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Bags");
        }
    }
}
