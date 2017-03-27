namespace Paytech.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Animals",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(),
                        Type = c.Int(nullable: false),
                        Birth = c.DateTime(nullable: false),
                        OwnerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.People", t => t.OwnerId, cascadeDelete: true)
                .Index(t => t.OwnerId);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Animals", "OwnerId", "dbo.People");
            DropIndex("dbo.Animals", new[] { "OwnerId" });
            DropTable("dbo.People");
            DropTable("dbo.Animals");
        }
    }
}
