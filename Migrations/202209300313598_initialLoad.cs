namespace CRUDInMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialLoad : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        City = c.String(),
                        Age = c.Int(nullable: false),
                        EmailId = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Employees");
        }
    }
}
