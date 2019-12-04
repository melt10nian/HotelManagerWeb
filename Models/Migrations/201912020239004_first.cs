namespace Models.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class first : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CustomerInfo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        IdNumber = c.String(),
                        Birthday = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CustomerInfo");
        }
    }
}
