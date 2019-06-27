namespace EntityFrameworkExample.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bag1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bags", "Weight", c => c.Double(nullable: false));
            DropColumn("dbo.Bags", "Height");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Bags", "Height", c => c.Double(nullable: false));
            DropColumn("dbo.Bags", "Weight");
        }
    }
}
