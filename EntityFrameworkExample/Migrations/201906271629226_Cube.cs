namespace EntityFrameworkExample.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Cube : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cubes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Weight = c.Double(nullable: false),
                        SideLength = c.Double(nullable: false),
                        ConstructionMaterial = c.String(),
                        Contents = c.String(),
                        CurrentLocation = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Cubes");
        }
    }
}
