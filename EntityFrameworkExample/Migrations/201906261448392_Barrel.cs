﻿namespace EntityFrameworkExample.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Barrel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Barrels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Weight = c.Double(nullable: false),
                        Radius = c.Double(nullable: false),
                        Height = c.Double(nullable: false),
                        ConstructionMaterial = c.String(),
                        Contents = c.String(),
                        CurrentLocation = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ExampleEntities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ExampleStringData = c.String(),
                        ExampleIntegerData = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ExampleChildEntities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ExampleData = c.String(),
                        ParentEntityId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ExampleEntities", t => t.ParentEntityId, cascadeDelete: true)
                .Index(t => t.ParentEntityId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ExampleChildEntities", "ParentEntityId", "dbo.ExampleEntities");
            DropIndex("dbo.ExampleChildEntities", new[] { "ParentEntityId" });
            DropTable("dbo.ExampleChildEntities");
            DropTable("dbo.ExampleEntities");
            DropTable("dbo.Barrels");
        }
    }
}
