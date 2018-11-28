namespace LabManagementWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSample : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Samples",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        SampleID = c.Int(nullable: false),
                        Weight = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Job_ID = c.Int(nullable: false),
                        DateCreated = c.DateTime(),
                        UserCreated = c.String(),
                        DateModified = c.DateTime(),
                        UserModified = c.String(),
                        Job_ID1 = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Jobs", t => t.Job_ID1)
                .Index(t => t.Job_ID1);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Samples", "Job_ID1", "dbo.Jobs");
            DropIndex("dbo.Samples", new[] { "Job_ID1" });
            DropTable("dbo.Samples");
        }
    }
}
