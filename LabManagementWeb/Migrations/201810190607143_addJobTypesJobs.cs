namespace LabManagementWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addJobTypesJobs : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Jobs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        JobNumber = c.String(),
                        Elements = c.String(),
                        Standards = c.String(),
                        JobType_ID = c.Int(nullable: false),
                        DateCreated = c.DateTime(),
                        UserCreated = c.String(),
                        DateModified = c.DateTime(),
                        UserModified = c.String(),
                        JobType_ID1 = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.JobTypes", t => t.JobType_ID1)
                .Index(t => t.JobType_ID1);
            
            CreateTable(
                "dbo.JobTypes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Prefix = c.String(),
                        DateCreated = c.DateTime(),
                        UserCreated = c.String(),
                        DateModified = c.DateTime(),
                        UserModified = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Jobs", "JobType_ID1", "dbo.JobTypes");
            DropIndex("dbo.Jobs", new[] { "JobType_ID1" });
            DropTable("dbo.JobTypes");
            DropTable("dbo.Jobs");
        }
    }
}
