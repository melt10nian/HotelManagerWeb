namespace Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CustomerInfos", "Disable", c => c.Int(nullable: false));
            DropColumn("dbo.CustomerInfos", "Enable");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CustomerInfos", "Enable", c => c.Int(nullable: false));
            DropColumn("dbo.CustomerInfos", "Disable");
        }
    }
}
