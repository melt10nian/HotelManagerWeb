namespace Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CustomerInfos", "PhoneNumber", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CustomerInfos", "PhoneNumber", c => c.Int(nullable: false));
        }
    }
}
